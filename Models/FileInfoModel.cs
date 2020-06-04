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
        [Required]
        public int FileNo { get; set; }
        public int VigilanceCase { get; set; }
        public string Subject { get; set; }
        public string Remarks { get; set; }
        public int SerialNo { get; set; }
        public string FileType { get; set; }
        //public HttpPostedFileBase FileAttachment { get; set; }

        [Display(Name = "Attachment")]
        public HttpPostedFileBase[] AttachFiles { get; set; }
        //public List<HttpPostedFileBase> files { get; set; }
    }
}