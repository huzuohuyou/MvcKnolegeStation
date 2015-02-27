using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKnolegeStation.Models;

namespace MvcKnolegeStation.Controllers
{
    public class DownLoadLogController : Controller
    {
        private DownLoadLogContext db = new DownLoadLogContext();

        //
        // GET: /DownLoadLog/

        public ActionResult Index()
        {
            return View(db.DownLoadLogs.ToList());
        }

        //
        // GET: /DownLoadLog/Details/5

        public ActionResult Details(int id = 0)
        {
            DownLoadLogModels downloadlogmodels = db.DownLoadLogs.Find(id);
            if (downloadlogmodels == null)
            {
                return HttpNotFound();
            }
            return View(downloadlogmodels);
        }

        //
        // GET: /DownLoadLog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DownLoadLog/Create

        [HttpPost]
        public ActionResult Create(DownLoadLogModels downloadlogmodels)
        {
            if (ModelState.IsValid)
            {
                db.DownLoadLogs.Add(downloadlogmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downloadlogmodels);
        }

        //
        // GET: /DownLoadLog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DownLoadLogModels downloadlogmodels = db.DownLoadLogs.Find(id);
            if (downloadlogmodels == null)
            {
                return HttpNotFound();
            }
            return View(downloadlogmodels);
        }

        //
        // POST: /DownLoadLog/Edit/5

        [HttpPost]
        public ActionResult Edit(DownLoadLogModels downloadlogmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downloadlogmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(downloadlogmodels);
        }

        //
        // GET: /DownLoadLog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DownLoadLogModels downloadlogmodels = db.DownLoadLogs.Find(id);
            if (downloadlogmodels == null)
            {
                return HttpNotFound();
            }
            return View(downloadlogmodels);
        }

        //
        // POST: /DownLoadLog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DownLoadLogModels downloadlogmodels = db.DownLoadLogs.Find(id);
            db.DownLoadLogs.Remove(downloadlogmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}