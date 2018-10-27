namespace Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class CarImage
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        [Required]
        [StringLength(260)]
        public string ImageFileName { get; set; }

        public virtual Car Car { get; set; }
    }
}
