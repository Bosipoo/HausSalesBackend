using HausSalesBackend.Data;
using HausSalesBackend.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Services
{
    public class GeneralLedgerService
    {
        private readonly ApplicationDbContext _context;

        public GeneralLedgerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GeneralLedger>> GetGeneralLedgersAsync()
        {
            return await _context.GeneralLedgers.ToListAsync();
        }

        public async Task<GeneralLedger> GetGeneralLedgerByIdAsync(int id)
        {
            return await _context.GeneralLedgers.FindAsync(id);
        }

        public async Task<GeneralLedger> AddGeneralLedgerAsync(GeneralLedger ledger)
        {
            _context.GeneralLedgers.Add(ledger);
            await _context.SaveChangesAsync();
            return ledger;
        }

        public async Task<bool> UpdateGeneralLedgerAsync(GeneralLedger ledger)
        {
            _context.Entry(ledger).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerExists(ledger.glId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteGeneralLedgerAsync(int id)
        {
            var product = await _context.GeneralLedgers.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.GeneralLedgers.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool LedgerExists(Guid id)
        {
            return _context.GeneralLedgers.Any(e => e.glId == id);
        }
    }
}
