﻿using HausSalesBackend.Models;
using HausSalesBackend.Models.DTOs;
using HausSalesBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace HausSalesBackend.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> AddGeneralLedger([FromBody] GLedgerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ledger = await _generalLedgerService.AddGeneralLedgerAsync(dto);
            return Ok(ledger);
        }

        [HttpGet("GetLedgers")]
        public async Task<ActionResult<IEnumerable<GeneralLedger>>> GetGeneralLedgers()
        {
            var ledgers = await _generalLedgerService.GetGeneralLedgersAsync();
            return Ok(ledgers);
        }

        [HttpGet("GetLedgers/{id}")]
        public async Task<ActionResult<GeneralLedger>> GetGeneralLedger(Guid id)
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

