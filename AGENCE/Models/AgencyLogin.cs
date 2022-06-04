using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace AGENCE.Models
{
    public class AgencyLogin
    {
        [Required]
        [Display(Name = "USER")]
        public string user { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "PASSWORD")]
        public string password { get; set; }
    }
}