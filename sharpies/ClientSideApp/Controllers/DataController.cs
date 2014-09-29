using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientSideApp.Models;
using ClientSideApp.Plumbing;
using dotNetExt;
using Faker;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Logging;

namespace ClientSideApp.Controllers
{

#if DEBUG
    public class DataController : Controller
    {

        private readonly Lazy<LightSpeedContext<LightSpeedModelUnitOfWork>> _lazyContext = new Lazy
            <LightSpeedContext<LightSpeedModelUnitOfWork>>(
            LightSpeedHelper.GetLightSpeedContext);

        

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
        public ActionResult ReIndex()
        {
            Context.SearchEngine.Rebuild(IsolationLevel.ReadCommitted,
             typeof(Gift));

            return View();
        }

        
        public ActionResult Generate(int quantityToGenerate = 30)
        {

            
            using (var uow = Context.CreateUnitOfWork())
            {
                GenerateCustomers(quantityToGenerate, uow);
                GenerateGifts(quantityToGenerate, uow);
                return View();
            }
        }

        private void GenerateCustomers(int customersToGenerate, LightSpeedModelUnitOfWork uow)
        {
            var fake = new Fake<Customer>();

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

                uow.Attach(customer, AttachMode.Import);
                uow.Add(customer);
            });
            uow.SaveChanges();
        }

        private void GenerateGifts(int giftsToGenerate, LightSpeedModelUnitOfWork uow)
        {
            var fake = new Fake<Gift>();

            giftsToGenerate.Times(i =>
            {
               Gift gift = fake.Generate();
                
               

                gift.ResetId();

                uow.Attach(gift, AttachMode.Import);
                uow.Add(gift);
            });
            uow.SaveChanges();
        }
    }


#endif
}