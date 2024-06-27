using HausSalesBackend.Models;
using HausSalesBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace HausSalesBackend.Controllers
{
    [Route("api")]
    [ApiController]
    public class GeneralLedgerController : ControllerBase
    {
        private readonly GeneralLedgerService _generalLedgerService;

        public GeneralLedgerController(GeneralLedgerService generalLedgerService)
        {
            _generalLedgerService = generalLedgerService;
        }

        [HttpPost("AddLedger")]
        public async Task<ActionResult<GeneralLedger>> PostGeneralLedger(GeneralLedger ledger)
        {
            var createdGeneralLedger = await _generalLedgerService.AddGeneralLedgerAsync(ledger);
            return CreatedAtAction("GetGeneralLedger", new { id = createdGeneralLedger.glId }, createdGeneralLedger);
        }

        [HttpGet("GetLedgers")]
        public async Task<ActionResult<IEnumerable<GeneralLedger>>> GetGeneralLedgers()
        {
            var ledgers = await _generalLedgerService.GetGeneralLedgersAsync();
            return Ok(ledgers);
        }

        [HttpGet("GetLedgers/{id}")]
        public async Task<ActionResult<GeneralLedger>> GetGeneralLedger(int id)
        {
            var product = await _generalLedgerService.GetGeneralLedgerByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("UpdateLedgers/{id}")]
        public async Task<IActionResult> PutGeneralLedger(Guid id, GeneralLedger product)
        {
            if (id != product.glId)
            {
                return BadRequest();
            }

            var success = await _generalLedgerService.UpdateGeneralLedgerAsync(product);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("DeleteLedgers/{id}")]
        public async Task<IActionResult> DeleteGeneralLedger(int id)
        {
            var success = await _generalLedgerService.DeleteGeneralLedgerAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

