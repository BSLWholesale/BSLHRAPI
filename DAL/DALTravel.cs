using BSLHRAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BSLHRAPI.DAL
{
    public class DALTravel
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;

        public clsTravelRequest Fn_Insert_Travel_Request(clsTravelRequest objReq)
        {
            var objResp = new clsTravelRequest();
            try
            {
                if (objReq.TravelID == 0 || objReq.TravelID == null)
                {
                    objResp.vErrorMsg = "Please Enter TravelID";
                }
                else if (objResp.RequestDate == null)
                {
                    objResp.vErrorMsg = "Please Select Date";
                }
                else if (objResp.oRequestList == null)
                {
                    objResp.vErrorMsg = "Please Enter Request List";
                }
                else
                {

                    if (Con.State == ConnectionState.Broken)
                    { Con.Close(); }
                    if (Con.State == ConnectionState.Closed)
                    { Con.Open(); }

                   // string RequestDate = objReq.RequestDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);

                    cmd = new SqlCommand("USP_TravelRequest", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TravelID", objReq.TravelID);
                    cmd.Parameters.AddWithValue("@EmpId", objReq.EmpId);
                   // cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                    cmd.Parameters.AddWithValue("@RequestDate", objReq.RequestDate);
                    cmd.Parameters.AddWithValue("@BSLTravelDesk", objReq.BSLTravelDesk);
                    cmd.Parameters.AddWithValue("@TravelReport", objReq.TravelReport);
                    cmd.Parameters.AddWithValue("@QueryType", "InsertMaster");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {

                        foreach (clsRequestList info in objReq.oRequestList)
                        {
                            if (!String.IsNullOrWhiteSpace(info.vTravelMode))
                            {
                                var objList = new clsRequestList();
                                SqlCommand cmd2 = new SqlCommand("USP_TravelRequest", Con);
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.AddWithValue("@TravelID", objReq.TravelID);
                                cmd2.Parameters.AddWithValue("@Amount", info.Amount);
                                cmd2.Parameters.AddWithValue("@Qty", info.Qty);
                                cmd2.Parameters.AddWithValue("@DepartDate", info.DepartDate);
                                cmd2.Parameters.AddWithValue("@ReturnDate", info.ReturnDate);
                                cmd2.Parameters.AddWithValue("@vSource", info.vSource);
                                cmd2.Parameters.AddWithValue("@vDestination", info.vDestination);
                                cmd2.Parameters.AddWithValue("@vTravelMode", info.vTravelMode);
                                cmd2.Parameters.AddWithValue("@QueryType", "InsertDetail");
                                int i2 = cmd2.ExecuteNonQuery();
                                if (i2 >= 1)
                                {
                                    objResp.vErrorMsg = "Success";
                                }
                                else
                                {
                                    objResp.vErrorMsg = "Failed to insert  detail";
                                }
                                cmd2.Dispose();
                            }
                        }
                    }
                    else
                    {
                        objResp.vErrorMsg = "Failed Travel Request!";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Insert_Travel_Request", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
            }
            return objResp;
        }
    }
}