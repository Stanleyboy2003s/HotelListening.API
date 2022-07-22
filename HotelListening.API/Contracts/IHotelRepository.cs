namespace HotelListening.API.Contracts;

public interface IHotelRepository:IGenericRepository<Hotel> 
{
    Task<Hotel> GetDetail(long id);
}
