using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoRank.AI.NLP.LanguageDetection.Application.Dtos
{
    public class PredictionResponseDto
    {
        public string Code { get; set; } = null!;
        public string Language { get; set; } = null!;
        public float Score { get; set; } = 0;
    }
}
