using File_Transfer_System.DAL;
using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace File_Transfer_System.Controllers
{
    public class DesignationController : Controller
    {
        DesignationDAL designationDAL = new DesignationDAL();
        // GET: Department
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            List<DesignationModel> list = designationDAL.GetList();
            return View(list);
        }
        public JsonResult Save(DesignationModel designation)
        {
            designation.CreatedBy = 1;
            var result = designationDAL.Save(designation);
            return Json(result);
        }
    }
}