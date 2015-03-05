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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string _strSql2 = "select * from knoledge";
            DataTable _dtKnoledgeSet = CommonFunction.OraExecuteBySQL(_strSql2, new Dictionary<string, string>(), "KnoledgeSet");
            PublicProperity.m_dtKnoledges = _dtKnoledgeSet;

            string _strSql = "select rownum, t.* from (select * from knoledge order by to_number(m_strhot) desc ) t where rownum<=5  ";
            DataTable _dtHotKnoledgeSet = CommonFunction.OraExecuteBySQL(_strSql, new Dictionary<string, string>(), "KnoledgeSet");
            PublicProperity.m_dtHotKnoledges = _dtHotKnoledgeSet;
            List<DataRow> _listKnoledgeName = new List<DataRow>();
            foreach (DataRow item in _dtHotKnoledgeSet.Rows)
            {
                _listKnoledgeName.Add(item);
            }
            ViewBag.m_dtHotKnoledges = _listKnoledgeName;

            string _strSqlNew = "select rownum, t.* from (select * from knoledge order by m_dateuploadtime desc ) t where rownum<=5  ";
            DataTable _dtNewKnoledgeSet = CommonFunction.OraExecuteBySQL(_strSqlNew, new Dictionary<string, string>(), "KnoledgeSet");
            PublicProperity.m_dtNewKnoledges = _dtNewKnoledgeSet;
            List<DataRow> _listNewKnoledgeName = new List<DataRow>();
            foreach (DataRow item in _dtNewKnoledgeSet.Rows)
            {
                _listNewKnoledgeName.Add(item);
            }
            ViewBag.m_dtNewHotKnoledges = _listNewKnoledgeName;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
