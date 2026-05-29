using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api-pessoas")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("listar-todas")]
        public async Task<IActionResult> ObterTodos()
        {
            var pessoas = await _service.ObterTodosAsync();

            return Ok(pessoas);
        }

        [HttpGet()]
        [Route("listar-por-id/{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var pessoa = await _service.ObterPorIdAsync(id);

            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] PessoaRequestDto dto)
        {
            var pessoa = await _service.CriarAsync(dto);

            return CreatedAtAction(nameof(ObterPorId), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut()]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] PessoaRequestDto dto)
        {
            var atualizado = await _service.AtualizarAsync(id, dto);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var removido = await _service.RemoverAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
