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
    public class TravelController : ApiController
    {
        DALTravel _DALTravel = new DALTravel();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Travel/Fn_Insert_Travel_Request")]
        public clsTravelRequest Fn_Insert_Travel_Request(clsTravelRequest objReq)
        {
            var objResp = new clsTravelRequest();
            objResp = _DALTravel.Fn_Insert_Travel_Request(objReq);
            return objResp;
        }
    }
}