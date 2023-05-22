namespace Websitebangiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Websitebangiay.Areas.Admin.Controllers;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        [Key]
        public int Masp { get; set; }

        [StringLength(50)]
        public string Tensp { get; set; }

        public decimal? Giatien { get; set; }

        public int? Soluong { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public bool? Sanphammoi { get; set; }

        [StringLength(50)]
        public string Anhbia { get; set; }

        public int? Mahang { get; set; }

        public int? macl { get; set; }

        public virtual Chatlieu Chatlieu { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }       
        public virtual Hangsanxuat Hangsanxuat { get; set; }
    }
}
