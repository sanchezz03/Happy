using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;
using Happy.Service.Dtos;
using Happy.Utils.Models;
using Happy.Common.Enums;
using Happy.Utils;
using Happy.Service.Dtos.Complexes;

namespace Happy.Service.Services;

public class TrainingRecommendationService : ITrainingRecommendationService
{
    private readonly IComplexDataProvider _complexDataProvider;
    private readonly IProgressDataProvider _progressDataProvider;

    public TrainingRecommendationService(IComplexDataProvider complexDataProvider,
        IProgressDataProvider progressDataProvider)
    {
        _complexDataProvider = complexDataProvider;
        _progressDataProvider = progressDataProvider;
    }

    #region Public methods

    public async Task<List<TrainingRecommendationDto>> PredictSportLoadAsync(string userId, long complexId, ERateOfPerceivedExertion rate)
    {
        return await HandleGettingTrainingRecommendationAsync(userId, complexId, rate);
    }

    #endregion

    #region Private methods

    private async Task<List<TrainingRecommendationDto>> HandleGettingTrainingRecommendationAsync(string userId, long complexId, ERateOfPerceivedExertion rate)
    {
        var complexDto = await _complexDataProvider.GetAsync(complexId);
        var exerciseDtos = HandleGettingExerciseDtosAsync(complexDto);
        var progressDtos = await _progressDataProvider.GetListAsync(userId);

        var trainingDatas = GetTrainingDatas(progressDtos);

        return GetTrainingRecommendation(complexDto, exerciseDtos, trainingDatas, rate);
    }

    private List<ExerciseDto> HandleGettingExerciseDtosAsync(ComplexDto complexDto)
    {
        var exerciseDtos = complexDto.ComplexExerciseDtos
            .Select(x => x.ExerciseDto)
            .ToList();

        return exerciseDtos;
    }

    private List<TrainingData> GetTrainingDatas(IEnumerable<ProgressDto> progressDtos)
    {
        return progressDtos.Select(p => new TrainingData
        {
            Weight = p.Weight ?? 0,
            NumberOfRepetitions = p.NumberOfRepetitions,
            RateOfPerceivedExertion = (float)(p.GetRateOfPerceivedExertion(p.RateOfPerceivedExertion)),
            Day = (float)(p.Date - progressDtos.Min(d => d.Date)).TotalDays
        }).ToList();
    }

    private List<TrainingRecommendationDto> GetTrainingRecommendation(ComplexDto complexDto, List<ExerciseDto> exerciseDtos,
        List<TrainingData> trainingDatas, ERateOfPerceivedExertion rate)
    {
        var response = new List<TrainingRecommendationDto>();
        var service = new PredictingSportsLoadService(trainingDatas);

        foreach (var exerciseDto in exerciseDtos)
        {
            var trainingRecommendationDto = new TrainingRecommendationDto();

            trainingRecommendationDto.ExerciseId = exerciseDto.Id;
            trainingRecommendationDto.Weight = (int)service.PredictWeight(exerciseDto.NumberOfRepetitions, (float)rate, (float)complexDto.WeekDay);
            trainingRecommendationDto.Repetitions = (int)service.PredictRepetitions((float)exerciseDto.Weight, (float)rate, (float)complexDto.WeekDay);

            response.Add(trainingRecommendationDto);
        }

        return response;
    }

    #endregion
}