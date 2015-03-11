using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ToolFunction;
using MvcKnolegeStation.Models;

namespace MvcKnolegeStation.Controllers
{
    public class PictureWallController : Controller
    {
        //
        // GET: /PictureWall/

        public ActionResult Index()
        {
            string _strSql = "select * from picturewall";
            DataTable _dtPictures = CommonFunction.OraExecuteBySQL(_strSql, new Dictionary<string, string>(), "Pictures");
            PublicProperity.m_dtKnoledges = _dtPictures;
            List<DataRow> _listPicture = new List<DataRow>();
            foreach (DataRow item in _dtPictures.Rows)
            {
                _listPicture.Add(item);
            }
            ViewBag.Pictures = _listPicture;
            Session.Add("Pictures", _listPicture);
            return View();
        }

        //
        // GET: /PictureWall/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PictureWall/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PictureWall/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PictureWall/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PictureWall/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PictureWall/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PictureWall/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
