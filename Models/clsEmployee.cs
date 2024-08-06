using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSLHRAPI.Models
{
    public class clsEmployee
    {
        public Nullable<Int64> nEmpId { get; set; }
        public string vEmpEmailId { get; set; }
        public string vEmpMobile { get; set; }
        public string vEmpName { get; set; }
        public string vEmpLocation { get; set; }
        public int nBSLTravelDesk { get; set; }
        public string vEmpPassword { get; set; }
        public DateTime DOB { get; set; }
        public string vEmpDivision { get; set; }
        public bool bEmpActiveStatus { get; set; }
        public string vEmpType { get; set; }
        public string vEmpGrade { get; set; }
        public string vEmpDesignation { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class ExpenseClaimMaster
    {
        public Nullable<Int64> ExpenseID { get; set; }
        public Nullable<Int64> EmpId { get; set; }
        public Nullable<DateTime> AppliedDate { get; set; }
        public string ApproveStatus { get; set; }
        public string vErrorMsg { get; set; }
    }
    public class ExpenseClaimDetail
    {
        public Nullable<int> EDetId { get; set; }
        public Nullable<Int64> ExpenseID { get; set; }
        public Nullable<int> EModeId { get; set; }
        public Nullable<Int64> TravelId { get; set; }
        public float EAmount { get; set; }
        public string Remarks { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsExpenseMode
    {
        public Nullable<int> EModeId { get; set; }
        public string EModeDescription { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsTravelDeskMaster
    {
        public Nullable<int> TDeskId { get; set; }
        public string TDeskDescription { get; set; }
        public string TDeskLocation { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsTravelMode
    {
        public Nullable<int> TModeId { get; set; }
        public string TravelDescription { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsTravelRequest
    {
        public Nullable<Int64> TravelID { get; set; }
        public Nullable<Int64> EmpId { get; set; }
        public Nullable<DateTime> RequestDate { get; set; }
        public int BSLTravelDesk { get; set; }
        public string TravelReport { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsTravelRequestDetail
    {
        public Nullable<int> TRDetId { get; set; }
        public Nullable<Int64> TravelID { get; set; }
        public Nullable<int> TravelType { get; set; }
        public Nullable<int> TModeId { get; set; }
        public float Amount { get; set; }
        public Nullable<int> Qty { get; set; }
        public string vErrorMsg { get; set; }
    }

    public class clsRequestDropdown
    {
        public string vFieldName { get; set; }
        public string vValueField { get; set; }
        public string vTBLName { get; set; }
        public string vCriteria { get; set; }
        public string vErrorMsg { get; set; }
    }
    public class clsResponseDropdown
    {
        public string vValueField { get; set; }
        public string vFieldName { get; set; }
        public string vErrorMsg { get; set; }
    }
}