using Happy.Service.Dtos.Complexes;
using Happy.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Happy.WebApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class ComplexController : ControllerBase
{
    private readonly IComplexService _complexService;

    public ComplexController(IComplexService complexService)
    {
        _complexService = complexService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Complex", typeof(ComplexDto))]
    public async Task<IActionResult> Create([FromBody] RequestComplexDto request)
    {
        try
        {
            var complexDto = await _complexService.CreateAsync(request);

            return Ok(complexDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{weekNumber}")]
    [SwaggerResponse(200, "Complex", typeof(ComplexDto))]
    public async Task<IActionResult> Get(int weekNumber)
    {
        try
        {
            var complexDto = await _complexService.GetListAsync(weekNumber);

            return Ok(complexDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _complexService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
