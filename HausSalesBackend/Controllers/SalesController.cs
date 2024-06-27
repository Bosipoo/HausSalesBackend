using HausSalesBackend.Models;
using HausSalesBackend.Services;
using HausSalesBackend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HausSalesBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("AddSale")]
        public async Task<ActionResult<Sale>> AddProperty(Sale sale)
        {
            var createdSale = await _saleService.AddSaleAsync(sale);
            return CreatedAtAction(nameof(GetSale), new { id = createdSale.Id }, createdSale);
        }

        [HttpGet("GetSales")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            var sales = await _saleService.GetSalesAsync();
            return Ok(sales);
        }

        [HttpGet("GetSale/{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sales = await _saleService.GetSaleByIdAsync(id);

            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Sale>>> SearchSales([FromQuery] string searchTerm)
        {
            var sales = await _saleService.SearchSalesAsync(searchTerm);
            return Ok(sales);
        }
    }
}
