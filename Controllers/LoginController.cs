using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace File_Transfer_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginCred)
        {
            if (loginCred.UserName == "admin" && loginCred.Password == "admin")
                return RedirectToAction("Index","CreateFile");
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Logout()
        {
            Session["UserData"] = null;
            return RedirectToAction("Index");
        }

    }
}