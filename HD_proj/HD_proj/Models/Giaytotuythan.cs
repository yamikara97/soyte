﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Giaytotuythan
    {
        [Key]
        [Display(Name = "Số Cmnd/Cccd")]
        [MinLength(9)]
        public string IdCmnd { get; set; }

        [Display(Name = "Họ tên")]
        public string Hoten { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Ngaysinh { get; set; }

        [Display(Name = "Ngày cấp")]
        [DataType(DataType.Date)]
        public DateTime Ngaycap { get; set; }

        [Display(Name = "Nơi cấp")]
        public string Noicap { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Sodienthoai {get;set;}

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display (Name = "Địa chỉ thường trú")]
        public string Diachi { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime DateUpdate { get; set; } = DateTime.Now;

        public string UpdateBy { get; set; }
    }
}
