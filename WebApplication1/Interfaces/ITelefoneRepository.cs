using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<List<Telefone>> ObterTodosAsync();
        Task<Telefone?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Telefone telefone);
        Task AtualizarAsync(Telefone telefone);
        Task RemoverAsync(Telefone telefone);
        Task<List<Telefone>> ObterPorPessoaIdAsync(int pessoaId);
    }
}
