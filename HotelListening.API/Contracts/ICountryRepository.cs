namespace HotelListening.API.Contracts;

public interface ICountryRepository : IGenericRepository<Country>
{
    //Read  all information about country with specific id 
    Task<Country> GetDetail(long id);
}
