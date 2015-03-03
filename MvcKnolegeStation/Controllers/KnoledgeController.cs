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
            //DataTable _dtKnoledgeSet = CommonFunction.OleExecuteBySQL(_strSql, new SortedDictionary<string, string>(), "KnoledgeSet");
            DataTable _dtKnoledgeSet = CommonFunction.OraExecuteBySQL(_strSql, new Dictionary<string, string>(), "KnoledgeSet");
            PublicProperity.m_dtKnoledges = _dtKnoledgeSet;
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

        public ActionResult Details(string m_strUserId)
        {
            object _strUserId = Request.QueryString["m_strUserId"];
            DataRow[] _drKnoledge =  PublicProperity.m_dtKnoledges.Select("m_strUserId='" + _strUserId + "'");
            if (1==_drKnoledge.Length)
            {
                ViewBag.m_strUserId = _drKnoledge[0]["m_strUserId"].ToString();
                ViewBag.m_strTitle = _drKnoledge[0]["m_strTitle"].ToString();
                ViewBag.m_strDesc = _drKnoledge[0]["m_strDesc"].ToString();
                ViewBag.m_strHot = _drKnoledge[0]["m_strHot"].ToString();
                ViewBag.m_dateUploadTime = _drKnoledge[0]["m_dateUploadTime"].ToString();
            }
            return View();
        }

        //
        // GET: /Knoledge/Create

        public ActionResult Create()
        {

            return View("Create");
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

        public ActionResult CreateItem(string m_strUserId, string m_strTitle, string m_strDesc, string m_dateUploadTime)
        {
            Dictionary<string, string> _dictParam = new Dictionary<string, string>();
            _dictParam.Add("m_strUserId", m_strUserId);
            _dictParam.Add("m_strTitle", m_strTitle);
            _dictParam.Add("m_strDesc", m_strDesc);
            _dictParam.Add("m_dateUploadTime", m_dateUploadTime);
            string _strSql = "insert into knoledge(m_strUserId,m_strTitle,m_strDesc,m_dateUploadTime) values(:m_strUserId,:m_strTitle,:m_strDesc,to_date(:m_dateUploadTime,'yyyy-MM-dd'))";
            int iResult = CommonFunction.OraExecuteNonQuery(_strSql, _dictParam);
            return View("Create");
        }
        //
        // GET: /Knoledge/Edit/5

        public ActionResult Edit(string m_strUserId)
        {
            object _strUserId = Request.QueryString["m_strUserId"];
            DataRow[] _drKnoledge = PublicProperity.m_dtKnoledges.Select("m_strUserId='" + _strUserId + "'");
            if (1 == _drKnoledge.Length)
            {
                ViewBag.m_strUserId = _drKnoledge[0]["m_strUserId"].ToString();
                ViewBag.m_strTitle = _drKnoledge[0]["m_strTitle"].ToString();
                ViewBag.m_strDesc = _drKnoledge[0]["m_strDesc"].ToString();
                ViewBag.m_strHot = _drKnoledge[0]["m_strHot"].ToString();
                ViewBag.m_dateUploadTime = _drKnoledge[0]["m_dateUploadTime"].ToString();
            }
            return View();
        }

        //
        // POST: /Knoledge/Edit/5

        [HttpPost]
        public ActionResult Edit(string m_strTitle, string m_strDesc, string m_strUserId)
        {
            Dictionary<string, string> _dictParam = new Dictionary<string, string>();
            _dictParam.Add("m_strTitle", m_strTitle);
            _dictParam.Add("m_strDesc", m_strDesc);
            string _strSql = "update  knoledge  set m_strTitle = :m_strTitle,m_strDesc=:m_strDesc where m_strUserId=:m_strUserId";
            int iResult = CommonFunction.OraExecuteNonQuery(_strSql, _dictParam);
            return View("");
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