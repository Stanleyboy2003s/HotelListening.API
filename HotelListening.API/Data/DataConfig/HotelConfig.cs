namespace HotelListening.API.Data.DataConfig;

public class HotelConfig : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("T_Hotel");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Address).IsRequired();
        builder.HasOne<Country>(h => h.Country).WithMany(c => c.Hotels);
    }

}
