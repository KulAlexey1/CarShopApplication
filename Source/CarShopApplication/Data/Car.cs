namespace Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
        }

        public int Id { get; set; }

        public int? BrandId { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int? CarBodyTypeId { get; set; }

        public int NumberOfDoors { get; set; }

        public int? ManufacturerId { get; set; }

        public short CarReleaseYear { get; set; }

        public int Price { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual CarBodyType CarBodyType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarImage> CarImages { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
