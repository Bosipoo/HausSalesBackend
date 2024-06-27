using HausSalesBackend.Data;
using HausSalesBackend.Models;
using HausSalesBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Services
{
    public class SaleService : ISaleService
    {
        private readonly ApplicationDbContext _context;

        public SaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<Sale> AddSaleAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<bool> UpdateSaleAsync(Sale sale)
        {
            _context.Entry(sale).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(sale.Id))
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

        public async Task<bool> DeleteSaleAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return false;
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Sale>> SearchSalesAsync(string searchTerm)
        {
            searchTerm = searchTerm.ToLower(); // Convert search term to lowercase for case-insensitive search

            return await _context.Sales
                .Include(s => s.Prospect)
                .Where(s =>
                    s.SalesId.ToLower().Contains(searchTerm) ||
                    s.SalesRefNo.ToLower().Contains(searchTerm) ||
                    s.Prospect.FirstName.ToLower().Contains(searchTerm) ||
                    s.Prospect.LastName.ToLower().Contains(searchTerm))
                .ToListAsync();
        }
        //public async Task<IEnumerable<Sale>> FilterSalessByClientStatusAsync(string clientStatus)
        //{
        //    return await _context.Sales(s => s.)
        //        Prospects
        //                         .Where(p => p.ClientStatus == clientStatus)
        //                         .ToListAsync();
        //}

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}
