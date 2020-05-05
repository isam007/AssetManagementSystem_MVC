using CPRG214.ATS.Domain;
using Microsoft.EntityFrameworkCore;

namespace CPRG214.ATS.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext() : base() { }

        public AssetsContext(DbContextOptions<AssetsContext> options) : base(options) { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Change the connection string here for your home computer/lab computer
        //    optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;
        //                                  Database=AssetConnection;
        //                                  Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Dell" },
                new Manufacturer { Id = 2, Name = "HP" },
                new Manufacturer { Id = 3, Name = "Acer " },
                new Manufacturer { Id = 4, Name = "LG " },
                new Manufacturer { Id = 5, Name = "Avaya " },
                new Manufacturer { Id = 6, Name = "Polycom " },
                new Manufacturer { Id = 7, Name = "Cisco  " }
                );

            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "ATS11000",
                    Model = "Inspiron X15",
                    Description = "Black 2018 15' Laptop",
                    SerialNumber = "SN11000",
                    ManufacturerId = 1,
                    AssetTypeId = 1
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "ATS22000",
                    Model = "15LCD",
                    Description = "Black 2018 15' Monitor",
                    SerialNumber = "SN22000",
                    ManufacturerId = 2,
                    AssetTypeId = 2
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "ATS33000",
                    Model = "Slimware",
                    Description = "Black 2019 Slim phone",
                    SerialNumber = "S323000",
                    ManufacturerId = 4,
                    AssetTypeId = 3
                }
            );
        }
    }
}
