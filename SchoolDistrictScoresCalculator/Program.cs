using SchoolDistrictGradesCalculator.DataModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolDistrictGradesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileProcessor = new ClassGradesFileProcessor();
            var gradesCalculator = new GradesCalculator();
            var fileGenerator = new ClassGradesFileGenerator();

            //Process all the input files
            var schoolClasses = new List<SchoolClass>();
            DirectoryInfo di = new DirectoryInfo("Resources\\Input");
            FileInfo[] files = di.GetFiles("*.csv");

            foreach (var file in files)
            {
                schoolClasses.Add(fileProcessor.ProcessClass(file));
            }
            
            //Process class grades
            var schoolScores = gradesCalculator.CalcuateScores(schoolClasses);

            //Generate output file
            fileGenerator.Generate(schoolScores, "SchoolScoresOutput.txt");
        }
    }
}
