using Happy.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Happy.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ComplexExerciseController : ControllerBase
    {
        private readonly IComplexExerciseService _complexExerciseService;

        public ComplexExerciseController(IComplexExerciseService complexExerciseService)
        {
            _complexExerciseService = complexExerciseService;
        }

        [HttpPost("{complexId}/{exerciseName}")]
        public async Task<IActionResult> Create(long complexId, string exerciseName)
        {
            try
            {
                await _complexExerciseService.CreateAsync(complexId, exerciseName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{complexId}/{exerciseName}")]
        public async Task<IActionResult> Delete(long complexId, string exerciseName)
        {
            try
            {
                await _complexExerciseService.DeleteAsync(complexId, exerciseName);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
