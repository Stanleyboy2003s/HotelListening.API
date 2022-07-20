namespace HotelListening.API.Contracts;

public interface IGenericRepository<T> where T : class
{
    //Read the single data for specific id  asynchronously
    Task<T> GetAsync(long? id);
    //Read all the data asynchronously
    Task<List<T>> GetAllAsync();
    //Insert the data(entity) asynchronously   
    Task AddAsync(T entity);
    //Modify the data(entity) for specific id asynchronously
    Task UpdateAsync(T entity);
    //Remove the data for specific id asynchronously
    Task DeleteAsync(long id);
    //Determine whether the data exists or not for specific id asynchronously
    Task<bool> Exist(long id);
}
