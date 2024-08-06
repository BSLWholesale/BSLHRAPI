using BSLHRAPI.Models;
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
    public class DALEmployee
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["BSL"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        int mxTravelID;


        public clsEmployee Fn_Add_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.nEmpId != null || objReq.nEmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpName))
                {
                    objResp.vErrorMsg = "Please Employee Name";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpEmailId))
                {
                    objResp.vErrorMsg = "Please EmailId";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpMobile))
                {
                    objResp.vErrorMsg = "Please Mobile";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpGrade))
                {
                    objResp.vErrorMsg = "Please Select Grade";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpLocation))
                {
                    objResp.vErrorMsg = "Please Select Location";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpPassword))
                {
                    objResp.vErrorMsg = "Please Password";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string encriptPassword = Generic.EncryptText(objReq.vEmpPassword);
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.nEmpId);
                    cmd.Parameters.AddWithValue("@EmpName", objReq.vEmpName);
                    cmd.Parameters.AddWithValue("@EmpEmailId", objReq.vEmpEmailId);
                    cmd.Parameters.AddWithValue("@EmpMobile", objReq.vEmpMobile);
                    cmd.Parameters.AddWithValue("@EmpGrade", objReq.vEmpGrade);
                    cmd.Parameters.AddWithValue("@EmpLocation", objReq.vEmpLocation);
                    cmd.Parameters.AddWithValue("@BSLTravelDesk", objReq.nBSLTravelDesk);
                    cmd.Parameters.AddWithValue("@EmpPassword", encriptPassword);
                    cmd.Parameters.AddWithValue("@DOB", objReq.DOB);
                    cmd.Parameters.AddWithValue("@QueryType", "Insert");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Add_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
                cmd.Dispose();
            }
            return objResp;
        }

        public clsEmployee Fn_Update_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.nEmpId != null || objReq.nEmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpName))
                {
                    objResp.vErrorMsg = "Please Employee Name";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpEmailId))
                {
                    objResp.vErrorMsg = "Please EmailId";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpMobile))
                {
                    objResp.vErrorMsg = "Please Mobile";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpGrade))
                {
                    objResp.vErrorMsg = "Please Select Grade";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpLocation))
                {
                    objResp.vErrorMsg = "Please Select Location";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpPassword))
                {
                    objResp.vErrorMsg = "Please Password";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string encriptPassword = Generic.EncryptText(objReq.vEmpPassword);
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.nEmpId);
                    cmd.Parameters.AddWithValue("@EmpName", objReq.vEmpName);
                    cmd.Parameters.AddWithValue("@EmpEmailId", objReq.vEmpEmailId);
                    cmd.Parameters.AddWithValue("@EmpMobile", objReq.vEmpMobile);
                    cmd.Parameters.AddWithValue("@EmpGrade", objReq.vEmpGrade);
                    cmd.Parameters.AddWithValue("@EmpLocation", objReq.vEmpLocation);
                    cmd.Parameters.AddWithValue("@BSLTravelDesk", objReq.nBSLTravelDesk);
                    cmd.Parameters.AddWithValue("@EmpPassword", encriptPassword);
                    cmd.Parameters.AddWithValue("@DOB", objReq.DOB);
                    cmd.Parameters.AddWithValue("@QueryType", "Update");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Update_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
            }

            return objResp;
        }

        public clsEmployee Fn_Delete_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.nEmpId != null || objReq.nEmpId != 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.nEmpId);
                    cmd.Parameters.AddWithValue("@QueryType", "Delete");
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Delete_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
            }

            return objResp;
        }

        public clsEmployee Fn_LogIn_Employee(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (objReq.nEmpId == null || objReq.nEmpId == 0)
                {
                    objResp.vErrorMsg = "Please Enter User Id.";
                }
                else if (String.IsNullOrWhiteSpace(objReq.vEmpPassword))
                {
                    objResp.vErrorMsg = "Please Password";
                }
                else
                {
                    if (Con.State == ConnectionState.Broken)
                    {
                        Con.Close();
                    }
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string encriptPassword = Generic.EncryptText(objReq.vEmpPassword);
                    cmd = new SqlCommand("USP_Employee", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", objReq.nEmpId);
                    cmd.Parameters.AddWithValue("@EmpPassword", encriptPassword);
                    cmd.Parameters.AddWithValue("@QueryType", "LogIn");
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        string decryptTextPassword = Generic.DecryptText(Convert.ToString(dr["EmpPassword"]));
                        objResp.nEmpId = Convert.ToInt32(dr["EmpId"]);
                        objResp.vEmpName = Convert.ToString(dr["EmpName"]);
                        objResp.vEmpEmailId = Convert.ToString(dr["EmpEmailId"]);
                        objResp.vEmpMobile = Convert.ToString(dr["EmpMobile"]);
                        objResp.vEmpLocation = Convert.ToString(dr["EmpLocation"]);
                        objResp.vEmpGrade = Convert.ToString(dr["EmpGrade"]);
                        objResp.vEmpPassword = decryptTextPassword;
                        objResp.vErrorMsg = "Success";
                    }
                    else
                    {
                        objResp.vErrorMsg = "Faild";
                    }
                    dr.Close();
                    cmd.Dispose();
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_LogIn_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                Con.Close();
            }

            return objResp;
        }

        public List<clsEmployee> Fn_Get_All_Employee(clsEmployee objReq)
        {
            var objRespList = new List<clsEmployee>();
            var objResp = new clsEmployee();
            try
            {
                if (Con.State == ConnectionState.Broken)
                {
                    Con.Close();
                }
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                cmd = new SqlCommand("USP_Employee", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QueryType", "SelectAll");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        objResp = new clsEmployee();

                        objResp.nEmpId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmpId"]);
                        objResp.vEmpName = Convert.ToString(ds.Tables[0].Rows[i]["EmpName"]);
                        objResp.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"]).ToUniversalTime(); ;
                        objResp.vEmpEmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmpEmailId"]);
                        objResp.vEmpMobile = Convert.ToString(ds.Tables[0].Rows[i]["EmpMobile"]);
                        objResp.vEmpLocation = Convert.ToString(ds.Tables[0].Rows[i]["EmpLocation"]);
                        objResp.vEmpGrade = Convert.ToString(ds.Tables[0].Rows[i]["EmpGrade"]);
                        string decryptTextPassword = Generic.DecryptText(Convert.ToString(ds.Tables[0].Rows[i]["EmpPassword"]));
                        objResp.vEmpPassword = decryptTextPassword;

                        objResp.vErrorMsg = "Success";
                        objRespList.Add(objResp);
                        i++;
                    }
                }
                else
                {
                    objResp.vErrorMsg = "No record found.";
                    objRespList.Add(objResp);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Get_All_Employee", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
                objRespList.Add(objResp);
            }
            finally
            {
                cmd.Dispose();
                Con.Close();
            }

            return objRespList;
        }

        public clsEmployee Fn_Get_EmployeeByID(clsEmployee objReq)
        {
            var objResp = new clsEmployee();
            try
            {
                if (Con.State == ConnectionState.Broken)
                {
                    Con.Close();
                }
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                cmd = new SqlCommand("USP_Employee", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", objReq.nEmpId);
                cmd.Parameters.AddWithValue("@QueryType", "SelectByID");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {

                        objResp.nEmpId = Convert.ToInt32(ds.Tables[0].Rows[i]["EmpId"]);
                        objResp.vEmpName = Convert.ToString(ds.Tables[0].Rows[i]["EmpName"]);
                        objResp.vEmpEmailId = Convert.ToString(ds.Tables[0].Rows[i]["EmpEmailId"]);
                        objResp.vEmpMobile = Convert.ToString(ds.Tables[0].Rows[i]["EmpMobile"]);
                        objResp.vEmpGrade = Convert.ToString(ds.Tables[0].Rows[i]["EmpGrade"]);
                        objResp.vEmpLocation = Convert.ToString(ds.Tables[0].Rows[i]["EmpLocation"]);
                        // objResp.nBSLTravelDesk = Convert.ToInt32(ds.Tables[0].Rows[i]["BSLTravelDesk"]);

                        string decryptTextPassword = Generic.DecryptText(Convert.ToString(ds.Tables[0].Rows[i]["EmpPassword"]));
                        objResp.vEmpPassword = decryptTextPassword;
                        objResp.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"]);
                        objResp.vErrorMsg = "Success";
                    }
                }
                else
                {
                    objResp.vErrorMsg = "No record found.";
                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Get_EmployeeByID", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                objResp.vErrorMsg = exp.Message.ToString();
            }
            finally
            {
                cmd.Dispose();
                Con.Close();
            }

            return objResp;
        }

        public List<clsResponseDropdown> Fn_Fill_DropdownList(clsRequestDropdown objReq)
        {
            var _productmodel = new List<clsResponseDropdown>();
            try
            {
                string strSql = "";
                if (Con.State == ConnectionState.Broken)
                { Con.Close(); }
                if (Con.State == ConnectionState.Closed)
                { Con.Open(); }

                if (String.IsNullOrWhiteSpace(objReq.vValueField))
                {
                    strSql = "select Distinct " + objReq.vFieldName + " from " + objReq.vTBLName + " where 1=1";
                }
                else
                {
                    strSql = "select Distinct " + objReq.vValueField + ", " + objReq.vFieldName + " from " + objReq.vTBLName + " where 1=1";
                }


                if (!String.IsNullOrWhiteSpace(objReq.vCriteria))
                {
                    strSql = strSql + objReq.vCriteria;
                }
                strSql = strSql + " order by " + objReq.vFieldName + "";
                SqlDataAdapter da = new SqlDataAdapter(strSql, Con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                int i = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    while (ds.Tables[0].Rows.Count > i)
                    {
                        var Material_item = new clsResponseDropdown();

                        if (String.IsNullOrWhiteSpace(objReq.vValueField))
                        {
                            Material_item.vFieldName = Convert.ToString(ds.Tables[0].Rows[i][0]);
                        }
                        else
                        {
                            Material_item.vValueField = Convert.ToString(ds.Tables[0].Rows[i][0]);
                            Material_item.vFieldName = Convert.ToString(ds.Tables[0].Rows[i][1]);
                        }

                        Material_item.vErrorMsg = "Success";
                        _productmodel.Add(Material_item);
                        i++;
                    }
                }
                else
                {

                }
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Fill_DropdownList", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
                var Material_item = new clsResponseDropdown();
                Material_item.vErrorMsg = exp.Message.ToString();
                _productmodel.Add(Material_item);
            }
            finally
            {
                Con.Close();
            }
            return _productmodel;

        }
       

        public clsTravelRequest Fn_Get_MX_TravelID(clsTravelRequest objReq)
        {
            var objResp = new clsTravelRequest();
            try
            {

                if (Con.State == ConnectionState.Broken) { Con.Close(); }
                if (Con.State == ConnectionState.Closed) { Con.Open(); }
                // string strSql = "Select Concat(format(getdate(),'ddMMyyyy'), FORMAT(ISNULL(max(cast(substring(MaterialCode,13,6) as int))+1,1),'000000')) from " + objReq.vTBLName + " where Convert(date,CreatedOn)=Convert(date,getdate())";
                string strSql = "Select Concat(format(getdate(),'ddMMyyyy'), FORMAT(ISNULL(max(TravelID)+1,1),'000000')) from TravelRequest where Convert(date,RequestDate)=Convert(date,getdate())";
                SqlCommand cmd = new SqlCommand(strSql, Con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    objResp.TravelID = Convert.ToInt64(dr[0].ToString());
                    objResp.vErrorMsg = "Success";
                }
                else
                {
                    string dt = DateTime.Now.ToString("ddMMyyyy");
                    objResp.TravelID = Convert.ToInt64(dt + "000001");
                    objResp.vErrorMsg = "Success";
                }
                dr.Close();
                cmd.Dispose();
                Con.Close();
            }
            catch (Exception exp)
            {
                Logger.WriteLog("Function Name : Fn_Get_MX_TravelID", " " + "Error Msg : " + exp.Message.ToString(), new StackTrace(exp, true));
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