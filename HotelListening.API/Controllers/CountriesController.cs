
namespace HotelListening.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    //Use CountryRepository to replace _context for refactoring  CountriesController
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountriesController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
    {
        var countries = await _countryRepository.GetAllAsync();
        if (countries == null) return NotFound();
        #region//自定義轉換
        //var countriesMapper = new List<GetCountryDto>();
        //foreach (var country in countries)
        //{
        //    countriesMapper.Add(new GetCountryDto()
        //    {
        //        Id = country.Id,
        //        Name = country.Name,
        //        ShortName = country.ShortName,
        //    });
        //}
        //return Ok(countriesMapper);
        #endregion
        var records = _mapper.Map<List<GetCountryDto>>(countries);
        return Ok(countries);
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> GetCountry(long id)
    {     
        var country = await _countryRepository.GetDetail(id);
        if (country == null) return NotFound();
        CountryDto countryDto = _mapper.Map<CountryDto>(country);
        return Ok(countryDto);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(long id, UpdateCountryDto updateCountryDto)
    {
        if (id != updateCountryDto.Id) return BadRequest("Invalid Record Id");      
        var country = await _countryRepository.GetAsync(id);
        if (country == null) return NotFound();       
        _mapper.Map(updateCountryDto, country);
        try
        {
            await _countryRepository.UpdateAsync(country);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CountryExists(id)) return NotFound();        
            else throw;          
        }
        return NoContent();
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
    {
        var Countries = await _countryRepository.GetAllAsync();
        if (Countries == null) return Problem("Entity set 'HotelListListingDbContext.Countries'  is null.");
        #region 自定義country與createCountryDto的轉換
        //Country country = new Country()
        //{
        //    Name = createCountryDto.Name,
        //    ShortName = createCountryDto.ShortName,
        //};
        #endregion
        Country country = _mapper.Map<Country>(createCountryDto);
        await _countryRepository.AddAsync(country);
        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(long id)
    {
        var country = _countryRepository.GetAsync(id);
        if (country == null) return NotFound();      
        await _countryRepository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<bool> CountryExists(long id)
    {   
        return await _countryRepository.Exist(id);
    }
}
