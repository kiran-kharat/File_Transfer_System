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


        public FileInfoModel GetFileInfo()
        {
            connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            FileInfoModel infoModel = new FileInfoModel();
            infoModel.DepartmentList = new List<DeptMaster>();
            infoModel.SubDeptList = new List<SubDeptMaster>();

            try
            {
                cmd = new SqlCommand("sp_GetFileDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand = cmd;
                connection.Open();
                adp.Fill(ds);
                connection.Close();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DeptMaster dMaster = new DeptMaster();
                    dMaster.Id = Convert.ToInt32(dr["Id"].ToString());
                    dMaster.Name = dr["Name"].ToString();
                    infoModel.DepartmentList.Add(dMaster);
                }

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    SubDeptMaster sMaster = new SubDeptMaster();
                    sMaster.Id = Convert.ToInt32(dr["Id"].ToString());
                    sMaster.Name = dr["Name"].ToString();
                    infoModel.SubDeptList.Add(sMaster);
                }

                infoModel.DeptId = 0;
                infoModel.SubDeptId = 0;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return infoModel;
        }

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
                cmd.Parameters.AddWithValue("@DepartmentName", Convert.ToInt32(formData["DeptId"] ?? string.Empty));
                cmd.Parameters.AddWithValue("@SubDeptName", Convert.ToInt32(formData["SubDeptId"] ?? string.Empty));
                cmd.Parameters.AddWithValue("@VigilanceCase", Convert.ToInt32(formData["VigilanceCase"] ?? string.Empty));
                cmd.Parameters.AddWithValue("@Subject", formData["Subject"] ?? string.Empty);
                cmd.Parameters.AddWithValue("@Remarks", formData["Remarks"] ?? string.Empty);
                cmd.Parameters.AddWithValue("@SerialNo", Convert.ToInt32(formData["SerialNo"] ?? string.Empty));
                cmd.Parameters.AddWithValue("@FileType", formData["FileType"] ?? string.Empty);
                cmd.Parameters.AddWithValue("@LinkFile", Convert.ToInt32(formData["LinkFile"] ?? string.Empty));
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