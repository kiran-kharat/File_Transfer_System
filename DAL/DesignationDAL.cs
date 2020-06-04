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
    public class DesignationDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        SqlConnection connection;

        public bool Save(DesignationModel model)
        {
            int status = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_SaveDesignation", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@desc", model.Description);
                cmd.Parameters.AddWithValue("@abbr", model.Abbreviation);
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
        public List<DesignationModel> GetList()
        {
            DataTable dt = new DataTable();
            List<DesignationModel> list = new List<DesignationModel>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_GetDesignationList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                connection.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    DesignationModel item = new DesignationModel();
                    item.Id = Convert.ToInt32(dr["Id"]);
                    item.Abbreviation = Convert.ToString(dr["Abbreviation"]);
                    item.Description = Convert.ToString(dr["Description"]);
                    item.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    list.Add(item);
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