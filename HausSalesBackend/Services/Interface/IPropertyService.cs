using HausSalesBackend.Models;
using HausSalesBackend.Models.DTOs;

namespace HausSalesBackend.Services.Interface
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<Property> AddPropertyAsync(PropertyDto property);
        Task<bool> UpdatePropertyAsync(Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}
