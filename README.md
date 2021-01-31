# SchoolDistrictGradesCalculator

[Output File](SchoolDistrictScoresCalculator/Resources/Output/SchoolScoresOutput.txt) 

All code is under SchoolDistrictScoresCalculator folder

[ClassGradesFileProcessor](SchoolDistrictScoresCalculator/ClassGradesFileProcessor.cs) - Transforms input files to data models

[GradesCalculator](SchoolDistrictScoresCalculator/GradesCalculator.cs) - Computes stats like average, median, percentile for class and school

[ClassGradesFileGenerator](SchoolDistrictScoresCalculator/ClassGradesFileGenerator.cs)  - Generates output bases on the stats

[Program](SchoolDistrictScoresCalculator/Program.cs)  - Uses Processor, Calculator, Generator to achieve the desired result

[DataModels](SchoolDistrictScoresCalculator/DataModels) -  - Folders contains all the data models used
