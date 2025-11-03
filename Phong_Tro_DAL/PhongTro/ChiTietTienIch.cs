namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietTienIch")]
    public partial class ChiTietTienIch
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaPhong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTienIch { get; set; }

        public decimal? Gia { get; set; }

        public virtual Phong Phong { get; set; }

        public virtual TienIch TienIch { get; set; }
    }
}
