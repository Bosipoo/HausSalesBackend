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

        public async Task<Property> AddPropertyAsync(PropertyDto propertyDto)
        {
            var propertyType = await _context.PropertyTypes.FindAsync(propertyDto.PropertyTypeId);
            if (propertyType == null)
            {
                throw new Exception("Invalid PropertyTypeId");
            }

            var property = _mapper.Map<Property>(propertyDto);
            property.PropertyType = propertyType;

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
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

        public async Task<PropertyType> AddPropertyTypeAsync(PTypeDto propertyType)
        {

            var prop = _mapper.Map<PropertyType>(propertyType);
            _context.PropertyTypes.Add(prop);
            await _context.SaveChangesAsync();
            return prop;
        }

        public async Task<IEnumerable<PropertyType>> GetPropertiesTypeAsync()
        {
            return await _context.PropertyTypes.ToListAsync();
        }

        public async Task<PropertyType?> GetPropertyTypeByIdAsync(int id)
        {
            return await _context.PropertyTypes.FindAsync(id);
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
