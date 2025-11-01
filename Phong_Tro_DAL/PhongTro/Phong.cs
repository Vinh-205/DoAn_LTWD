namespace Phong_Tro_DAL.Phong_Tro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            ChiTietTienIches = new HashSet<ChiTietTienIch>();
            HopDongs = new HashSet<HopDong>();
            ThongBaos = new HashSet<ThongBao>();
        }

        [Key]
        [StringLength(5)]
        public string MaPhong { get; set; }

        public int MaChu { get; set; }

        [StringLength(50)]
        public string TenPhong { get; set; }

        [StringLength(50)]
        public string LoaiPhong { get; set; }

        public double? DienTich { get; set; }

        public decimal? GiaThue { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public string TienNghi { get; set; }

        [StringLength(255)]
        public string AnhMinhHoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTienIch> ChiTietTienIches { get; set; }

        public virtual ChuTro ChuNha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao> ThongBaos { get; set; }
    }
}
