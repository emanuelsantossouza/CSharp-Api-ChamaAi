using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using apiChamaAi.Entities;
using chamaAi.Context;

namespace apiChamaAi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoboyController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public MotoboyController(ApiChamaAiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> PegarTodosAsync()
        {
            return await _context.Motoboys.ToListAsync();
        }


        [HttpPost]
        public IActionResult Create(Motoboy motoboy)
        {
            _context.Add(motoboy);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = motoboy.Id }, motoboy);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var motoboy = _context.Motoboys.Find(id);

            if (motoboy == null)
                return NotFound();

            return Ok(motoboy);
        }
    }
}