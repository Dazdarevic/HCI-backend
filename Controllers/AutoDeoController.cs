using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auto_delovi_bekend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoDeoController : ControllerBase
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly DataContext _dataContext;
#pragma warning restore IDE0052 // Remove unread private members

        public AutoDeoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoDeo>>> GetAllAutoDelovi()
        {
            var autoDelovi = await _dataContext.autodelovi.ToListAsync();
            return autoDelovi;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutoDeo>> GetAutoDeo(int id)
        {
            if (_dataContext.autodelovi == null)
            {
                return NotFound();
            }
            var autodeo = await _dataContext.autodelovi.FindAsync(id);
            if (autodeo == null)
            {
                return NotFound();
            }
            return autodeo;
        }

        [HttpPost("add")]
        public async Task<ActionResult<AutoDeo>> PostAutoDeo(AutoDeo autodeo)
        {
            _dataContext.autodelovi.Add(autodeo);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAutoDeo), new { id = autodeo.id }, autodeo);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<AutoDeo>> PutAutoDeo(int id, AutoDeo autodeo)
        {
            if (id != autodeo.id)
            {
                return BadRequest();
            }
            _dataContext.Entry(autodeo).State = EntityState.Modified;
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AutoDeo>> DeleteAutoDeo(int id)
        {
            var autodeo = await _dataContext.autodelovi.FindAsync(id);
            if (autodeo == null)
            {
                return NotFound();
            }
            _dataContext.autodelovi.Remove(autodeo);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
