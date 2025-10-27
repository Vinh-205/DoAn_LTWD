namespace Phong_Tro_DAL.Phong_Tro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [StringLength(8)]
        public string MaHD { get; set; }

        public int MaHopDong { get; set; }

        public int Thang { get; set; }

        public int Nam { get; set; }

        public int? SoDienCu { get; set; }

        public int? SoDienMoi { get; set; }

        public int? SoNuocCu { get; set; }

        public int? SoNuocMoi { get; set; }

        public decimal? TienDien { get; set; }

        public decimal? TienNuoc { get; set; }

        public decimal? TienDichVu { get; set; }

        public decimal? GiaPhong { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? NgayLap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual HopDong HopDong { get; set; }
    }
}
