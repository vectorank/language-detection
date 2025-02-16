using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoRank.AI.NLP.LanguageDetection.Application.Models
{
    public class PredictionOutput
    {
        public float[] Score { get; set; } = null!;
        [Column("PredictedLabel")]
        public string PredictedLabel { get; set; } = null!;
    }
}
