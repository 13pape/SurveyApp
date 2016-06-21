
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class SurveyUser
    {
        public int SurveyUserId { get; set; }
        public int AgeId { get; set; }
        public int SexId { get; set; }

        public ICollection<UserAnswer> UserAnswerList { get; set; }
    }
}
