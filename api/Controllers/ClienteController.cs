using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using chamaAi.Context;
using apiChamaAi.Entities;

namespace chamaAi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public ClienteController(ApiChamaAiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> PegarTodosAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = cliente.Id }, cliente);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(uint id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nomeCompleto)
        {
            var clientes = _context.Clientes.Where(x => x.NomeCompleto.Contains(nomeCompleto));

            if (clientes == null)
                return NotFound();

            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(uint id, Cliente cliente)
        {
            if (id <= 0 || cliente == null || cliente.Id != id)
            {
                return BadRequest();
            }

            var clienteBanco = _context.Clientes.Find(id);

            if (clienteBanco == null)
                return NotFound();

            clienteBanco.NomeCompleto = cliente.NomeCompleto;
            clienteBanco.Telefone = cliente.Telefone;
            clienteBanco.Email = cliente.Email;
            clienteBanco.DataDNascimento = cliente.DataDNascimento;
            clienteBanco.tipo = cliente.tipo;
            clienteBanco.FotoDePerfil = cliente.FotoDePerfil;
            clienteBanco.Senha = cliente.Senha;
            clienteBanco.ConfirmaSenha = cliente.ConfirmaSenha;

            _context.SaveChanges();

            return Ok(clienteBanco);
        }

        // [HttpPut("AtualizarPorNome")]
        // public IActionResult AtualizarPorNome(string nome, Usuario usuario)
        // {
        //     var usuarios = _context.Usuarios.Where(x => x.Nome.Contains(nome));

        //     if(usuarios == null)
        //         return NotFound();

        //     usuarios.Nome = usuario.Nome;
        //     usuarios.Sobrenome = usuario.Sobrenome;
        //     usuarios.Telefone = usuario.Telefone;
        //     usuarios.Email =  usuario.Email;
        //     usuarios.DataDNascimento =  usuario.DataDNascimento;

        //     _context.Usuarios.Update(usuarios);
        //     _context.SaveChanges();

        //     return Ok (usuarios);
        // }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(uint id)
        {
            var clienteBanco = _context.Clientes.Find(id);

            if (clienteBanco == null)
                return NotFound();

            _context.Clientes.Remove(clienteBanco);
            _context.SaveChanges();
            return NoContent();
        }



        [HttpPut("UploadoFotoPerfildoUsuario")]
        public async Task<ActionResult> UploadFotoPerfilUsuario([FromForm] IFormFile foto, [FromForm] Cliente cliente, [FromForm] uint id)
        {
            if (foto == null || foto.Length == 0)
                return BadRequest();

            // Ler os bytes da imagem a partir do arquivo enviado
            using (var stream = new MemoryStream())
            {
                await foto.CopyToAsync(stream);
                byte[] data = stream.ToArray();

                // Salvar a imagem no banco de dados ou em algum outro local de armazenamento

                return Ok();
            }
        }
    }
}
