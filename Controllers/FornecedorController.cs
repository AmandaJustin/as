using Microsoft.AspNetCore.Mvc;
using MinhaLojaAPI.Models;
using MinhaLojaAPI.Repositories;

namespace MinhaLojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fornecedores = _fornecedorRepository.GetAll();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Create(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _fornecedorRepository.Add(fornecedor);
            _fornecedorRepository.Save();
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest("ID do fornecedor não corresponde.");
            }

            var existingFornecedor = _fornecedorRepository.GetById(id);
            if (existingFornecedor == null)
            {
                return NotFound();
            }

            _fornecedorRepository.Update(fornecedor);
            _fornecedorRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _fornecedorRepository.Delete(id);
            _fornecedorRepository.Save();
            return NoContent();
        }
    }
}