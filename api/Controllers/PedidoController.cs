using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using chamaAi.Context;
using apiChamaAi.Entities;

namespace chamaAi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public PedidoController(ApiChamaAiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> PegarTodosAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(uint id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            _context.Add(pedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = pedido.Id }, pedido);
        }

        // [HttpPut("{id}")]
        // public IActionResult Atualizar(uint id, Pedido pedido)
        // {
        //     if (id <= 0 || pedido == null || pedido.Id != id)
        //     {
        //         return BadRequest();
        //     }

        //     var pedidoBanco = _context.Pedidos.Find(id);

        //     if (pedidoBanco == null)
        //         return NotFound();

        //     pedidoBanco.LocalizacaoClienteDestino = pedido.LocalizacaoClienteDestino;

        //     _context.SaveChanges();

        //     return Ok(pedidoBanco);
        // }

        [HttpPut("{id}")]
        public IActionResult AtualizarPedido(uint id, Pedido pedido)
        {
            if (id <= 0 || pedido == null || pedido.Id != id)
            {
                return BadRequest();
            }

            var pedidoBanco = _context.Pedidos.Find(id);

            if (pedidoBanco == null)
                return NotFound();

            pedidoBanco.Id = pedido.Id;
            pedidoBanco.EnderecoAtual = pedido.EnderecoAtual;
            pedidoBanco.NumeroAtual = pedido.NumeroAtual;
            pedidoBanco.EnderecoNumeroAtual = pedido.EnderecoNumeroAtual;
            pedidoBanco.EnderecoDestino = pedido.EnderecoDestino;
            pedidoBanco.NumeroDestino = pedido.NumeroDestino;
            pedidoBanco.EstadoDestino = pedido.EstadoDestino;
            pedidoBanco.EnderecoNumeroDestino = pedido.EnderecoNumeroDestino;
            pedidoBanco.TamanhoProduto = pedido.TamanhoProduto;
            pedidoBanco.PesoProduto = pedido.PesoProduto;
            pedidoBanco.isFragil = pedido.isFragil;
            pedidoBanco.DescricaoProduto = pedido.DescricaoProduto;
            pedidoBanco.FormaDePagamento = pedido.FormaDePagamento;
            pedidoBanco.LocalizacaoClienteOrigem.Latitude = pedido.LocalizacaoClienteOrigem.Latitude;
            pedidoBanco.LocalizacaoClienteOrigem.Longitude = pedido.LocalizacaoClienteOrigem.Longitude;
            pedidoBanco.LocalizacaoClienteDestino.Longitude = pedido.LocalizacaoClienteDestino.Longitude;
            pedidoBanco.LocalizacaoClienteDestino.Latitude = pedido.LocalizacaoClienteDestino.Latitude;
            
            pedidoBanco.HoraPedidoCliente = pedido.HoraPedidoCliente;
            pedidoBanco.HoraSaidaMotoboySede = pedido.HoraSaidaMotoboySede;
            pedidoBanco.HoraChegadaMotoboyCliente = pedido.HoraChegadaMotoboyCliente;
            pedidoBanco.HoraMotoboyEntregaCliente = pedido.HoraMotoboyEntregaCliente;
            pedidoBanco.ValorAproximadoDaCorrida = pedido.ValorAproximadoDaCorrida;
            pedidoBanco.QualServico = pedido.QualServico;
            pedidoBanco.SedeId = pedido.SedeId;
            pedidoBanco.UsuarioId = pedido.UsuarioId;

            _context.Pedidos.Update(pedidoBanco);
            _context.SaveChanges();

            return Ok(pedidoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(uint id)
        {
            var pedidoBanco = _context.Pedidos.Find(id);

            if (pedidoBanco == null)
                return NotFound();

            _context.Pedidos.Remove(pedidoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
