using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using chamaAi.Context;
using apiChamaAi.Entities;

namespace apiChamaAi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SedeController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public SedeController(ApiChamaAiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> PegarTodaSedeAsync()
        {
            return await _context.Sedes.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult PegarSedePorId(uint id)
        {
            var sede = _context.Sedes.Find(id);

            if (sede == null)
                return NotFound();

            return Ok(sede);
        }

        [HttpGet("PegarPorNomeSede")]
        public IActionResult PegarPorNomeSede(string Nome)
        {
            var Sedes = _context.Sedes.Where(x => x.Nome.Contains(Nome));

            if (Sedes == null)
                return NotFound();

            return Ok(Sedes);
        }

        [HttpPost]
        public IActionResult Create(Sede sede)
        {
            _context.Add(sede);
            _context.SaveChanges();
            return CreatedAtAction(nameof(PegarPorNomeSede), new { id = sede.Id }, sede);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(uint id, Sede sede)
        {
            var sedeBanco = _context.Sedes.Find(id);

            if (sedeBanco == null)
                return NotFound();

            sedeBanco.Nome = sede.Nome;
            sedeBanco.Telefone = sede.Telefone;
            sedeBanco.Email = sede.Email;
            sedeBanco.Estado = sede.Estado;
            sedeBanco.Cidade = sede.Cidade;
            sedeBanco.Endereco = sede.Endereco;
            sede.Cep = sede.Cep;
            sedeBanco.Cnpj = sede.Cnpj;
            sedeBanco.SobreNos = sede.SobreNos;
            sedeBanco.Logo = sede.Logo;

            _context.Sedes.Update(sedeBanco);
            _context.SaveChanges();

            return Ok(sedeBanco);
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(uint id)
        {
            var sedeBanco = _context.Sedes.Find(id);

            if (sedeBanco == null)
                return NotFound();

            _context.Sedes.Remove(sedeBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
