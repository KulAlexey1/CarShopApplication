namespace Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
        }

        public int Id { get; set; }

        [Required]
        [StringLength(90)]
        public string Country { get; set; }

        [StringLength(80)]
        public string StateOrProvinceOrRegion { get; set; }

        [Required]
        [StringLength(189)]
        public string City { get; set; }

        [Required]
        [StringLength(70)]
        public string Street { get; set; }

        [Required]
        [StringLength(5)]
        public string House { get; set; }

        public int Building { get; set; }

        [StringLength(10)]
        public string ZIPCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
