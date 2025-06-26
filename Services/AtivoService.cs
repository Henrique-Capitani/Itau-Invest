using Itau_invest.Data;
using Itau_invest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itau_invest.Services
{
    public class AtivoService
    {
        private readonly AppDbContext _context;

        public AtivoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ativo>> GetAllAsync()
        {
            try
            {
                return await _context.Ativo.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os ativos.", ex);
            }
        }

        public async Task<Ativo> GetByIdAsync(int idAtivo)
        {
            try
            {
                var ativo = await _context.Ativo.FindAsync(idAtivo);
                if (ativo == null)
                    throw new KeyNotFoundException("Ativo não encontrado.");

                return ativo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o ativo por ID.", ex);
            }
        }

        public async Task<Ativo> CreateAsync(Ativo ativo)
        {
            try
            {
                _context.Ativo.Add(ativo);
                await _context.SaveChangesAsync();
                return ativo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o ativo.", ex);
            }
        }

        public async Task<Ativo> UpdateAsync(int idAtivo, Ativo ativo)
        {
            if (idAtivo != ativo.IdAtivo)
                return null;

            try
            {
                var existingAtivo = await _context.Ativo.FindAsync(idAtivo);
                if (existingAtivo == null)
                    return null;

                existingAtivo.Nome = ativo.Nome; 
                existingAtivo.Codigo = ativo.Codigo; 

                await _context.SaveChangesAsync();
                return existingAtivo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o ativo.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var ativo = await _context.Ativo.FindAsync(id);
                if (ativo == null)
                    return false;

                _context.Ativo.Remove(ativo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o ativo.", ex);
            }
        }
    }
}
