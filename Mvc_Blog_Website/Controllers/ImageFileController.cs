using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Website.Controllers
{
    public class ImageFileController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());


        // GET: ImageFile
        public ActionResult Index()
        {
            var results = ifm.GetList();
            return View(results);
        }
    }
}