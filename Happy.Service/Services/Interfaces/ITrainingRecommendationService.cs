using Happy.Common.Enums;
using Happy.Service.Dtos;

namespace Happy.Service.Services.Interfaces;

public interface ITrainingRecommendationService
{
    Task<List<TrainingRecommendationDto>> PredictSportLoadAsync(string userId, long complexId, ERateOfPerceivedExertion rate);
}
