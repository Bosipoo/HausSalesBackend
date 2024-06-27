using HausSalesBackend.Models;
using HausSalesBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HausSalesBackend.Controllers
{
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
        public async Task<ActionResult<Property>> AddProperty(Property property)
        {
            var createdProperty = await _propertyService.AddPropertyAsync(property);
            return CreatedAtAction(nameof(GetProperty), new { id = createdProperty.Id }, createdProperty);
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
            if (id != property.Id)
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
