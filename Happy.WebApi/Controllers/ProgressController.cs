using Happy.Domain.Entities;
using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;
using Happy.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Happy.WebApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
public class ProgressController : BaseController
{
    private readonly IProgressService _progressService;

    public ProgressController(IProgressService progressService,
        UserManager<User> userManager) : base(userManager)
    {
        _progressService = progressService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Progress", typeof(ProgressDto))]
    public async Task<IActionResult> Create([FromBody] ModificationProgressDto request)
    {
        try
        {
            var progressDto = await _progressService.CreateAsync(request);
        
            return Ok(progressDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [SwaggerResponse(200, "ProgressDtos", typeof(IEnumerable<ProgressDto>))]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var user = await GetCurrentUserAsync();
            var exerciseDto = await _progressService.GetListAsync(user.Id);

            return Ok(exerciseDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] ModificationProgressDto request)
    {
        try
        {
            await _progressService.UpdateAsync(id, request);

            return Ok();
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
            await _progressService.DeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
