namespace Phong_Tro_DAL.PhongTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuTro")]
    public partial class ChuTro
    {
        [Key]
        public int MaChuTro { get; set; }

        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(20)]
        public string Role { get; set; }
    }
}
