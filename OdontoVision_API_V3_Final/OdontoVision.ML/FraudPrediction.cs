using Microsoft.ML.Data;

namespace OdontoVision.ML.Models;

public class FraudPrediction
{
    [ColumnName("PredictedLabel")]
    public bool IsFraud { get; set; }

    public float Score { get; set; }

    public float Probability { get; set; }
}
