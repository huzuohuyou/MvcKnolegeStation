using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKnolegeStation.Models;
using ToolFunction;

namespace MvcKnolegeStation.Controllers
{
    public class KnoledgeController : Controller
    {
        private KnolegeContext db = new KnolegeContext();

        //
        // GET: /Knoledge/

        public ActionResult Index()
        {
            string _strSql = "select * from knoledge";
            DataTable _dtKnoledgeSet = CommonFunction.OleExecuteBySQL(_strSql, new Dictionary<string, string>(), "KnoledgeSet");
            List<DataRow> _listKnoledgeName = new List<DataRow>();
            foreach (DataRow item in _dtKnoledgeSet.Rows)
            {
                _listKnoledgeName.Add(item);
            }
            ViewBag.KnoledgeSet = _listKnoledgeName;
            return View();
        }

        //
        // GET: /Knoledge/Details/5

        public ActionResult Details(int id = 0)
        {
            KnoledgeModels knolegemodels = db.Knoleges.Find(id);
            if (knolegemodels == null)
            {
                return HttpNotFound();
            }
            return View(knolegemodels);
        }

        //
        // GET: /Knoledge/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Knoledge/Create

        [HttpPost]
        public ActionResult Create(KnoledgeModels knolegemodels)
        {
            if (ModelState.IsValid)
            {
                db.Knoleges.Add(knolegemodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knolegemodels);
        }

        public ActionResult CreateItem()
        {
            return View("Create");
            //return RedirectToAction("Index");
        }
        //
        // GET: /Knoledge/Edit/5

        public ActionResult Edit(int id = 0)
        {
            KnoledgeModels knolegemodels = db.Knoleges.Find(id);
            if (knolegemodels == null)
            {
                return HttpNotFound();
            }
            return View(knolegemodels);
        }

        //
        // POST: /Knoledge/Edit/5

        [HttpPost]
        public ActionResult Edit(KnoledgeModels knolegemodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knolegemodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knolegemodels);
        }

        //
        // GET: /Knoledge/Delete/5

        public ActionResult Delete(int id = 0)
        {
            KnoledgeModels knolegemodels = db.Knoleges.Find(id);
            if (knolegemodels == null)
            {
                return HttpNotFound();
            }
            return View(knolegemodels);
        }

        //
        // POST: /Knoledge/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            KnoledgeModels knolegemodels = db.Knoleges.Find(id);
            db.Knoleges.Remove(knolegemodels);
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