using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows.Exceptions
{
    public class TwoPossibleAnswersException:Exception
    {
        private double _cValue;
        public TwoPossibleAnswersException()
        {
        }

        public TwoPossibleAnswersException(string message)
        : base(message)
        {

        }

        public TwoPossibleAnswersException(double value)
        {
            _cValue = value;
        }

        public double ConflictingValue
        {
            get { return _cValue; }
        }

    }
}
