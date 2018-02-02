using System;
using System.Collections.Generic;

namespace demoWebAppCore.Models
{
    public partial class StudentsExams
    {
        public int Ppkfkstudent { get; set; }
        public int Ppkfkexam { get; set; }
        public int Grade { get; set; }

        public Exams PpkfkexamNavigation { get; set; }
        public Students PpkfkstudentNavigation { get; set; }
    }
}
