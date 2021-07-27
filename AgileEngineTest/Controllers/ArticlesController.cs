﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTest.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: ArticlesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArticlesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticlesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticlesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticlesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}