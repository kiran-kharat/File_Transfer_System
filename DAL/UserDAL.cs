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
    public class UserDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        SqlConnection connection;

        public bool Save(FormCollection formData)
        {
            int status = 0;

            List<string> ids = (formData["Id"].Split(',')).ToList();
            List<string> salutations = (formData["Salutation"].Split(',')).ToList();
            List<string> userNames = (formData["UserName"].Split(',')).ToList();
            List<string> genders = (formData["Gender"].Split(',')).ToList();
            List<string> emailIds = (formData["EmailId"].Split(',')).ToList();
            try
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    connection = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("sp_SaveUser", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ids[i]));
                    cmd.Parameters.AddWithValue("@salutation", salutations[i]);
                    cmd.Parameters.AddWithValue("@userName", userNames[i]);
                    cmd.Parameters.AddWithValue("@gender", genders[i]);
                    cmd.Parameters.AddWithValue("@emailId", emailIds[i]);
                    connection.Open();
                    status = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public List<UserModel> GetList()
        {
            DataTable dt = new DataTable();
            List<UserModel> users = new List<UserModel>();
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("sp_GetUserList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                connection.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    UserModel user = new UserModel();
                    user.Id = Convert.ToInt32(dr["Id"]);
                    user.Salutation = Convert.ToString(dr["Salutation"]);
                    user.UserName = Convert.ToString(dr["UserName"]);
                    user.EmailId = Convert.ToString(dr["EmailId"]);
                    user.Gender = Convert.ToString(dr["Gender"]);
                    user.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }

    }
}