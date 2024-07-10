using LINQ.DBContext;
using LINQ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqCRUDController : ControllerBase
    {
        private readonly SMSDBContext _context;
        public LinqCRUDController(SMSDBContext context)
        {
            _context = context;
        }

        [HttpGet("AllShareholderList")]
        public async Task<ActionResult<IEnumerable<Shareholders>>> Get()
        {
            var result = await _context.Shareholders.ToListAsync();

            return result;
        }

        [HttpGet("GetAllParvaluewithID/{id}")]
        public async Task<ActionResult<Parvalues>> GetParvalue(int id)
        {
            var result = await _context.Parvalues.FindAsync(id);
            if (result == null)
            {
                return NotFound($"Parvalue with id ={id} not found!");
            }
            return result;
        }

        [HttpGet("GetAllParvalue")]
        public async Task<ActionResult<List<Parvalues>>> GetParvalue()
        {
            var result = await _context.Parvalues.ToListAsync();
            return result;
        }

        [HttpPost("AddParvalue")]
        public async Task<ActionResult<Parvalues>> Post([FromBody] Parvalues parvalues)
        {
            var result = new Parvalues()
            {
                Amount = parvalues.Amount,
                Name = parvalues.Name,
                Description = parvalues.Description,
                VersionNumber = parvalues.VersionNumber,
            };
            _context.Parvalues.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }

        [HttpPut("UpdateParvalue/{id}")]
        public async Task<ActionResult<Parvalues>> Put(int id, [FromBody] Parvalues parvalues)
        {
            var existingParvalue = await _context.Parvalues.FindAsync(id);

            if (existingParvalue == null)
            {
                //throw new Exception($"Parvalue not found with id={id}");
                return NotFound($"Parvalue not found with id={id}");
            }

            existingParvalue.Amount = parvalues.Amount;
            existingParvalue.Name = parvalues.Name;
            existingParvalue.Description = parvalues.Description;
            existingParvalue.VersionNumber = parvalues.VersionNumber;

            _context.Parvalues.Update(existingParvalue);
            await _context.SaveChangesAsync();

            return existingParvalue;
        }

        [HttpDelete("DeleteParvalue/{id}")]
        public async Task<ActionResult<Parvalues>> Delete(int id, [FromBody] Parvalues parvalues)
        {
            var existingParvalue = await _context.Parvalues.FindAsync(id);

            if (existingParvalue == null)
            {
                return NotFound($"Parvalue not found with id={id}");
            }


            _context.Parvalues.Remove(existingParvalue);
            await _context.SaveChangesAsync();

            return existingParvalue;
        }

    }
}
