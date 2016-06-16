using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Models
{
    public class UserAnswer
    {
        public int UserAnswerId { get; set; }
        public int AnswerId { get; set; }
        public int SurveyUserId { get; set; }
    }
}
