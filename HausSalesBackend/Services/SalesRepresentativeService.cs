using HausSalesBackend.Data;
using HausSalesBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Services
{
    public class SalesRepresentativeService
    {
        private readonly ApplicationDbContext _context;

        public SalesRepresentativeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesRepresentative>> GetSalesRepresentativesAsync()
        {
            return await _context.SalesRepresentatives.ToListAsync();
        }

        public async Task<SalesRepresentative?> GetSalesRepresentativeByIdAsync(int id)
        {
            return await _context.SalesRepresentatives.FindAsync(id);
        }

        public async Task<SalesRepresentative> AddSalesRepresentativeAsync(SalesRepresentative salesRepresentative)
        {
            _context.SalesRepresentatives.Add(salesRepresentative);
            await _context.SaveChangesAsync();
            return salesRepresentative;
        }

        public async Task<bool> UpdateSalesRepresentativeAsync(SalesRepresentative salesRepresentative)
        {
            _context.Entry(salesRepresentative).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesRepresentativeExists(salesRepresentative.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteSalesRepresentativeAsync(int id)
        {
            var salesRepresentative = await _context.SalesRepresentatives.FindAsync(id);
            if (salesRepresentative == null)
            {
                return false;
            }

            _context.SalesRepresentatives.Remove(salesRepresentative);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SalesRepresentative>> SearchSalesRepresentativesAsync(string? firstName, string? lastName, string? email)
        {
            var query = _context.SalesRepresentatives.AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(sr => sr.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(sr => sr.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(sr => sr.Email.Contains(email));
            }

            return await query.ToListAsync();
        }

        private bool SalesRepresentativeExists(int id)
        {
            return _context.SalesRepresentatives.Any(e => e.Id == id);
        }
    }
}
