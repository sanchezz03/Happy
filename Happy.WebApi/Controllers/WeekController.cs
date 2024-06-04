using Happy.Service.Dtos;
using Happy.Service.Services.DataProviders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Happy.WebApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class WeekController : ControllerBase
{
    private readonly IWeekDataProvider _weekDataProvider;

    public WeekController(IWeekDataProvider weekDataProvider)
    {
        _weekDataProvider = weekDataProvider;
    }

    [HttpGet("{weekNumber}")]
    [SwaggerResponse(200, "Week", typeof(WeekDto))]
    public async Task<IActionResult> Get(int weekNumber)
    {
        try
        {
            var week = await _weekDataProvider.GetByWeekNumberAsync(weekNumber);

            if (week == null)
            {
                return BadRequest();
            }

            return Ok(week);
        }
        catch (Exception ex){

            return BadRequest(ex.Message);
        }
    }
}
