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
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Logging;
using Mindscape.LightSpeed.Search;
using Version = Lucene.Net.Util.Version;

namespace ClientSideApp.Plumbing
{

    public class DarcySearch : ISearchEngine
    {
        private readonly AzureDirectory azureDirectory;
        private readonly Analyzer _analyzer = new StandardAnalyzer(Version.LUCENE_30);

        private IndexWriter _indexWriter;
        private bool createNewIndex = false;



        public DarcySearch()
        {

        }
        public DarcySearch(ISet<String> stopWords)
        {
            this._analyzer = (Analyzer)new StandardAnalyzer(Version.LUCENE_30, stopWords);
        }

        public DarcySearch(AzureDirectory azureDirectory)
        {
            this.azureDirectory = azureDirectory;
        }
        public DarcySearch(ISet<String> stopWords, AzureDirectory azureDirectory)
        {
            this.azureDirectory = azureDirectory;
            this._analyzer = (Analyzer)new StandardAnalyzer(Version.LUCENE_30, stopWords);
        }


        public LightSpeedContext Context { get; set; }

        private IndexWriter GetIndexWriter()
        {
            Debug.WriteLine("get index writer");
            IndexWriter indexWriter = new IndexWriter(this.azureDirectory, this._analyzer, createNewIndex, IndexWriter.MaxFieldLength.UNLIMITED);
            //indexWriter.MergeFactor = 10;
            //indexWriter.MaxMergeDocs = 10;
            
            return indexWriter;
        }


        public void Add(IndexKey indexKey, string data)
        {
            Debug.WriteLine("Add");
            //Invariant.ArgumentNotNull((object) indexKey, "indexKey");
            //Invariant.ArgumentNotNull((object) data, "data");
            Document doc = new Document();
            doc.Add(new Field("key", indexKey.Key, Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
            doc.Add(new Field("scope", indexKey.Scope, Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
            doc.Add(new Field("id", indexKey.EntityId, Field.Store.YES, Field.Index.NOT_ANALYZED, Field.TermVector.NO));
            doc.Add(new Field("data", data, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.NO));
            if (this._indexWriter != null)
            {
                this._indexWriter.AddDocument(doc, this._analyzer);

            }
            else
            {
                using (IndexWriter indexWriter = this.GetIndexWriter())
                {
                    
                        indexWriter.AddDocument(doc, this._analyzer);
                        indexWriter.Commit();
                    
                }
            }
        }

        public void BeginBulkAdd()
        {
            Debug.WriteLine("begin bulk add");
            this._indexWriter = this.GetIndexWriter();
        }

        public void Clear()
        {
            Debug.WriteLine("clear");

            createNewIndex = true;
            var q = this.azureDirectory.ListAll();
            foreach (var item in q)
            {
                this.azureDirectory.DeleteFile(item);
            }

        }

        //public LightSpeedContext Context
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public void EndBulkAdd()
        {
            Debug.WriteLine("end bulk add");
            if (this._indexWriter == null)
                return;
           // this._indexWriter.Commit();
            this._indexWriter.Dispose();
            this._indexWriter = (IndexWriter)null;

            createNewIndex = false;
        }

        public void Optimize()
        {
            Debug.WriteLine("optmize");
            IndexWriter indexWriter = this.GetIndexWriter();
            try
            {
                //indexWriter.Optimize();
            }
            finally
            {
                indexWriter.Dispose();
            }
        }

        public void Remove(IndexKey indexKey)
        {
            Debug.WriteLine("remove");
            //Invariant.ArgumentNotNull((object) indexKey, "indexKey");

            using (IndexReader indexReader = IndexReader.Open(this.azureDirectory, false))
            {
                indexReader.DeleteDocuments(new Term("key", indexKey.Key));
                indexReader.Commit();
            }

        }

        public IList<SearchResult> Search(string query, params string[] scopes)
        {
            //Invariant.ArgumentNotEmpty(query, "query");
            //Invariant.ArgumentNotNull((object) scopes, "scopes");


            SearchResult[] searchResultArray;
            using (IndexSearcher indexSearcher = new IndexSearcher(this.azureDirectory))
            {



                Query query1 = new QueryParser(Version.LUCENE_30, "data", this._analyzer).Parse(query);
                QueryWrapperFilter queryFilter = (QueryWrapperFilter)null;
                if (scopes.Length > 0)
                {
                    BooleanQuery booleanQuery = new BooleanQuery();
                    foreach (string scope in scopes)
                        booleanQuery.Add((Query)new TermQuery(new Term("scope", scope)), Occur.SHOULD);
                    queryFilter = new QueryWrapperFilter((Query)booleanQuery);
                }
                TopDocs hits = queryFilter != null
                    ? indexSearcher.Search(query1, queryFilter, 1)
                    : ((Searcher)indexSearcher).Search(query1, 1);
                searchResultArray = new SearchResult[hits.TotalHits];
                int n = 0;
                foreach (var hit in hits.ScoreDocs)
                {
                    Document doc = indexSearcher.Doc(hit.Doc);
                    searchResultArray[n] = new SearchResult(doc.GetField("key").StringValue,
                        doc.GetField("scope").StringValue, doc.GetField("id").StringValue, hit.Score);
                    n++;
                }


            }
            return (IList<SearchResult>)searchResultArray;
        }

        public void Update(IndexKey indexKey, string data)
        {
            Debug.WriteLine("update");
            //Invariant.ArgumentNotNull((object) indexKey, "indexKey");
            //Invariant.ArgumentNotNull((object) data, "data");
            this.Remove(indexKey);
            this.Add(indexKey, data);
        }
    }


    public class LightSpeedHelper
    {
        public static LightSpeedContext<LightSpeedModelUnitOfWork> GetLightSpeedContext()
        {
            //create folder  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "/SearchEngine")
            //if not exists

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            CloudStorageAccount.TryParse(CloudConfigurationManager.GetSetting("luceneBlobStorage"), out cloudStorageAccount);
            AzureDirectory azureDirectory = new AzureDirectory(cloudStorageAccount, "testcatalog");


            var searcher = new DarcySearch(azureDirectory);

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