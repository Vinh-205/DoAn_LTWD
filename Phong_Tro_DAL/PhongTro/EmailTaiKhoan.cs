namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailTaiKhoan")]
    public partial class EmailTaiKhoan
    {
        public int ID { get; set; }

        public int MaTK { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(6)]
        public string MaXacNhan { get; set; }

        public DateTime? ThoiGianHetHan { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
