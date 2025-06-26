using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Services
{
    public class CotacaoService
    {

        private readonly AppDbContext _context;

        public CotacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cotacao>> GetAllAsync()
        {
            return await _context.Cotacoes.ToListAsync();
        }

        public async Task<Cotacao> GetByIdAsync(int idCotacao)
        {
            return await _context.Cotacoes.FindAsync(idCotacao);
        }

        public async Task<Cotacao> CreateAsync(Cotacao cotacao)
        {
            _context.Cotacoes.Add(cotacao);
            await _context.SaveChangesAsync();
            return cotacao;
        }

        public async Task<bool> UpdateAsync(int idCotacao, Cotacao cotacao)
        {
            if (idCotacao != cotacao.IdCotacao)
                return false;

            _context.Entry(cotacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cotacao = await _context.Cotacoes.FindAsync(id);
            if (cotacao == null)
                return false;

            _context.Cotacoes.Remove(cotacao);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
