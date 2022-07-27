using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvpKampProject_01.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
             List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text= x.CategoryName,
                                                       Value= x.CategoryId.ToString()
                                                   }
                                                   ).ToList(); ;
            
            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text= x.WriterName + " " + x.WriterSurname,
                                                       Value= x.WriterId.ToString()
                                                   }
                                                   ).ToList(); ;
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                   ).ToList(); ;
            ViewBag.vlc = valueCategory;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetById(id);
            headingvalues.HeadingStatus = false;
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("Index");
        }

        public ActionResult ActiveHeading(int id)
        {
            var headingvalues = hm.GetById(id);
            headingvalues.HeadingStatus = true;
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("Index");
        }

    }
}