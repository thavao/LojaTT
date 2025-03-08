using LojaTT.Context;
using LojaTT.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController(LojaContext context) : ControllerBase
    {
        private readonly LojaContext _context = context;

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido([FromBody] Pedido pedido)
        {
            
            var AddPedidoTask = _context.Pedido.AddAsync(pedido);
            var SaveChangeTask = _context.SaveChangesAsync();
            await Task.WhenAll(AddPedidoTask.AsTask(), SaveChangeTask);
            return Ok();
        }
    }
}
