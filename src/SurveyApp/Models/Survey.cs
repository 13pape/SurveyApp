using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<Question> QuestionList { get; set; }
    }
}
