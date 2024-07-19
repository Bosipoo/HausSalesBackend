using AutoMapper;
using HausSalesBackend.Data;
using HausSalesBackend.Models;
using HausSalesBackend.Models.DTOs;
using HausSalesBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PropertyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task<Property> AddPropertyAsync(PropertyDto property)
        {
            var prop = _mapper.Map<Property>(property);
            _context.Properties.Add(prop);
            await _context.SaveChangesAsync();
            return prop;
        }

        public async Task<bool> UpdatePropertyAsync(Property property)
        {
            _context.Entry(property).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(property.Id))
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

        public async Task<bool> DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return false;
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
