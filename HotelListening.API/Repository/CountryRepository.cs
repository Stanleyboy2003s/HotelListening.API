namespace HotelListening.API.Repository;

public class CountryRepository: GenericRepository<Country>, ICountryRepository
{
    private readonly HotelListListingDbContext _context;
    public CountryRepository(HotelListListingDbContext context):base(context)
    {
        _context = context;
    }
    public async Task<Country> GetDetail(long id)
    {
        return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id);
    }
}
