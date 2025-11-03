namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TienIch")]
    public partial class TienIch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TienIch()
        {
            ChiTietTienIches = new HashSet<ChiTietTienIch>();
        }

        [Key]
        public int MaTienIch { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTienIch { get; set; }

        public decimal? DonGia { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTienIch> ChiTietTienIches { get; set; }
    }
}
