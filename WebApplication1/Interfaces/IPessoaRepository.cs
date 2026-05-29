using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> ObterTodosAsync();

        Task<Pessoa?> ObterPorIdAsync(int id);

        Task AdicionarAsync(Pessoa pessoa);

        Task AtualizarAsync(Pessoa pessoa);

        Task RemoverAsync(Pessoa pessoa);
    }
}
