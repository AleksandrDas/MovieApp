using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class LoginModel
    {
        [StringLength(50)]
        [Required]
        public string Epasts { get; set; }

        [StringLength(100)]
        [Required]
        public string Parole { get; set; }
    }
}