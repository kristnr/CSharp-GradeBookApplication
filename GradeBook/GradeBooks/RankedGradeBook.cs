using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name) : base (name)
        {
            Type = GradeBookType.Ranked;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            var threshold = (int)Math.Ceiling(Students.Count * 2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A'
            } else if (grades[(threshold*2) - 1] <= averageGrade) {
                return 'B';
            } else if (grades[(threshold*3) - 1] <= averageGrade) {
                return 'C';
            } else if (grades[(threshold*4) - 1] <= averageGrade) {
                return 'D';
            }
            return 'F';
        }
    }
}
