using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDistrictGradesCalculator.DataModels
{
    public class SchoolScores
    {
        public SchoolScores()
        {
            ClassScores = new List<ClassScores>();
        }

        public string HighestPerformingClass { get; set; }
        public Student HighestPerformingStudent { get; set; }
        public float SchoolAverage { get; set; }

        // To Add 
        //public float SchoolMedian { get; set; }

        //To Add
        //School Percentile Ranges across all classes TBD    
        public IList<ClassScores> ClassScores { get; private set; }
    }
}
