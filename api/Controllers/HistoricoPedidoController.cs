using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiChamaAi.Entities;
using chamaAi.Context;

namespace apiChamaAi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoPedidoController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public HistoricoPedidoController(ApiChamaAiContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> PegarTodosAsync() { 
            return await _context.Pedidos.ToListAsync();
        }

        [HttpPost]
        public IActionResult CreateHoraPedidoCliente(Pedido historicoPedido){

           var pedido = new Pedido{
                HoraPedidoCliente = historicoPedido.HoraPedidoCliente,
                HoraSaidaMotoboySede = historicoPedido.HoraSaidaMotoboySede,
                HoraChegadaMotoboyCliente = historicoPedido.HoraChegadaMotoboyCliente,
                HoraMotoboyEntregaCliente = historicoPedido.HoraMotoboyEntregaCliente
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return Ok();
        }
}
}