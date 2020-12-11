using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name) : base (name)
        {
            Type = Enums.GradeBookType.Ranked;
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
            return 'F';
        }
    }
}
