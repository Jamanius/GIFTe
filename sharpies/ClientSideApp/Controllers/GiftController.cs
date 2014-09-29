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
        public IEnumerable<Customer> Get()
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                List<Gift> gift = uow.Gifts.ToList();
                return gift;
            }
        }

        // PATCH: api/Gift/4
        public void Patch(int id, Dictionary<String, String> patch)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Customer customer = uow.FindById<Customer>(id);
                if (customer == null) { return; }

                customer.Patch(patch);

                uow.Attach(customer);
                uow.SaveChanges();
            }
        }
        // GET: api/Gift/5
        public Customer Get(int id)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Customer customer = uow.FindById<Customer>(id);
                return customer;
            }
        }

        // POST: api/Gift
        public void Post([FromBody]Customer customer)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                customer.ResetId();
                uow.Attach(customer, AttachMode.Import);
                uow.Add(customer);
                uow.SaveChanges(true);
            }
        }


        // LINK: api/Gift
        [AcceptVerbs("LINK")]
        public void PostMany([FromBody]List<Customer> customers)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                customers.ForEach(customer =>
                {
                    customer.ResetId();
                    uow.Attach(customer, AttachMode.Import);
                    uow.Add(customer);
                });

                uow.SaveChanges();
            }
        }

        // PUT: api/Gift/5
        public void Put(int id, [FromBody]Customer value)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Customer customer = uow.FindById<Customer>(id);

                customer.CloneValues(value);

                uow.Attach(customer);
                uow.SaveChanges();
            }
        }

        // DELETE: api/Gift/5
        public void Delete(int id)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Customer customer = uow.FindById<Customer>(id);
                if (customer == null) return;

                uow.Remove(customer);
                uow.SaveChanges();
            }
        }

        // GET: api/Gift/5/notes
        [Route("api/customers/{customerId}/notes")]
        [AcceptVerbs("GET")]
        public String GetNotesForCustomer(int customerId)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Customer customer = uow.FindById<Customer>(customerId);
                if (customer == null) { return String.Empty; }

                String template = "<ul class='notes'>{{#each notes}}<li class='note'>{{this}}</li>{{/each}}</ul>";
                var data = new { createdate = customer.CreatedOn, notes = customer.Notes.OrderByDescending(o => o.CreatedOn).Select(s => s.Text) };
                var output = Handlebars.Render(template, data);

                return output;
            }
        }

        // GET: api/Gift/5/notes
        [Route("api/customers/{customerId}/notes")]
        [AcceptVerbs("POST")]
        public void PostNoteForCustomer(int customerId, [FromBody]String text)
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                Customer customer = uow.FindById<Customer>(customerId);
                if (customer == null) return;

                Note note = new Note() { Text = text };
                uow.Attach(note, AttachMode.Import);
                customer.Notes.Add(note);

                uow.SaveChanges();
            }
        }

    
    }
}
