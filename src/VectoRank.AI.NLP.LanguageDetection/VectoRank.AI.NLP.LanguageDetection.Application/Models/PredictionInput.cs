using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoRank.AI.NLP.LanguageDetection.Application.Models
{
    public class PredictionInput
    {
        [Column("Label")]
        public string LangCode { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
