using HausSalesBackend.Data;
using HausSalesBackend.Models;
using HausSalesBackend.Models.DTOs;
using HausSalesBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HausSalesBackend.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("AddProperty")]
        public async Task<ActionResult<Property>> AddProperty([FromBody] PropertyDto property)
        {
            try
            {
                var createdProperty = await _propertyService.AddPropertyAsync(property);
                return CreatedAtAction(nameof(GetProperty), new { id = createdProperty.Id }, createdProperty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddPropertyType")]
        public async Task<IActionResult> AddPropertyType([FromBody] PropertyType propertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdPropertyType = await _propertyService.AddPropertyTypeAsync(propertyType);
                return CreatedAtAction(nameof(GetPropertyTypeById), new { id = createdPropertyType.Id }, createdPropertyType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetPropertyType")]
        public async Task<IActionResult> GetPropertyType()
        {
            var propertyType = await _propertyService.GetPropertiesTypeAsync();

            if (propertyType == null)
            {
                return NotFound();
            }

            return Ok(propertyType);
        }

        [HttpGet("GetPropertyTypeById/{id}")]
        public async Task<IActionResult> GetPropertyTypeById(int id)
        {
            var propertyType = await _propertyService.GetPropertyTypeByIdAsync(id);

            if (propertyType == null)
            {
                return NotFound();
            }

            return Ok(propertyType);
        }

        // GET: api/Properties
        [HttpGet("GetProperties")]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            var properties = await _propertyService.GetPropertiesAsync();
            return Ok(properties);
        }

        // GET: api/Properties/5
        [HttpGet("GetProperty/{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // POST: api/Properties
        

        // PUT: api/Properties/5
        [HttpPut("UpdateProperty/{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            if (!id.Equals( property.Id))
            {
                return BadRequest();
            }

            var success = await _propertyService.UpdatePropertyAsync(property);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Properties/5
        [HttpDelete("DeleteProperty/{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var success = await _propertyService.DeletePropertyAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
