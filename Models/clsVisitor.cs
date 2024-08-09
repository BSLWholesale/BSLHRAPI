using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSLHRAPI.Models
{
    public class clsVisitor
    {
        //public int VisitorPassId { get; set; }
        public double VisitorPassId { get; set; }
        public string VisitorName { get; set; }
        public string VisitorCompanyName { get; set; }
        public string VisitorMobileNo { get; set; }
        public string VisitorAddress { get; set; }
        public string VisitorPurposeOfVisit { get; set; }
        public string VisitorReason { get; set; }
        public string VisitorIdProof { get; set; }
        public string VisitorIdProofNo { get; set; }
        public string VisitorPassNo { get; set; }
        public string WhomToMeet { get; set; }
        public string PersonDepartment { get; set; }
        //public DateTime VisitorInDateTime { get; set; }
        public string VisitorInDateTime { get; set; }
        //public DateTime VisitorOutDateTime { get; set; }
        public string VisitorOutDateTime { get; set; }
        public string VStatus { get; set; }
        public int LoginId { get; set; }
        public string ErrorMsg { get; set; }

    }
}