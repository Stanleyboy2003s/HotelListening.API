namespace HotelListening.API.Configurations;

public class MapperConfig:Profile
{
    public MapperConfig()
    {
        #region Country Map
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();
        #endregion

        #region Hotel Map
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        CreateMap<Hotel, GetHotelDto>().ReverseMap();
        #endregion
    }
}
