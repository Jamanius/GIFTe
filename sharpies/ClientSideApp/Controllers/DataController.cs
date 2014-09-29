using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientSideApp.Models;
using dotNetExt;
using Faker;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Logging;

namespace ClientSideApp.Controllers
{

#if DEBUG
    public class DataController : Controller
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


        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purge()
        {
            using (var uow = Context.CreateUnitOfWork())
            {
                foreach (var customer in uow.Customers)
                {
                    uow.Remove(customer);
                }
                 
                uow.SaveChanges();
                return View();
            }
        }

        
        public ActionResult Generate(int customersToGenerate = 30)
        {

            var fake = new Fake<Customer>();

            using (var uow = Context.CreateUnitOfWork())
            {
                customersToGenerate.Times(i =>
                {
                    Customer customer = fake.Generate();
                    customer.Phone_number = Phone.Number();
                    5.Times(k =>
                    {
                        var note = new Note();
                        note.Text = Lorem.Paragraph();
                        customer.Notes.Add(note);
                    });
                    

                    customer.ResetId();

                    uow.Attach(customer,AttachMode.Import);
                    uow.Add(customer);
                });
                uow.SaveChanges();
                return View();
            }
        }
       
    }
#endif
}