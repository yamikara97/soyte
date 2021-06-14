﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
    
        public bool IsAdmin { get; set; }

        public byte[] Assignment { get; set; }


    }
}
