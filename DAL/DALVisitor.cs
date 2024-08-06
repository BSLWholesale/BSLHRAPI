using BSLHRAPI.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BSLHRAPI.DAL
{
    public class DALVisitor
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        public clsVisitor Fn_Insert_Visitor(clsVisitor objReq)
        {
            var objResp = new clsVisitor();
            try
            {
                if (objReq.VisitorPassId == 0)
                {
                    objResp.ErrorMsg = "Visitor Id is not Supplied.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorName))
                {
                    objResp.ErrorMsg = "Please Enter Visitor Name.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorCompanyName))
                {
                    objResp.ErrorMsg = "Please Enter a Company Name.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorMobileNo))
                {
                    objResp.ErrorMsg = "Please Enter a Mobile Number.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorAddress))
                {
                    objResp.ErrorMsg = "Please Enter an Address.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorPurposeOfVisit))
                {
                    objResp.ErrorMsg = "Please Enter a Purpose of Visit.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorReason))
                {
                    objResp.ErrorMsg = "Please Enter a Reason.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorIdProof))
                {
                    objResp.ErrorMsg = "Please Select a ID Proof.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorIdProofNo))
                {
                    objResp.ErrorMsg = "Please Enter a ID Proof No.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.VisitorPassNo))
                {
                    objResp.ErrorMsg = "Please Enter a Pass Number.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.WhomToMeet))
                {
                    objResp.ErrorMsg = "Please Enter Whom To Meet.";
                }
                else if (string.IsNullOrWhiteSpace(objReq.PersonDepartment))
                {
                    objResp.ErrorMsg = "Please Enter Person Department.";
                }
                else
                {
                    if (con.State == ConnectionState.Broken)
                    { con.Close(); }
                    if (con.State == ConnectionState.Closed)
                    { con.Open(); }

                    cmd = new SqlCommand("USP_VisitorGatePass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VPassId", objReq.VisitorPassId);
                    cmd.Parameters.AddWithValue("@VisitorName", objReq.VisitorName);
                    cmd.Parameters.AddWithValue("@VCompanyName", objReq.VisitorCompanyName);
                    cmd.Parameters.AddWithValue("@VMobile", objReq.VisitorMobileNo);
                    cmd.Parameters.AddWithValue("@VAddress", objReq.VisitorAddress);
                    cmd.Parameters.AddWithValue("@VPurposeOfVisit", objReq.VisitorPurposeOfVisit);
                    cmd.Parameters.AddWithValue("@VReason", objReq.VisitorReason);
                    cmd.Parameters.AddWithValue("@VisitorIdProof", objReq.VisitorIdProof);
                    cmd.Parameters.AddWithValue("@VisitorIdProofNo", objReq.VisitorIdProofNo);
                    cmd.Parameters.AddWithValue("@VisitorPassNo", objReq.VisitorPassNo);
                    cmd.Parameters.AddWithValue("@WhomToMeet", objReq.WhomToMeet);
                    cmd.Parameters.AddWithValue("@PersonDepartment", objReq.PersonDepartment);
                    cmd.Parameters.AddWithValue("@VisitorInDateTime", objReq.VisitorInDateTime);
                    //cmd.Parameters.AddWithValue("@VisitorInDateTime", DateTime.Now);
                    //cmd.Parameters.AddWithValue("@VisitorOutDateTime", objReq.VisitorOutDateTime);
                    cmd.Parameters.AddWithValue("@VStatus", objReq.VStatus);
                    cmd.Parameters.AddWithValue("@LoginId", objReq.LoginId);
                    cmd.Parameters.AddWithValue("@QueryType", "Insert");

                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.ErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.ErrorMsg = "Failed";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Insert_Visitor", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.ErrorMsg = exp.Message.ToString();
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
            return objResp;
        }


        public List<clsVisitor> Fn_Get_All_Visitor(clsVisitor objReq)
        {
            var _objRespList = new List<clsVisitor>();
            var objResp = new clsVisitor();
            try
            {
                if (con.State == ConnectionState.Broken)
                { con.Close(); }
                if (con.State == ConnectionState.Closed)
                { con.Open(); }

                cmd = new SqlCommand("USP_VisitorGatePass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QueryType", "Select");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        objResp = new clsVisitor();

                        objResp.VisitorPassId = Convert.ToInt32(ds.Tables[0].Rows[i]["VPassId"]);
                        objResp.VisitorName = Convert.ToString(ds.Tables[0].Rows[i]["VisitorName"]);
                        objResp.VisitorMobileNo = Convert.ToString(ds.Tables[0].Rows[i]["VMobile"]);
                        objResp.VisitorInDateTime = Convert.ToString(ds.Tables[0].Rows[i]["VisitorInDateTime"]);
                        i++;
                    }
                }
                else
                {
                    objResp.ErrorMsg = "No Records Found.";
                    _objRespList.Add(objResp);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Get_All_Visitor", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.ErrorMsg = exp.Message.ToString();
                _objRespList.Add(objResp);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return _objRespList;
        }

    }
}