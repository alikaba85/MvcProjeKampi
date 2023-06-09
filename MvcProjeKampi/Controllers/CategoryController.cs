﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.getCategoryList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
           
           CategoryValidator categoryValidator = new CategoryValidator();
           ValidationResult results = categoryValidator.Validate(p);
           if (results.IsValid)
           {
               cm.CategoryAddBL(p);
               return RedirectToAction("GetCategoryList");
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
    }
}

