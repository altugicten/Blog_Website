﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Blog_Website.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();


        // GET: Message
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendBox(p);
            return View(messagelist);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View(); 
        }
        
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = mv.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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

        public ActionResult GetInboxMessageDetails(int id)
        {
            var contactvalues = mm.GetByID(id);
            return View(contactvalues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var contactvalues = mm.GetByID(id);
            return View(contactvalues);
        }
    }
}