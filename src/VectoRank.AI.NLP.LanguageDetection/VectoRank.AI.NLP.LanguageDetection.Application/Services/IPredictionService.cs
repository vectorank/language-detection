using VectoRank.AI.NLP.LanguageDetection.Application.Dtos;

namespace VectoRank.AI.NLP.LanguageDetection.Application.Services
{
    /// <summary>
    /// Defines the contract for a language detection service that predicts the language of the input text.
    /// </summary>
    public interface IPredictionService
    {
        /// <summary>
        /// Detects the language of the provided input text.
        /// </summary>
        /// <param name="text">The input text whose language is to be detected.</param>
        /// <returns>A <see cref="PredictionResponseDto"/> containing the detected language and other related information.</returns>
        PredictionResponseDto Predict(string text);
    }

}
