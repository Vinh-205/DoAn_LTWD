namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongBao")]
    public partial class ThongBao
    {
        [Key]
        public int MaTB { get; set; }

        public int MaTK_Gui { get; set; }

        public int? MaTK_Nhan { get; set; }

        [Required]
        [StringLength(500)]
        public string NoiDung { get; set; }

        public bool? DaDoc { get; set; }

        public DateTime? NgayGui { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual TaiKhoan TaiKhoan1 { get; set; }
    }
}
