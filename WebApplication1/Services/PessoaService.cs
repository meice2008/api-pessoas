using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PessoaResponseDto>> ObterTodosAsync()
        {
            var pessoas = await _repository.ObterTodosAsync();

            return pessoas.Select(p => new PessoaResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email,

                Telefones = p.Telefones?
            .Select(t => new TelefoneResponseDto
            {
                Id = t.Id,
                Numero = t.Numero,
                PessoaId = t.PessoaId
            })
            .ToList() ?? new List<TelefoneResponseDto>()
            }).ToList();
        }

        public async Task<PessoaResponseDto?> ObterPorIdAsync(int id)
        {
            var pessoa = await _repository.ObterPorIdAsync(id);

            if (pessoa == null)
                return null;

            return new PessoaResponseDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,

                Telefones = pessoa.Telefones?
                    .Select(t => new TelefoneResponseDto
                    {
                        Id = t.Id,
                        Numero = t.Numero,
                        PessoaId = t.PessoaId
                    })
                    .ToList() ?? new List<TelefoneResponseDto>()
            };
        }

        public async Task<PessoaResponseDto> CriarAsync(PessoaRequestDto dto)
        {
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Email = dto.Email,
                //DataNascimento = dto.DataNascimento,
                //EstaAtivo = true
            };

            await _repository.AdicionarAsync(pessoa);

            return new PessoaResponseDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email
            };
        }

        public async Task<bool> AtualizarAsync(int id, PessoaRequestDto dto)
        {
            var pessoa = await _repository.ObterPorIdAsync(id);

            if (pessoa == null)
                return false;

            pessoa.Nome = dto.Nome;
            pessoa.Email = dto.Email;
            //pessoa.DataNascimento = dto.DataNascimento;

            await _repository.AtualizarAsync(pessoa);

            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var pessoa = await _repository.ObterPorIdAsync(id);

            if (pessoa == null)
                return false;

            await _repository.RemoverAsync(pessoa);

            return true;
        }
    }
}
