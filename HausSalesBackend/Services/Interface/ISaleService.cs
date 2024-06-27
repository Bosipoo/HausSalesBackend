using HausSalesBackend.Models;

namespace HausSalesBackend.Services.Interface
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetSalesAsync();
        Task<Sale?> GetSaleByIdAsync(int id);
        Task<Sale> AddSaleAsync(Sale sale);
        Task<bool> UpdateSaleAsync(Sale sale);
        Task<bool> DeleteSaleAsync(int id);
        Task<IEnumerable<Sale>> SearchSalesAsync(string searchTerm);
    }
}
