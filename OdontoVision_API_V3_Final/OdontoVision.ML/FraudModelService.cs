using System;
using Microsoft.ML;
using OdontoVision.ML.Models;
using System.IO;


namespace OdontoVision.ML;

public class FraudModelService
{
    private readonly MLContext _mlContext;
    private readonly ITransformer _model;
    private readonly PredictionEngine<FraudInput, FraudPrediction> _predictionEngine;

    public FraudModelService()
    {
        _mlContext = new MLContext();

        var modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MLModel.zip");
        using var stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        _model = _mlContext.Model.Load(stream, out _);
        _predictionEngine = _mlContext.Model.CreatePredictionEngine<FraudInput, FraudPrediction>(_model);
    }

    public FraudPrediction Predict(FraudInput input)
    {
        return _predictionEngine.Predict(input);
    }
}
