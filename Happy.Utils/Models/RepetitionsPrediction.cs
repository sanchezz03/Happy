using Microsoft.ML.Data;

namespace Happy.Utils.Models;

public class RepetitionsPrediction
{
    [ColumnName("Score")]
    public float PredictedRepetitions { get; set; }
}
