namespace DataServices.EFService
{
    using System.Data.Entity;
    using Data;

    public class CarShopDBContext : DbContext
    {
        public CarShopDBContext()
            : base("name=CarShopDBContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CarBodyType> CarBodyTypes { get; set; }
        public virtual DbSet<CarImage> CarImages { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.StateOrProvinceOrRegion)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.House)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.ZIPCode)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Manufacturers)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.ImageFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarBodyType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CarBodyType>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.CarBodyType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarImage>()
                .Property(e => e.ImageFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Manufacturer)
                .WillCascadeOnDelete(false);
        }
    }
}
