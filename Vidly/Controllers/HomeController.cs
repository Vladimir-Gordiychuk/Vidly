using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Config;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("privacy-policy")]
        public ViewResult PrivacyPolicy()
        {
            ViewBag.Company = SiteConfig.Config.Site.Company;
            ViewBag.SiteName = SiteConfig.Config.Site.Name;
            ViewBag.SiteUrl = SiteConfig.Config.Site.Url;

            ViewBag.ContactUrl = ViewBag.SiteUrl + "/contact";
            ViewBag.PrivacyPolicyUrl = ViewBag.SiteUrl + "/privacy-policy";

            return View();
        }

        [Route("terms-of-service")]
        public ViewResult TermsOfService()
        {
            ViewBag.Company = SiteConfig.Config.Site.Company;
            ViewBag.SiteName = SiteConfig.Config.Site.Name;
            ViewBag.SiteUrl = SiteConfig.Config.Site.Url;

            ViewBag.ContactUrl = SiteConfig.Config.Site.Url + "/contact";
            ViewBag.PrivacyPolicyUrl = SiteConfig.Config.Site.Url + "/privacy-policy";

            return View();
        }

        [Route("about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.FirstName = SiteConfig.Config.Contact.FirstName;
            ViewBag.LastName = SiteConfig.Config.Contact.LastName;
            ViewBag.Email = SiteConfig.Config.Contact.Email;

            ViewBag.AddressLine1 = SiteConfig.Config.Contact.AddressLine1;
            ViewBag.AddressLine2 = SiteConfig.Config.Contact.AddressLine2;
            ViewBag.Country = SiteConfig.Config.Contact.Country;
            ViewBag.ZipCode = SiteConfig.Config.Contact.ZipCode;

            return View();
        }
    }
}