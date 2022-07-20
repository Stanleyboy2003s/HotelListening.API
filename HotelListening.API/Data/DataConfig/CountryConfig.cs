namespace HotelListening.API.Data.DataConfig
{
    public class CountryConfig: IEntityTypeConfiguration<Country>
    {
   
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("T_Country");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.ShortName).IsRequired();

        }
    }
}
