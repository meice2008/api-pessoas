using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly AppDbContext _context;

        public TelefoneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Telefone>> ObterTodosAsync()
        {
            return await _context.Telefones
                .Include(t => t.Pessoa)
                .ToListAsync();
        }

        public async Task<Telefone?> ObterPorIdAsync(int id)
        {
            return await _context.Telefones
                .Include(t => t.Pessoa)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AdicionarAsync(Telefone telefone)
        {
            await _context.Telefones.AddAsync(telefone);

            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Telefone telefone)
        {
            _context.Telefones.Update(telefone);

            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Telefone telefone)
        {
            _context.Telefones.Remove(telefone);

            await _context.SaveChangesAsync();
        }


        public async Task<List<Telefone>> ObterPorPessoaIdAsync(int pessoaId)
        {
            return await _context.Telefones
                .Where(t => t.PessoaId == pessoaId)
                .ToListAsync();
        }
    }
}
