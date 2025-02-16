using Microsoft.AspNetCore.Mvc;
using VectoRank.AI.NLP.LanguageDetection.Application.Services;

namespace VectoRank.AI.NLP.LanguageDetection.WebApp.Controllers
{
    [Route("api/v1/language-detection")]
    [ApiController]
    public class LanguageDetectionController : ControllerBase
    {
        private readonly IPredictionService _predictionService;
        public LanguageDetectionController(IPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [HttpGet("detect")]
        public async Task<IActionResult> Detect(string text)
        {
            var predictionResult = _predictionService.Predict(text);
            return Ok(predictionResult);
        }
    }
}
