
namespace HotelListening.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly HotelListListingDbContext _context;

    public CountriesController(HotelListListingDbContext context)
    {
        _context = context;
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
    {
      if (_context.Countries == null)
      {
          return NotFound();
      }
        return Ok(await _context.Countries.ToListAsync());
    }

    // GET: api/Countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Country>> GetCountry(long id)
    {
      if (_context.Countries == null)
      {
          return NotFound();
      }
        var country = await _context.Countries.FindAsync(id);

        if (country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }

    // PUT: api/Countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCountry(long id, Country country)
    {
        if (id != country.Id)
        {
            return BadRequest();
        }

        _context.Entry(country).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(Country country)
    {
      if (_context.Countries == null)
      {
          return Problem("Entity set 'HotelListListingDbContext.Countries'  is null.");
      }
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/Countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(long id)
    {
        if (_context.Countries == null)
        {
            return NotFound();
        }
        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CountryExists(long id)
    {
        return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
