namespace HotelListening.API.Repository;

public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
{
    private HotelListListingDbContext _context;
    public HotelRepository(HotelListListingDbContext context):base(context)
    {
        _context = context;
    }

    public async Task<Hotel> GetDetail(long id)
    {
        return await _context.Hotels.Include(q => q.Country).FirstOrDefaultAsync(q => q.Id == id);
    }
}
