using SchoolDistrictGradesCalculator.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchoolDistrictGradesCalculator
{
    public class ClassGradesFileProcessor
    {
        public SchoolClass ProcessClass(FileInfo file)
        {
            if (file == null)
                throw new ArgumentException("Invalid file");

            var schoolClass = new SchoolClass();            

            using (var sr = new StreamReader(file.FullName))
            {           
                //ignore first line which is a header for processing
                var header = sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var namegrade = line.Split(',');
                        //Validate Name and Grade
                        if (namegrade.Length != 2)
                        {
                            throw new InvalidDataException("Class file Name, Grade is incorrect");
                        }

                        if (string.IsNullOrEmpty(namegrade[0]))
                        {
                            throw new InvalidDataException("Class file has invalid name");
                        }

                        float score;
                        if (!float.TryParse(namegrade[1], out score))
                        {
                            throw new InvalidDataException("Class file has invalid score");
                        }

                        schoolClass.Students.Add(new Student { Name = namegrade[0], Grade = score });

                    }
                }
            }

            schoolClass.ClassName = Path.GetFileNameWithoutExtension(file.FullName);

            return schoolClass;
        }
    }
}
