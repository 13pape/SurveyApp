using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class SurveyQuestion
    {
        public Survey Survey {get;set;}
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
