using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Kenguru_four_
{
    public class RegModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

    }
}