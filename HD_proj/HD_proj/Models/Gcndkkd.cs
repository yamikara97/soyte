using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HD_proj.Models
{
    public class Gcndkkd : IdentityBase
    {
        public enum Trangthaivb
        {
            ACTIVE = 0,
            DEACTIVE = 1
        }

        [Display (Name = "Số")]
        public string So { get; set; }

        [Display (Name = "Loại")]
        public string Loai { get; set; }

        [Display (Name = "Tên cơ sở")]
        public string Tencoso { get; set; }

        [Display (Name = "Trụ sở chính")]
        public string Truso { get; set; }

        [Display (Name = "Địa chỉ kinh doanh")]
        public string Diachikinhdoanh { get; set; }

        [Display (Name = "Loại hình")]
        public string Loaihinh { get; set; }
       
        [Display (Name = "Phạm vi KD")]
        public string Phamvi { get; set; }

        [Display(Name = "Ngày cấp")]
        [DataType(DataType.Date)]
        public DateTime Ngaycap { get; set; }

        [Display (Name = "Ngày hiệu lực")]
        [DataType (DataType.Date)]
        public DateTime Ngayhieuluc { get; set; }

        [Display(Name = "Trạng thái")]
        public Trangthaivb Trangthai { get; set; }

        public string Cmnd { get; set; }

        public Guid Quyetdinh { get; set; }


        [Display (Name = "Người ký duyệt")]
        public string Nguoikyduyet { get; set; }
    }
}
