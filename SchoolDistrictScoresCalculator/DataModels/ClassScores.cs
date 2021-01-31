using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDistrictGradesCalculator.DataModels
{
    public class ClassScores
    {
        public ClassScores()
        {
            IgnoredStudents = new List<Student>();
        }
        public string ClassName { get; set; }
        public int TotalStudents { get; set; }
        public int TotalStudentsForAverageCalc { get; set; }
        public IList<Student> IgnoredStudents { get; private set; }
        public Student TopStudent { get; set; }
        public float ClassAverage { get; set; }
        public float ClassMedian { get; set; }

    }
}
