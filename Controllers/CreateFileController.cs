using File_Transfer_System.DAL;
using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace File_Transfer_System.Controllers
{
    public class CreateFileController : Controller
    {
        FileDetailsDAL fileDetailsDAL;
        // GET: CreateFile
        [HttpGet]
        public ActionResult Index()
        {
            return View("CreateFile");
        }

        [HttpPost]
        public JsonResult SaveFileDetails(FormCollection formData)
        {
            fileDetailsDAL = new FileDetailsDAL();
            var result = fileDetailsDAL.SaveFileDetails(formData);
            return Json(result);
        }
    }
}