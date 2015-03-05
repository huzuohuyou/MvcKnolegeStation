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


        public ActionResult Search(string search)
        {

            string _strSql = "select * from knoledge where m_strDesc like:m_strDesc";
            char[] _cSerrch = search.ToCharArray();
            string _strSearch = "%";
            foreach (var item in _cSerrch)
            {
                _strSearch += item + "%";
            }
            _strSearch += "%";
            Dictionary<string, string> _dictParam = new Dictionary<string, string>();
            _dictParam.Add("m_strDesc", _strSearch);
            DataTable _dtKnoledgeSet = CommonFunction.OraExecuteBySQL(_strSql, _dictParam, "KnoledgeSet");
            PublicProperity.m_dtKnoledges = _dtKnoledgeSet;
            List<DataRow> _listKnoledgeName = new List<DataRow>();
            foreach (DataRow item in _dtKnoledgeSet.Rows)
            {
                _listKnoledgeName.Add(item);
            }
            ViewBag.KnoledgeSet = _listKnoledgeName;
            return View("Index");
        }

        //
        // GET: /Knoledge/Details/5

        public ActionResult Details(string Id)
        {
            //SetCurrentModel(Id);
            IncreaseHot(Id);
            DataRow[] _drKnoledge = PublicProperity.m_dtKnoledges.Select("Id='" + Id + "'");
            if (1==_drKnoledge.Length)
            {
                ViewBag.Id = _drKnoledge[0]["Id"].ToString();
                ViewBag.m_strUserId = _drKnoledge[0]["m_strUserId"].ToString();
                ViewBag.m_strTitle = _drKnoledge[0]["m_strTitle"].ToString();
                ViewBag.m_strDesc = _drKnoledge[0]["m_strDesc"].ToString();
                ViewBag.m_strHot = _drKnoledge[0]["m_strHot"].ToString();
                ViewBag.m_dateUploadTime = _drKnoledge[0]["m_dateUploadTime"].ToString();
            }
            return View();
        }

        /// <summary>
        /// 增加访问热度
        /// </summary>
        /// <param name="p_strId">Id</param>
        public void IncreaseHot(string p_strId) {
            Dictionary<string, string> _dictParam = new Dictionary<string, string>();
            _dictParam.Add("id",p_strId);
            string _strSql = "update Knoledge set m_strHot = m_strHot+1 where id = :id";
            CommonFunction.OraExecuteNonQuery(_strSql,_dictParam);
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
            if (true)
            {
                //UserModels um = new UserModels();
                //um.UserId1=
            }
            Dictionary<string, string> _dictParam = new Dictionary<string, string>();
            _dictParam.Add("Id", Guid.NewGuid().ToString());
            _dictParam.Add("m_strUserId", m_strUserId);
            _dictParam.Add("m_strTitle", m_strTitle);
            _dictParam.Add("m_strDesc", m_strDesc);
            _dictParam.Add("m_dateUploadTime", m_dateUploadTime);
            string _strSql = "insert into knoledge(Id,m_strUserId,m_strTitle,m_strDesc,m_dateUploadTime) values(:Id,:m_strUserId,:m_strTitle,:m_strDesc,to_date(:m_dateUploadTime,'yyyy-MM-dd'))";
            int iResult = CommonFunction.OraExecuteNonQuery(_strSql, _dictParam);
            return View("Create");
        }

        /// <summary>
        /// Model属性赋值
        /// </summary>
        /// <param name="Id">KnoledgeId</param>
        public void SetCurrentModel(string Id)
        {
            DataRow[] _drKnoledge = null;
            if (null != PublicProperity.m_dtKnoledges)
            {
                _drKnoledge = PublicProperity.m_dtKnoledges.Select("Id='" + Id + "'");
            }
            else if (null != PublicProperity.m_dtHotKnoledges)
            {
                _drKnoledge = PublicProperity.m_dtHotKnoledges.Select("Id='" + Id + "'");
            }
            else
            {
                return;
            }
            KnoledgeModels km = new KnoledgeModels();
            if (1 == _drKnoledge.Length)
            {
                foreach (DataColumn _dcItem in _drKnoledge[0].Table.Columns)
                {
                    object[] _oParam = new object[1];
                    _oParam[0] = _drKnoledge[0][_dcItem].ToString();
                    CommonFunction.SetProperitys(km, "Set" + _dcItem.ToString(), _oParam);
                }
                PublicProperity.m_curModel = km;
            }
        }

        public ActionResult Edit(string Id)
        {
            //SetCurrentModel(Id);
            //Detail->Edit用过吗
            object _strUserId = Request.QueryString["Id"];
            DataRow[] _drKnoledge = PublicProperity.m_dtKnoledges.Select("Id='" + Id + "'");
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
        /// <summary>
        /// Edit 保存
        /// </summary>
        /// <param name="m_strTitle"></param>
        /// <param name="m_strDesc"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(string m_strTitle, string m_strDesc, string Id)
        {
            //SetCurrentModel(Id);
            Dictionary<string, string> _dictParam = new Dictionary<string, string>();
            _dictParam.Add("Id", Id);
            _dictParam.Add("m_strTitle", m_strTitle);
            _dictParam.Add("m_strDesc", m_strDesc);
            string _strSql = "update  knoledge  set m_strTitle = :m_strTitle,m_strDesc=:m_strDesc where Id=:Id";
            int iResult = CommonFunction.OraExecuteNonQuery(_strSql, _dictParam);
            return RedirectToAction("Index", "Knoledge");
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