using WebApplication1.DTOs.Telefone;

namespace WebApplication1.Interfaces.Telefones
{
    public interface ITelefoneService
    {
        Task<List<TelefoneResponseDto>> ObterTodosAsync();
        Task<TelefoneResponseDto?> ObterPorIdAsync(int id);
        Task<TelefoneResponseDto> CriarAsync(TelefoneRequestDto dto);
        Task<bool> AtualizarAsync(int id, TelefoneRequestDto dto);
        Task<bool> RemoverAsync(int id);
        Task<List<TelefoneResponseDto>> ObterPorPessoaIdAsync(int pessoaId);
    }
}
