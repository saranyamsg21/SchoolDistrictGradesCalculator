using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDistrictGradesCalculator.DataModels
{
    public class SchoolClass
    {
        public SchoolClass()
        {
            Students = new List<Student>();
        }
        public string ClassLevel { get; set; }
        public string ClassName { get; set; }
        public IList<Student> Students {get; private set;}
    }
}
