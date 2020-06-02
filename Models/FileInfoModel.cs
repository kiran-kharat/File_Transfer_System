using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace File_Transfer_System.Models
{
    public class FileInfoModel
    {
        public int DeptId { get; set; }
        public int SubDeptId { get; set; }
        [Required]
        public int FileNo { get; set; }
        public List<DeptMaster> DepartmentList { get; set; }
        public List<SubDeptMaster> SubDeptList { get; set; }
        public int VigilanceCase { get; set; }
        public string Subject { get; set; }
        public string Remarks { get; set; }
        public int SerialNo { get; set; }
        public string FileType { get; set; }
        public int LinkFile { get; set; }
        public HttpPostedFileBase FileAttachment { get; set; }
    }

    public class DeptMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SubDeptMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}