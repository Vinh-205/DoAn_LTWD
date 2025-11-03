namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuePhong")]
    public partial class ThuePhong
    {
        [Key]
        public int MaHopDong { get; set; }

        public int MaTK { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        public virtual Phong Phong { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
