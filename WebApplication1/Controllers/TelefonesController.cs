using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api-telefones")]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneService _service;

        public TelefonesController(ITelefoneService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("listar-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            var telefones = await _service.ObterTodosAsync();

            return Ok(telefones);
        }

        [HttpGet()]
        [Route("listar-por-id/{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var telefone = await _service.ObterPorIdAsync(id);

            if (telefone == null)
                return NotFound();

            return Ok(telefone);
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Criar([FromBody] TelefoneRequestDto dto)
        {
            var telefone = await _service.CriarAsync(dto);

            return CreatedAtAction(nameof(ObterPorId), new { id = telefone.Id }, telefone);
        }

        [HttpPut()]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(
            int id,
            [FromBody] TelefoneRequestDto dto)
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

        [HttpGet("listar-por-pessoa/{pessoaId}")]
        public async Task<IActionResult> ObterPorPessoa(int pessoaId)
        {
            var telefones = await _service.ObterPorPessoaIdAsync(pessoaId);

            if (telefones == null)
                return NotFound();

            return Ok(telefones);
        }
    }
}
