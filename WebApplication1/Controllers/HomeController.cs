using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          //object a=   ConfigurationManager.GetSection("ConnectionA");
            //   ConfigurationManager.ConnectionSettings[]
            //     ConfigurationManager.ConnectionStrings[""]
            Hashtable config =
(Hashtable)System.Configuration.ConfigurationSettings.GetConfig("myCustomGroup/myCustomSection");

           Hashtable  c=  (Hashtable) config["key"];
            DictionaryEntry b = new DictionaryEntry();
            b.Key = "ee";
            foreach (DictionaryEntry deKey in config)
            {
                 
                Hashtable attribs = (Hashtable)deKey.Value;
                foreach (DictionaryEntry deAttrib in attribs)
                {
                  
                        deAttrib.Key.ToString();
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           

            //var serviceProviders = new List<OWF_VerificationsViewModel>(CreateServiceProviders_HF(onsiteId));    
            //var verifications = new List<OWF_VerificationsViewModel>(CreateNewFundVerifications_HF(onsiteId));

            //serviceProviders.AddRange(verifications);

            //foreach (var verification in serviceProviders)
            //{
            //    Add(verification);
            //    Save();
            //}


            //var  serviceProviders = new List<Class1>(new List<Class1>() { new Class1 { student = "xii" } });
            //var verifications = new List<Class1>(  new List<Class1>() { new Class1 {student="xi" } });
          



            //foreach (var verification in serviceProviders)
            //{
            //    Add(verification);
            //    Save();
            //}
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}