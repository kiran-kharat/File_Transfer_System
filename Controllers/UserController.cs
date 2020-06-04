using File_Transfer_System.DAL;
using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace File_Transfer_System.Controllers
{
    public class UserController : Controller
    {
        UserDAL userDAL = new UserDAL();
        // GET: Department
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            List<UserModel> users = userDAL.GetList();
            return View(users);
        }
        public JsonResult Save(FormCollection form)
        {
            var result = userDAL.Save(form);
            return Json(result);
        }
    }
}