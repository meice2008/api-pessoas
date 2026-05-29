using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces.Pessoas;

namespace WebApplication1.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> ObterTodosAsync()
        {
            return await _context.Pessoas
                .Include(p => p.Telefones)
                .ToListAsync();
        }

        public async Task<Pessoa?> ObterPorIdAsync(int id)
        {
            return await _context.Pessoas
                .Include(p => p.Telefones)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);

            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);

            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);

            await _context.SaveChangesAsync();
        }
    }
}
