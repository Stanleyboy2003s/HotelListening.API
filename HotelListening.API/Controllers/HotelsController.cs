namespace HotelListening.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
    {
        var Hotels = await _hotelRepository.GetAllAsync();
        if (Hotels == null) return NotFound();
        var records = _mapper.Map<IEnumerable<GetHotelDto>>(Hotels);
        return Ok(records);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetHotelDto>> GetHotel(long id)
    {
        var hotel = await _hotelRepository.GetAsync(id);
        if (hotel == null) return NotFound();
        var getHotelDto = _mapper.Map<GetHotelDto>(hotel);
        return Ok(getHotelDto);
    }

    // PUT: api/Hotels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(long id, UpdateHotelDto updateHotelDto)
    {
        if (id != updateHotelDto.Id) return BadRequest("Invalid Record Id");
        var hotel = await _hotelRepository.GetAsync(id);
        if (hotel == null) return NotFound();
        _mapper.Map(updateHotelDto, hotel);
        try
        {
            await _hotelRepository.UpdateAsync(hotel);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    // POST: api/Hotels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
    {
        var Hotels = _hotelRepository.GetAllAsync();
        if (Hotels == null) return Problem("Entity set 'HotelListListingDbContext.Hotels'  is null.");
        Hotel hotel = _mapper.Map<Hotel>(createHotelDto);
        await _hotelRepository.AddAsync(hotel);      
        return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(long id)
    {
        var hotel = await _hotelRepository.GetAsync(id);     
        if (hotel == null) return NotFound();
        await _hotelRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> HotelExists(long id)
    {
        return await _hotelRepository.Exist(id);
    }
}
