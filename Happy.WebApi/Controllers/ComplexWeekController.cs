using Happy.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Happy.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ComplexWeekController : ControllerBase
    {
        private readonly IComplexWeekService _complexWeekService;

        public ComplexWeekController(IComplexWeekService complexWeekService)
        {
            _complexWeekService = complexWeekService;
        }

        [HttpPost("{complexId}/{weekNumber}")]
        public async Task<IActionResult> Create(long complexId, int weekNumber)
        {
            try
            {
                await _complexWeekService.CreateAsync(complexId, weekNumber);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{complexId}/{weekNumber}")]
        public async Task<IActionResult> Delete(long complexId, int weekNumber)
        {
            try
            {
                await _complexWeekService.DeleteAsync(complexId, weekNumber);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
