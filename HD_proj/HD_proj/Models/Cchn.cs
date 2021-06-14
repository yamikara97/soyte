using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Cchn : IdentityBase
    {
        public enum Trangthaivb
        {
            ACTIVE = 0,
            DEACTIVE = 1
        }

        [Display(Name = "Số")]
        public string So { get; set; }

        [Display(Name = "Ngày Cấp")]
        [DataType(DataType.Date)]
        public DateTime Ngaycap { get; set; }

        [Display(Name = "Loại")]
        public string Loai { get; set; }

        [Display(Name = "Trình độ")]
        public int Trinhdo { get; set; }

        [Display(Name = "Phạm vi Hợp đồng")]
        public string Phamvi { get; set; }

        [Display(Name = "Hình thức cấp")]
        public string Hinhthuccap { get; set; }

        [Display(Name = "Ngày hiệu lực")]
        [DataType(DataType.Date)]
        public string Ngayhieuluc { get; set; }

        [Display (Name = "Trạng thái")]
        public Trangthaivb Trangthai { get;set; }

        public string Cmnd { get; set; }

        public Guid Quyetdinh { get; set; }

        [Display(Name = "Người ký duyệt")]
        public string Nguoikyduyet { get; set; }

    }
}
