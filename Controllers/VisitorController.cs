using BSLHRAPI.DAL;
using BSLHRAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BSLHRAPI.Controllers
{
    public class VisitorController : ApiController
    {
        // GET: Visitor

        DALVisitor _DALVisitor = new DALVisitor();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Visitor/Fn_Insert_Visitor")]
        public clsVisitor Fn_Insert_Visitor(clsVisitor objReq)
        {
            var objResp = new clsVisitor();
            objResp = _DALVisitor.Fn_Insert_Visitor(objReq);
            return objResp;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Visitor/Fn_Get_All_Visitor")]
        public clsVisitor Fn_Get_All_Visitor(clsVisitor objReq)
        {
            var objResp = new clsVisitor();
            objResp = _DALVisitor.Fn_Get_All_Visitor(objReq);
            return objResp;
        }
    }
}