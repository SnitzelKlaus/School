using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLMedarbejderNedslidning.ML.Objects
{
    public class EmploymentHistory
    {
        [LoadColumn(0)]
        public float DurationInMonths { get; set; }
        [LoadColumn(1)]
        public bool IsMarried { get; internal set; }
        [LoadColumn(2)]
        public bool BSDegree { get; internal set; }
        [LoadColumn(3)]
        public bool MSDegree { get; internal set; }
        [LoadColumn(4)]
        public float YearsExperience { get; set; }
        [LoadColumn(5)]
        public float AgeAtHire { get; set; }
        [LoadColumn(6)]
        public float HasKids { get; set; }
        [LoadColumn(7)]
        public float WithinMonthOfVesting { get; set; }
        [LoadColumn(8)]
        public float DeskDecorations { get; set; }
        [LoadColumn(9)]
        public float LongCommute { get; set; }
    }
}
