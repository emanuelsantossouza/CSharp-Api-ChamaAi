using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using chamaAi.Context;
using apiChamaAi.Entities;

namespace apiChamaAi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public AdministradorController(ApiChamaAiContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrando")]
        public IActionResult create(Administrador admin)
        {
            if (admin == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _context.Add(admin);
            _context.SaveChanges();
            return Ok(new { Message = "Usuario registrado com sucesso!!!" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> PegarTodosAsync()
        {
            return await _context.Administradores.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(uint id)
        {
            var admin = _context.Administradores.Find(id);

            if (admin == null)
                return NotFound();

            return Ok(admin);
        }
    }
}
