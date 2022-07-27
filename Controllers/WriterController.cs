using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvpKampProject_01.Controllers
{
    public class WriterController : Controller
    {
        
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.AddWriter(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writevalue = wm.GetById(id);
            return View(writevalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.UpdateWriter(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteWriter(int id)
        {
            var values = wm.GetById(id);
            wm.DeleteWriter(values);
            return RedirectToAction("Index");
        }
    }
}