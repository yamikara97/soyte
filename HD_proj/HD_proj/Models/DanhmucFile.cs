using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class DanhmucFile : IdentityBase
    {
        [Display (Name = "Tên file")]
        public string Ten { get; set; }

        [Display (Name = "Loại file")]
        public string TenLoai { get; set; }

        public string DuongDan { get; set; }

        public string PhanMoRong { get; set; }

        public string LoaiDulieu { get; set; }

        public Guid FatherId { get; set; }

    }
}
