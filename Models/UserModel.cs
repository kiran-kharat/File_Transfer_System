using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace File_Transfer_System.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Salutation { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}