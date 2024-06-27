using HausSalesBackend.Models;
using HausSalesBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HausSalesBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class SalesRepresentativesController : ControllerBase
    {
        private readonly SalesRepresentativeService _salesRepresentativeService;

        public SalesRepresentativesController(SalesRepresentativeService salesRepresentativeService)
        {
            _salesRepresentativeService = salesRepresentativeService;
        }

        // GET: api/SalesRepresentatives
        [HttpGet("GetSalesRepresentatives")]
        public async Task<ActionResult<IEnumerable<SalesRepresentative>>> GetSalesRepresentatives()
        {
            var salesRepresentatives = await _salesRepresentativeService.GetSalesRepresentativesAsync();
            return Ok(salesRepresentatives);
        }

        // GET: api/SalesRepresentatives/5
        [HttpGet("GetSalesRepresentatives/{id}")]
        public async Task<ActionResult<SalesRepresentative>> GetSalesRepresentative(int id)
        {
            var salesRepresentative = await _salesRepresentativeService.GetSalesRepresentativeByIdAsync(id);

            if (salesRepresentative == null)
            {
                return NotFound();
            }

            return Ok(salesRepresentative);
        }

        // POST: api/SalesRepresentatives
        [HttpPost("AddSalesRepresentative")]
        public async Task<ActionResult<SalesRepresentative>> AddSalesRepresentative(SalesRepresentative salesRepresentative)
        {
            var createdSalesRepresentative = await _salesRepresentativeService.AddSalesRepresentativeAsync(salesRepresentative);
            return CreatedAtAction(nameof(GetSalesRepresentative), new { id = createdSalesRepresentative.Id }, createdSalesRepresentative);
        }

        // PUT: api/SalesRepresentatives/5
        [HttpPut("UpdateSalesRepresentative/{id}")]
        public async Task<IActionResult> UpdateSalesRepresentative(int id, SalesRepresentative salesRepresentative)
        {
            if (id != salesRepresentative.Id)
            {
                return BadRequest();
            }

            var success = await _salesRepresentativeService.UpdateSalesRepresentativeAsync(salesRepresentative);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/SalesRepresentatives/5
        [HttpDelete("DeleteSalesRepresentative/{id}")]
        public async Task<IActionResult> DeleteSalesRepresentative(int id)
        {
            var success = await _salesRepresentativeService.DeleteSalesRepresentativeAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
