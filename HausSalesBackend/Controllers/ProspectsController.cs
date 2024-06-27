using HausSalesBackend.Models;
using HausSalesBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace HausSalesBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProspectsController : ControllerBase
    {
        private readonly ProspectService _prospectService;

        public ProspectsController(ProspectService prospectService)
        {
            _prospectService = prospectService;
        }

        // POST: api/Prospects
        [HttpPost("AddProspect")]
        public async Task<ActionResult<Prospect>> AddProspect(Prospect prospect)
        {
            var createdProspect = await _prospectService.AddProspectAsync(prospect);
            return CreatedAtAction(nameof(GetProspect), new { id = createdProspect.Id }, createdProspect);
        }

        // GET: api/Prospects
        [HttpGet("GetProspects")]
        public async Task<ActionResult<IEnumerable<Prospect>>> GetProspects()
        {
            var prospects = await _prospectService.GetProspectsAsync();
            return Ok(prospects);
        }

        // GET: api/Prospects/5
        [HttpGet("GetProspects/{id}")]
        public async Task<ActionResult<Prospect>> GetProspect(int id)
        {
            var prospect = await _prospectService.GetProspectByIdAsync(id);

            if (prospect == null)
            {
                return NotFound();
            }

            return Ok(prospect);
        }

        // PUT: api/Prospects/5
        [HttpPut("UpdateProspect/{id}")]
        public async Task<IActionResult> UpdateProspect(int id, Prospect prospect)
        {
            if (id != prospect.Id)
            {
                return BadRequest();
            }

            var success = await _prospectService.UpdateProspectAsync(prospect);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Prospects/5
        [HttpDelete("DeleteProspect/{id}")]
        public async Task<IActionResult> DeleteProspect(int id)
        {
            var success = await _prospectService.DeleteProspectAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/Prospects/FilterByClientStatus
        [HttpGet("FilterByClientStatus")]
        public async Task<ActionResult<IEnumerable<Prospect>>> FilterByClientStatus([FromQuery] string clientStatus)
        {
            var prospects = await _prospectService.FilterProspectsByClientStatusAsync(clientStatus);
            return Ok(prospects);
        }

        // GET: api/Prospects/GenerateReport
        [HttpGet("GenerateReport")]
        public async Task<ActionResult<IEnumerable<Prospect>>> GenerateReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var prospects = await _prospectService.GenerateProspectsReportAsync(startDate, endDate);
            return Ok(prospects);
        }
    }
}
