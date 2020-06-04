using File_Transfer_System.DAL;
using File_Transfer_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            fileDetailsDAL = new FileDetailsDAL();
            FileInfoModel fileInfoModel = new FileInfoModel();
            fileInfoModel = fileDetailsDAL.GetFileInfo();
            return View("CreateFile", fileInfoModel);
        }

        [HttpPost]
        public JsonResult SaveFileDetails(FormCollection formData )
        {
            fileDetailsDAL = new FileDetailsDAL();
            FileInfoModel fileinfo = new FileInfoModel();
           
            var result = fileDetailsDAL.SaveFileDetails(formData);
            var files = Request.Files.GetMultiple("fileControl").ToList();
            foreach (HttpPostedFileBase file in files)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    //ViewBag.UploadStatus += file.FileName + " files uploaded successfully.";
                    ViewBag.UploadStatus += string.Format("<b>{0}</b> uploaded.<br />", InputFileName);
                }
               
            }

            var output = fileDetailsDAL.SaveAttachmentDetails(formData,files);
            return Json(output);
        }
    }
}