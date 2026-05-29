using WebApplication1.DTOs;

namespace WebApplication1.Interfaces
{
    public interface IPessoaService
    {
        Task<List<PessoaResponseDto>> ObterTodosAsync();
        Task<PessoaResponseDto?> ObterPorIdAsync(int id);
        Task<PessoaResponseDto> CriarAsync(PessoaRequestDto dto);
        Task<bool> AtualizarAsync(int id, PessoaRequestDto dto);
        Task<bool> RemoverAsync(int id);
    }
}
