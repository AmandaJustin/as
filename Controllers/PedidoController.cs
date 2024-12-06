using Microsoft.AspNetCore.Mvc;
using MinhaLojaAPI.Models;
using MinhaLojaAPI.Repositories;

namespace MinhaLojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pedidos = _pedidoRepository.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pedido = _pedidoRepository.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pedidoRepository.Add(pedido);
            _pedidoRepository.Save();
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest("ID do pedido não corresponde.");
            }

            var existingPedido = _pedidoRepository.GetById(id);
            if (existingPedido == null)
            {
                return NotFound();
            }

            _pedidoRepository.Update(pedido);
            _pedidoRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _pedidoRepository.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _pedidoRepository.Delete(id);
            _pedidoRepository.Save();
            return NoContent();
        }
    }
}