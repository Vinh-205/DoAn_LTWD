namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKeDoanhThu")]
    public partial class ThongKeDoanhThu
    {
        [Key]
        public int MaThongKe { get; set; }

        public int Thang { get; set; }

        public int Nam { get; set; }

        public int? TongSoHoaDon { get; set; }

        public decimal? TongDoanhThu { get; set; }

        public decimal? DoanhThuPhong { get; set; }

        public decimal? DoanhThuDichVu { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}
