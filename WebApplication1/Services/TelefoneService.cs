using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _repository;

        public TelefoneService(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TelefoneResponseDto>> ObterTodosAsync()
        {
            var telefones = await _repository.ObterTodosAsync();

            return telefones.Select(t => new TelefoneResponseDto
            {
                Id = t.Id,
                Numero = t.Numero,
                PessoaId = t.PessoaId
            }).ToList();
        }

        public async Task<TelefoneResponseDto?> ObterPorIdAsync(int id)
        {
            var telefone = await _repository.ObterPorIdAsync(id);

            if (telefone == null)
                return null;

            return new TelefoneResponseDto
            {
                Id = telefone.Id,
                Numero = telefone.Numero,
                PessoaId = telefone.PessoaId
            };
        }

        public async Task<TelefoneResponseDto> CriarAsync(TelefoneRequestDto dto)
        {
            var telefone = new Telefone
            {
                Numero = dto.Numero,
                PessoaId = dto.PessoaId
            };

            await _repository.AdicionarAsync(telefone);

            return new TelefoneResponseDto
            {
                Id = telefone.Id,
                Numero = telefone.Numero,
                PessoaId = telefone.PessoaId
            };
        }

        public async Task<bool> AtualizarAsync(int id, TelefoneRequestDto dto)
        {
            var telefone = await _repository.ObterPorIdAsync(id);

            if (telefone == null)
                return false;

            telefone.Numero = dto.Numero;
            telefone.PessoaId = dto.PessoaId;

            await _repository.AtualizarAsync(telefone);

            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var telefone = await _repository.ObterPorIdAsync(id);

            if (telefone == null)
                return false;

            await _repository.RemoverAsync(telefone);

            return true;
        }

        public async Task<List<TelefoneResponseDto>> ObterPorPessoaIdAsync(int pessoaId)
        {
            var telefones = await _repository.ObterPorPessoaIdAsync(pessoaId);

            return telefones.Select(t => new TelefoneResponseDto
            {
                Id = t.Id,
                Numero = t.Numero,
                PessoaId = t.PessoaId
            }).ToList();
        }
    }
}
