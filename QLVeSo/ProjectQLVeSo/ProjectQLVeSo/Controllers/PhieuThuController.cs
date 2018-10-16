using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectQLVeSo.Controllers
{
    public class PhieuThuController : Controller
    {
        // GET: PhieuThu
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhieuThu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhieuThu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuThu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuThu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhieuThu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuThu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhieuThu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}