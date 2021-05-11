using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        private Context c = new Context();
        // GET: Static
        public ActionResult Index()
        {
            var pCategory = c.Categories.Count().ToString();
            ViewBag.p1 = pCategory;
            var pBaslik = c.Headings.Count(x=>x.HeadingName == "YAZILIM").ToString();
            ViewBag.p2 = pBaslik;
            var pYazar = (from x in c.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.p3 = pYazar;
            var pEnFazla = c.Categories.Where(u => u.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.p4 = pEnFazla;
            var pDurum = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.p5 = pDurum;


            return View();
        }
    }
}