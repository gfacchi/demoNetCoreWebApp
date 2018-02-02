using System;
using System.Collections.Generic;

namespace demoWebAppCore.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentsExams = new HashSet<StudentsExams>();
        }

        public int Pkstudent { get; set; }
        public string Name { get; set; }

        public ICollection<StudentsExams> StudentsExams { get; set; }
    }
}
