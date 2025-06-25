using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Services
{
    public class OperacaoService
    {
        private readonly AppDbContext _context;

        public OperacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Operacao>> GetAllAsync()
        {
            return await _context.Operacoes.ToListAsync();
        }

        public async Task<Operacao> GetByIdAsync(int id)
        {
            return await _context.Operacoes.FindAsync(id);
        }

        public async Task<Operacao> CreateAsync(Operacao operacao)
        {
            _context.Operacoes.Add(operacao);
            await _context.SaveChangesAsync();
            return operacao;
        }

        public async Task<bool>UpdateAsync(int id, Operacao operacao)
        {
            if (id != operacao.IdOperacao)
            return false;

            _context.Entry(operacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var operacao = await _context.Operacoes.FindAsync(id);
            if (operacao == null)
                return false;

            _context.Operacoes.Remove(operacao);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
