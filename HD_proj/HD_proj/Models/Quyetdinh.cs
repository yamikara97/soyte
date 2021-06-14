using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Quyetdinh : IdentityBase
    {
        [Display(Name = "Số hiệu")]
        public string Sohieu { get; set; }

        [Display(Name = "Người ký duyệt")]
        public string Nguoiky { get; set; }
    
    }
}
