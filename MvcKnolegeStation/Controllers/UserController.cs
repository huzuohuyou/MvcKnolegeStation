using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolFunction;
using System.Data;

namespace MvcKnolegeStation.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logon(string UserName, string Password)
        {
            string _strTableName = "";
            string _strUserName = "";
            string _strPassword = "";
            string _strSQL = "select * from " + _strTableName + " where " + _strUserName + " = " + UserName + " and " + _strPassword + " = " + Password;
            Dictionary<string,string> _dictParam = new Dictionary<string,string>();
            _dictParam.Add(_strUserName,UserName);
            _dictParam.Add(_strPassword,Password);
            DataTable _dtUser =  CommonFunction.OraExecuteBySQL(_strSQL, _dictParam, "User");
            return View();
        }
        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

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
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

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
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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
