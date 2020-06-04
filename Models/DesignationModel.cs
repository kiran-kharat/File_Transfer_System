using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace File_Transfer_System.Models
{
    public class DesignationModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}