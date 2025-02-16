using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectoRank.AI.NLP.LanguageDetection.Application.Dtos;
using VectoRank.AI.NLP.LanguageDetection.Application.Models;
using static System.Net.Mime.MediaTypeNames;

namespace VectoRank.AI.NLP.LanguageDetection.Application.Services
{
    public class PredictionService : IPredictionService
    {
        private readonly IConfiguration _configuration;
        private MLContext _mlContext;
        private ITransformer _model;
        private DataViewSchema _modelSchema;
        private PredictionEngine<PredictionInput, PredictionOutput> _predictionEngine;
        private Dictionary<string, string> languageCodePair;
        private static readonly object lockObject = new object();
        public PredictionService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mlContext = new MLContext(seed: 1);
            LoadModel();
            LoadLanguageCodePairs();
        }
        private void LoadModel()
        {
            var modelName = _configuration["ModelName"];
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Models", modelName + ".model");
            if (File.Exists(filePath))
            {
                _model = _mlContext.Model.Load(filePath, out _modelSchema);
                _predictionEngine = _mlContext.Model.CreatePredictionEngine<PredictionInput, PredictionOutput>(_model, _modelSchema);
            }
            else
            {
                throw new Exception("Model file not found");
            }
        }
        private void LoadLanguageCodePairs()
        {
            languageCodePair = new Dictionary<string, string>();
            languageCodePair.Add("cmn", "Mandarin Chinese");
            languageCodePair.Add("deu", "German");
            languageCodePair.Add("rus", "Russian");
            languageCodePair.Add("fra", "French");
            languageCodePair.Add("eng", "English");
            languageCodePair.Add("jpn", "Japanese");
            languageCodePair.Add("spa", "Spanish");
            languageCodePair.Add("ita", "Italian");
            languageCodePair.Add("vie", "Vietnamese");
            languageCodePair.Add("nld", "Dutch");
            languageCodePair.Add("epo", "Esperanto");
            languageCodePair.Add("por", "Portuguese");
            languageCodePair.Add("tur", "Turkish");
            languageCodePair.Add("heb", "Hebrew");
            languageCodePair.Add("hun", "Hungarian");
            languageCodePair.Add("ell", "Modern Greek (1453-)");
            languageCodePair.Add("ara", "Arabic");
            languageCodePair.Add("fin", "Finnish");
            languageCodePair.Add("bul", "Bulgarian");
            languageCodePair.Add("swe", "Swedish");
            languageCodePair.Add("ukr", "Ukrainian");
            languageCodePair.Add("ces", "Czech");
            languageCodePair.Add("pol", "Polish");
            languageCodePair.Add("lat", "Latin");
            languageCodePair.Add("ron", "Romanian");
            languageCodePair.Add("srp", "Serbian");
            languageCodePair.Add("dan", "Danish");
            languageCodePair.Add("pes", "Iranian Persian");
            languageCodePair.Add("lit", "Lithuanian");
            languageCodePair.Add("mkd", "Macedonian");
            languageCodePair.Add("tok", "Toki Pona");
            languageCodePair.Add("ina", "Interlingua (International Auxiliary Language Association)");
            languageCodePair.Add("tlh", "Klingon");
            languageCodePair.Add("kab", "Kabyle");
            languageCodePair.Add("ber", "Berber languages");
            languageCodePair.Add("mar", "Marathi");
            languageCodePair.Add("lfn", "Lingua Franca Nova");
        }
        public PredictionResponseDto Predict(string text)
        {
            lock (lockObject)
            {
                var prediction = _predictionEngine.Predict(new PredictionInput { Text = text });
                return new PredictionResponseDto { 
                    Code = prediction.PredictedLabel,
                    Language = languageCodePair[prediction.PredictedLabel],
                    Score = prediction.Score.Max()
                };
            }
        }
    }
}
