using Happy.Service.Dtos;
using Happy.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Happy.WebApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Exercise", typeof(ExerciseDto))]
    public async Task<IActionResult> Create([FromBody] ExerciseDto request)
    {
        try
        {
            var exerciseDto = await _exerciseService.CreateAsync(request);

            return Ok(exerciseDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{exerciseName}")]
    [SwaggerResponse(200, "Exercise", typeof(ExerciseDto))]
    public async Task<IActionResult> Get(string exerciseName)
    {
        try
        {
            var exerciseDto = await _exerciseService.GetAsync(exerciseName);

            return Ok(exerciseDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(long id,[FromBody] ExerciseDto request)
    {
        try
        {
            await _exerciseService.UpdateAsync(id, request);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _exerciseService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
