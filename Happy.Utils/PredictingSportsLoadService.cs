using Happy.Utils.Models;
using Microsoft.ML;

namespace Happy.Utils;

public class PredictingSportsLoadService
{
    private readonly MLContext _mlContext;
    private readonly ITransformer _weightModel;
    private readonly ITransformer _repetitionsModel;

    public PredictingSportsLoadService(List<TrainingData> trainingData)
    {
        _mlContext = new MLContext();

        var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

        var weightPipeline = _mlContext.Transforms.Concatenate("Features", nameof(TrainingData.NumberOfRepetitions), nameof(TrainingData.RateOfPerceivedExertion), nameof(TrainingData.Day))
                             .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(TrainingData.Weight), maximumNumberOfIterations: 100));
        _weightModel = weightPipeline.Fit(dataView);

        var repetitionsPipeline = _mlContext.Transforms.Concatenate("Features", nameof(TrainingData.Weight), nameof(TrainingData.RateOfPerceivedExertion), nameof(TrainingData.Day))
                                .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(TrainingData.NumberOfRepetitions), maximumNumberOfIterations: 100));
        _repetitionsModel = repetitionsPipeline.Fit(dataView);
    }

    #region Public methods

    public float PredictWeight(int numberOfRepetitions, float rateOfPerceivedExertion, float day)
    {
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<TrainingData, WeightPrediction>(_weightModel);
        var prediction = predictionEngine.Predict(new TrainingData
        {
            NumberOfRepetitions = numberOfRepetitions,
            RateOfPerceivedExertion = rateOfPerceivedExertion,
            Day = day
        });

        return prediction.PredictedWeight;
    }

    public float PredictRepetitions(float weight, float rateOfPerceivedExertion, float day)
    {
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<TrainingData, RepetitionsPrediction>(_repetitionsModel);
        var prediction = predictionEngine.Predict(new TrainingData
        {
            Weight = weight,
            RateOfPerceivedExertion = rateOfPerceivedExertion,
            Day = day
        });

        return prediction.PredictedRepetitions;
    }

    #endregion
}
