using SchoolDistrictGradesCalculator.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SchoolDistrictGradesCalculator
{
    class ClassGradesFileGenerator
    {
        public void Generate(SchoolScores schoolScores, string outputFileName)
        {
            using (var sw = new StreamWriter(outputFileName, true))
            {
                sw.WriteLine("----- School level data ----");
                sw.WriteLine();
                sw.WriteLine("---------------------------");
                sw.WriteLine("Highest performing class considering averages only: {0}", schoolScores.HighestPerformingClass);
                sw.WriteLine("(new) Highest performing student across all classes: {0}", schoolScores.HighestPerformingStudent.Name);
                sw.WriteLine("---------------------------");
                sw.WriteLine("Students Average across all classes: {0}", schoolScores.SchoolAverage);
                sw.WriteLine("// In V2 school level median and percentile will be available.");

                sw.WriteLine();
                sw.WriteLine("----- Class level data ----");
                foreach (var classScores in schoolScores.ClassScores)
                {
                    sw.WriteLine();
                    sw.WriteLine("Class Name: {0}", classScores.ClassName);
                    sw.WriteLine("Class Average: {0}", classScores.ClassAverage);
                    sw.WriteLine("(new) Class Median: {0}", classScores.ClassMedian);
                    sw.WriteLine("(new) Class top student: {0}", classScores.TopStudent.Name);
                    sw.WriteLine("Total students: {0}", classScores.TotalStudents);
                    sw.WriteLine("Total students considered for average: {0}", classScores.TotalStudentsForAverageCalc);
                    sw.WriteLine("Ignored students: {0}", string.Join(", ", classScores.IgnoredStudents.Select(x => x.Name)));
                    sw.WriteLine();
                    sw.WriteLine();
                }
            }
        }
    }
}
