using System;
using System.Collections.Generic;

namespace demoWebAppCore.Models
{
    public partial class Exams
    {
        public Exams()
        {
            StudentsExams = new HashSet<StudentsExams>();
        }

        public int Pkexam { get; set; }
        public DateTime ExDate { get; set; }
        public string Subject { get; set; }

        public ICollection<StudentsExams> StudentsExams { get; set; }
    }
}
