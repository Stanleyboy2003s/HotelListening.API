namespace HotelListening.API.Models.Country;

public class CountryDto : CountryDtoBase
{
    public long Id { get; set; }
    public List<HotelDto> Hotels { get; set; }
}
