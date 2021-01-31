using SchoolDistrictGradesCalculator.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDistrictGradesCalculator
{
    class GradesCalculator
    {
        public SchoolScores CalcuateScores (IList<SchoolClass> schoolClasses)
        {
            var schoolScores = new SchoolScores();

            foreach (var schoolClass in schoolClasses)
            {
                var classScores = new ClassScores();
                classScores.ClassName = schoolClass.ClassName;

                var totalStudents = schoolClass.Students.Count();
                var scores = 0;
                Student topStudent = null;
                foreach (var student in schoolClass.Students)
                {
                    if(student.Grade == 0)
                    {
                        classScores.IgnoredStudents.Add(student);
                        totalStudents--;
                    }
                    else
                    {
                        if(topStudent == null || topStudent.Grade < student.Grade)
                        {
                            topStudent = student;
                        }
                        scores += (int)student.Grade;
                    }
                }

                float classAverage = (float)scores / totalStudents;
                classScores.ClassAverage = MathF.Round(classAverage, 1);
                classScores.ClassMedian = CalcuateMedian(schoolClass.Students);
                classScores.TopStudent = topStudent;
                classScores.TotalStudentsForAverageCalc = totalStudents;
                classScores.TotalStudents = schoolClass.Students.Count();

                schoolScores.ClassScores.Add(classScores);
            }

            string topClass = null;
            float topClassAverage = 0;
            Student topSchoolStudent = null;
            float classAverages = 0;
            foreach (var classScore in schoolScores.ClassScores)
            {
                classAverages += classScore.ClassAverage;
                if(topClassAverage < classScore.ClassAverage)
                {
                    topClassAverage = classScore.ClassAverage;
                    topClass = classScore.ClassName;
                }

                if(topSchoolStudent == null || topSchoolStudent.Grade < classScore.TopStudent.Grade)
                {
                    topSchoolStudent = classScore.TopStudent;
                }
            }

            schoolScores.HighestPerformingClass = topClass;
            schoolScores.HighestPerformingStudent = topSchoolStudent;
            schoolScores.SchoolAverage = MathF.Round(classAverages / schoolScores.ClassScores.Count(), 1);

            return schoolScores;
        }

        private float CalcuateMedian(IList<Student> students)
        {
            int total = students.Count();
            int pos = (total % 2 == 0) ? total / 2 : (total + 1) / 2;
            pos = pos > 0 ? pos -1 : 0;
            return students.OrderBy(x => x.Grade).ToArray()[pos].Grade;
        }
    }
}
