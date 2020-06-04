using File_Transfer_System.DAL;
using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace File_Transfer_System.Controllers
{
    public class DepartmentController : Controller
    {
        DeptDAL deptDAL = new DeptDAL();
        // GET: Department
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            List<DepartmentModel> departments = deptDAL.GetList();
            return View(departments);
        }
        public JsonResult Save(DepartmentModel department)
        {
            department.CreatedBy = 1;
            var result = deptDAL.Save(department);
            return Json(result);
        }
    }
}