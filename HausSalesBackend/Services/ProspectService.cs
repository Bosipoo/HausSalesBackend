using HausSalesBackend.Data;
using HausSalesBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Services
{
    public class ProspectService
    {
        private readonly ApplicationDbContext _context;

        public ProspectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prospect>> GetProspectsAsync()
        {
            return await _context.Prospects.ToListAsync();
        }

        public async Task<Prospect?> GetProspectByIdAsync(int id)
        {
            return await _context.Prospects.FindAsync(id);
        }

        public async Task<Prospect> AddProspectAsync(Prospect prospect)
        {
            _context.Prospects.Add(prospect);
            await _context.SaveChangesAsync();
            return prospect;
        }

        public async Task<bool> UpdateProspectAsync(Prospect prospect)
        {
            _context.Entry(prospect).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectExists(prospect.Id))
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

        public async Task<bool> DeleteProspectAsync(int id)
        {
            var prospect = await _context.Prospects.FindAsync(id);
            if (prospect == null)
            {
                return false;
            }

            _context.Prospects.Remove(prospect);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Prospect>> FilterProspectsByClientStatusAsync(string clientStatus)
        {
            return await _context.Prospects
                                 .Where(p => p.ClientStatus == clientStatus)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Prospect>> GenerateProspectsReportAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Prospects
                                 .Where(p => p.DateOfBirth >= startDate && p.DateOfBirth <= endDate)
                                 .ToListAsync();
        }

        private bool ProspectExists(int id)
        {
            return _context.Prospects.Any(e => e.Id == id);
        }
    }
}
