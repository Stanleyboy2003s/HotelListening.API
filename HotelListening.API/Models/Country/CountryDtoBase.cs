namespace HotelListening.API.Models.Country;

public class CountryDtoBase
{
    [Required]
    public string Name { get; set; }
    public string ShortName { get; set; }
}
