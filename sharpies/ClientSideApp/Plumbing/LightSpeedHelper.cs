using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using ClientSideApp.Models;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store.Azure;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Logging;
using Mindscape.LightSpeed.Search;
using Version = Lucene.Net.Util.Version;

namespace ClientSideApp.Plumbing
{

    public class AzureLuceneSearch : ISearchEngine
    {
        private readonly AzureDirectory _azureDirectory;
        private readonly Analyzer _analyzer = new StandardAnalyzer(Version.LUCENE_30);

        private IndexWriter _indexWriter;
        private bool _createNewIndex;

        public AzureLuceneSearch(AzureDirectory azureDirectory)
        {
            _azureDirectory = azureDirectory;
        }
        public AzureLuceneSearch(ISet<String> stopWords, AzureDirectory azureDirectory)
        {
            _azureDirectory = azureDirectory;
            _analyzer = new StandardAnalyzer(Version.LUCENE_30, stopWords);
        }


        public LightSpeedContext Context { get; set; }

        private IndexWriter GetIndexWriter()
        {
            IndexWriter indexWriter = new IndexWriter(_azureDirectory, _analyzer, _createNewIndex, IndexWriter.MaxFieldLength.UNLIMITED);
            //indexWriter.MergeFactor = 10;
            //indexWriter.MaxMergeDocs = 10;
            
            return indexWriter;
        }


        public void Add(IndexKey indexKey, string data)
        {
            
            //Invariant.ArgumentNotNull((object) indexKey, "indexKey");
            //Invariant.ArgumentNotNull((object) data, "data");
            Document doc = new Document();
            doc.Add(new Field("key", indexKey.Key, Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
            doc.Add(new Field("scope", indexKey.Scope, Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
            doc.Add(new Field("id", indexKey.EntityId, Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
            doc.Add(new Field("data", data, Field.Store.NO, Field.Index.ANALYZED, Field.TermVector.NO));
            if (_indexWriter != null)
            {
                _indexWriter.AddDocument(doc, _analyzer);
            }
            else
            {
                using (IndexWriter indexWriter = GetIndexWriter())
                {
                        indexWriter.AddDocument(doc, _analyzer);
                }
            }
        }

        public void BeginBulkAdd()
        {
           _indexWriter = GetIndexWriter();
        }

        public void Clear()
        {
           _createNewIndex = true;
            var files = _azureDirectory.ListAll();
            foreach (var file in files)
            {
                _azureDirectory.DeleteFile(file);
            }
        }

      

        public void EndBulkAdd()
        {
            if (_indexWriter == null)
                return;
           
            _indexWriter.Dispose();
            _indexWriter = null;

            _createNewIndex = false;
        }

        public void Optimize()
        {
            using (IndexWriter indexWriter = GetIndexWriter())
            {
                    indexWriter.Optimize();
            }
        }

        public void Remove(IndexKey indexKey)
        {
            
            //Invariant.ArgumentNotNull((object) indexKey, "indexKey");

            using (IndexReader indexReader = IndexReader.Open(_azureDirectory, false))
            {
                indexReader.DeleteDocuments(new Term("key", indexKey.Key));
            }

        }

        public IList<SearchResult> Search(string query, params string[] scopes)
        {
            //Invariant.ArgumentNotEmpty(query, "query");
            //Invariant.ArgumentNotNull((object) scopes, "scopes");


            List<SearchResult> searchResultArray = new List<SearchResult>();
            using (IndexSearcher indexSearcher = new IndexSearcher(_azureDirectory))
            {
                Query luceneQuery = new QueryParser(Version.LUCENE_30, "data", _analyzer).Parse(query);
                QueryWrapperFilter queryFilter = null;
                if (scopes.Length > 0)
                {
                    BooleanQuery booleanQuery = new BooleanQuery();
                    foreach (string scope in scopes)
                    {
                        booleanQuery.Add(new TermQuery(new Term("scope", scope)), Occur.SHOULD);
                    }
                    queryFilter = new QueryWrapperFilter(booleanQuery);
                }
                TopDocs hits = queryFilter != null
                    ? indexSearcher.Search(luceneQuery, queryFilter, 1)
                    : (indexSearcher).Search(luceneQuery, 1);


                searchResultArray.AddRange(
                    hits.ScoreDocs.Select(hit => new {hit, doc = indexSearcher.Doc(hit.Doc)})
                        .Select(
                            @t =>
                                new SearchResult(@t.doc.GetField("key").StringValue,
                                    @t.doc.GetField("scope").StringValue, @t.doc.GetField("id").StringValue,
                                    @t.hit.Score)));
            }
            return searchResultArray;
        }

        public void Update(IndexKey indexKey, string data)
        {
            //Invariant.ArgumentNotNull((object) indexKey, "indexKey");
            //Invariant.ArgumentNotNull((object) data, "data");
            Remove(indexKey);
            Add(indexKey, data);
        }
    }


    public class LightSpeedHelper
    {
        public static LightSpeedContext<LightSpeedModelUnitOfWork> GetLightSpeedContext()
        {
            //create folder  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "/SearchEngine")
            //if not exists

            CloudStorageAccount cloudStorageAccount;
            CloudStorageAccount.TryParse(CloudConfigurationManager.GetSetting("luceneBlobStorage"), out cloudStorageAccount);
            

            AzureDirectory azureDirectory = new AzureDirectory(cloudStorageAccount, "searchindex");


            var searcher = new AzureLuceneSearch(azureDirectory);

            return new LightSpeedContext<LightSpeedModelUnitOfWork>
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                IdentityMethod = IdentityMethod.IdentityColumn,
                AutoTimestampMode = AutoTimestampMode.Utc,
                QuoteIdentifiers = true,
                SearchEngine = new SearchEngineBroker(searcher),
                // SearchEngineFileLocation = path,
                DataProvider = DataProvider.SqlServer2012,
                Logger = new TraceLogger()
            };
        }
    }
}