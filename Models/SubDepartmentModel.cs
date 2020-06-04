using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace File_Transfer_System.Models
{
    public class SubDepartmentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public string SubDeptType { get; set; }
        [Required]
        public string SubDeptName { get; set; }
        public string DeptName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
    public class SubDepartmentListModel
    {
        public List<SubDepartmentModel> SubDeptList { get; set; }
        public List<DepartmentModel> DeptList { get; set; }
    }
}