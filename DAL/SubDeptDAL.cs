using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using File_Transfer_System.Models;

namespace File_Transfer_System.DAL
{
    public class SubDeptDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        SqlConnection connection;

        public bool Save(SubDepartmentModel model)
        {
            int status = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_SaveSubDepartment", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@deptId", model.DeptId);
                cmd.Parameters.AddWithValue("@name", model.SubDeptName);
                cmd.Parameters.AddWithValue("@type", model.SubDeptType);
                cmd.Parameters.AddWithValue("@userId", model.CreatedBy);
                connection.Open();
                status = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public List<SubDepartmentModel> GetList()
        {
            DataTable dt = new DataTable();
            List<SubDepartmentModel> list = new List<SubDepartmentModel>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_GetSubDepartmentList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                connection.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    SubDepartmentModel model = new SubDepartmentModel();
                    model.Id = Convert.ToInt32(dr["Id"]);
                    model.DeptId = Convert.ToInt32(dr["DeptId"]);
                    model.DeptName = Convert.ToString(dr["Name"]);
                    model.SubDeptName = Convert.ToString(dr["SubDeptName"]);
                    model.SubDeptType = Convert.ToString(dr["SubDeptType"]);
                    model.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    list.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

    }
}