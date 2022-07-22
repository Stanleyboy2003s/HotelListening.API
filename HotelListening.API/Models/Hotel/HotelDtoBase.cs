namespace HotelListening.API.Models.Hotel
{
    public class HotelDtoBase
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        public double Rating { get; set; }
        [Required]
        public long CountryId { get; set; }
    }
}
