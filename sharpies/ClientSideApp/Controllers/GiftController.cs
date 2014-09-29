using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClientSideApp.Models;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;
using Mindscape.LightSpeed.Logging;
using NHandlebars;

namespace ClientSideApp.Controllers
{
    public class GiftController : ApiController
    {
        private readonly Lazy<LightSpeedContext<LightSpeedModelUnitOfWork>> _lazyContext = new Lazy<LightSpeedContext<LightSpeedModelUnitOfWork>>(
           () => new LightSpeedContext<LightSpeedModelUnitOfWork>
           {
               ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
               IdentityMethod = IdentityMethod.IdentityColumn,
               AutoTimestampMode = AutoTimestampMode.Utc,
               QuoteIdentifiers = true,
               Logger = new TraceLogger()
           });

        public LightSpeedContext<LightSpeedModelUnitOfWork> Context
        {
            get { return _lazyContext.Value; }
        }
        // GET: api/Gift
        public IEnumerable<Gift> Get()
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                List<Gift> gift = uow.Gifts.ToList();
                return gift;
            }
        }

       
        // GET: api/Gift/5
        public Gift Get(int id)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Gift customer = uow.FindById<Gift>(id);
                return customer;
            }
        }

        // POST: api/Gift
        public void Post([FromBody]Gift gift)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                gift.ResetId();
                uow.Attach(gift, AttachMode.Import);
                uow.Add(gift);
                uow.SaveChanges(true);
            }
        }


       

        // PUT: api/Gift/5
        public void Put(int id, [FromBody]Gift value)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Gift gift = uow.FindById<Gift>(id);

               gift.CloneValues(value);

                uow.Attach(gift);
                uow.SaveChanges();
            }
        }

        // DELETE: api/Gift/5
        public void Delete(int id)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Gift gift = uow.FindById<Gift>(id);
                if (gift == null) return;

                uow.Remove(gift);
                uow.SaveChanges();
            }
        }

        // GET: api/Gift/5/notes
        //[Route("api/customers/{customerId}/notes")]
        //[AcceptVerbs("GET")]
        //public String GetNotesForCustomer(int customerId)
        //{
        //    using (var uow = Context.CreateUnitOfWork())
        //    {
        //        Customer customer = uow.FindById<Customer>(customerId);
        //        if (customer == null) { return String.Empty; }

        //        String template = "<ul class='notes'>{{#each notes}}<li class='note'>{{this}}</li>{{/each}}</ul>";
        //        var data = new { createdate = customer.CreatedOn, notes = customer.Notes.OrderByDescending(o => o.CreatedOn).Select(s => s.Text) };
        //        var output = Handlebars.Render(template, data);

        //        return output;
        //    }
        //}

        // GET: api/Gift/5/notes
        //[Route("api/customers/{customerId}/notes")]
        //[AcceptVerbs("POST")]
        //public void PostNoteForCustomer(int customerId, [FromBody]String text)
        //{
        //    using (var uow = Context.CreateUnitOfWork())
        //    {
        //        Customer customer = uow.FindById<Customer>(customerId);
        //        if (customer == null) return;

        //        Note note = new Note() { Text = text };
        //        uow.Attach(note, AttachMode.Import);
        //        customer.Notes.Add(note);

        //        uow.SaveChanges();
        //    }
        //}

    
    }
}
