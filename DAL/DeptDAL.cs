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
    public class DeptDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        SqlConnection connection;

        public bool Save(DepartmentModel department)
        {
            int status = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_SaveDepartment", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", department.Id);
                cmd.Parameters.AddWithValue("@code", department.Code);
                cmd.Parameters.AddWithValue("@name", department.Name);
                cmd.Parameters.AddWithValue("@userId", department.CreatedBy);
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
        public List<DepartmentModel> GetList()
        {
            DataTable dt = new DataTable();
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_GetDepartmentList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                connection.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    DepartmentModel dept = new DepartmentModel();
                    dept.Id = Convert.ToInt32(dr["Id"]);
                    dept.Code = Convert.ToString(dr["Code"]);
                    dept.Name = Convert.ToString(dr["Name"]);
                    dept.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    departments.Add(dept);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return departments;
        }

    }
}