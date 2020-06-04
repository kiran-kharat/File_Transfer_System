using File_Transfer_System.DAL;
using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace File_Transfer_System.Controllers
{
    public class SubDepartmentController : Controller
    {
        
        SubDeptDAL subDeptDAL = new SubDeptDAL();
        // GET: Department
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            SubDepartmentListModel listModel = new SubDepartmentListModel();
            DeptDAL deptDAL = new DeptDAL();
            listModel.SubDeptList = subDeptDAL.GetList();
            listModel.DeptList = deptDAL.GetList();
            return View(listModel);
        }
        public JsonResult Save(SubDepartmentModel subDept)
        {
            subDept.CreatedBy = 1;
            var result = subDeptDAL.Save(subDept);
            return Json(result);
        }
    }
}