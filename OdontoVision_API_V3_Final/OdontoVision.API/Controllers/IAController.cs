using Microsoft.AspNetCore.Mvc;
using OdontoVision.ML;
using OdontoVision.ML.Models;

namespace OdontoVision.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IAController : ControllerBase
{
    private readonly FraudModelService _fraudModelService;

    public IAController(FraudModelService fraudModelService)
    {
        _fraudModelService = fraudModelService;
    }

    [HttpPost("DetectFraud")]
    public ActionResult DetectFraud([FromBody] FraudInput input)
    {
        var prediction = _fraudModelService.Predict(input);
        return Ok(new
        {
            input.Amount,
            prediction.IsFraud,
            prediction.Probability,
            prediction.Score
        });
    }
}
