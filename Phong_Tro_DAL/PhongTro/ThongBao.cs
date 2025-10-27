namespace Phong_Tro_DAL.Phong_Tro
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

        public int? MaHopDong { get; set; }

        [StringLength(5)]
        public string MaPhong { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public virtual HopDong HopDong { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
