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
    public class FileDetailsDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        SqlConnection connection;


        public bool SaveFileDetails(FormCollection formData)
        {
            int status = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_SaveFileDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileNo", Convert.ToInt32(formData["FileNo"]));
                cmd.Parameters.AddWithValue("@VigilanceCase", Convert.ToInt32(formData["VigilanceCase"] ?? string.Empty));
                cmd.Parameters.AddWithValue("@Subject", formData["Subject"] ?? string.Empty);
                cmd.Parameters.AddWithValue("@Remarks", formData["Remarks"] ?? string.Empty);
                cmd.Parameters.AddWithValue("@SerialNo", Convert.ToInt32(formData["SerialNo"] ?? string.Empty));
                cmd.Parameters.AddWithValue("@FileType", formData["FileType"] ?? string.Empty);
                connection.Open();
                status = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}