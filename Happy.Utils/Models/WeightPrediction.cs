using Microsoft.ML.Data;

namespace Happy.Utils.Models;

public class WeightPrediction
{
    [ColumnName("Score")]
    public float PredictedWeight { get; set; }
}
