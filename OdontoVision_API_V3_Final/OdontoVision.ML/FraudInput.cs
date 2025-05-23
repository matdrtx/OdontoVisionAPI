using Microsoft.ML.Data;

namespace OdontoVision.ML.Models;

public class FraudInput
{
    [LoadColumn(0)]
    public float Amount { get; set; }

    [LoadColumn(1)]
    public float TimeSinceLastTransaction { get; set; }

    [LoadColumn(2)]
    public bool IsForeignTransaction { get; set; }

    [LoadColumn(3)]
    public bool IsHighRiskCountry { get; set; }
}
