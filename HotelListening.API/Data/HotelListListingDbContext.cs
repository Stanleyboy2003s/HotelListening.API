namespace HotelListening.API.Data;

public class HotelListListingDbContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }


    public HotelListListingDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Jamaica",
                ShortName = "JM"
            },
             new Country
             {
                 Id = 2,
                 Name = "Jamaica",
                 ShortName = "JM"
             },
              new Country
              {
                  Id = 3,
                  Name = "Cayman Island",
                  ShortName = "CI"
              },
              new Country
              {
                  Id = 4,
                  Name = "Taiwan",
                  ShortName = "TW"
              }
            );

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Sandals Resort and Spa",
                Address = "Negril",
                CountryId = 1,
                Rating = 4.5
            },
              new Hotel
              {
                  Id = 2,
                  Name = "Comfort Suites",
                  Address = "George Town",
                  CountryId = 3,
                  Rating = 4.3
              },
               new Hotel
               {
                   Id = 3,
                   Name = "Grand Palldium",
                   Address = "Nassua",
                   CountryId = 2,
                   Rating = 4
               },
                  new Hotel
                  {
                      Id = 4,
                      Name = "Splendor Hotel-Taichung",
                      Address = "Taichung",
                      CountryId = 4,
                      Rating = 4.2
                  }
            );
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

}
