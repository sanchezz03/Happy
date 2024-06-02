using Happy.Common.Enums;
using Happy.Domain.Entities;
using Happy.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Happy.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TrainingRecommendationController : BaseController
    {
        private readonly ITrainingRecommendationService _trainingRecommendationService;

        public TrainingRecommendationController(ITrainingRecommendationService trainingRecommendationService, 
            UserManager<User> userManager) : base(userManager)
        {
            _trainingRecommendationService = trainingRecommendationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long complexId, ERateOfPerceivedExertion rate)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var response = await _trainingRecommendationService.PredictSportLoadAsync(user.Id, complexId, rate);

                return Ok(response);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
