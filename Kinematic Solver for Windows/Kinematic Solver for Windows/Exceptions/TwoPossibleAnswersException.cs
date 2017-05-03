using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematic_Solver_for_Windows.Exceptions
{
    public class TwoPossibleAnswersException:Exception
    {
        private double _firstValue;
        private double _secondValue;
        public TwoPossibleAnswersException()
        {
        }

        public TwoPossibleAnswersException(string message)
        : base(message)
        {

        }

        public TwoPossibleAnswersException(double value1, double value2)
        {
            this._firstValue = value1;
            this._secondValue = value2;
        }

        public double FirstValue
        {
            get { return this._firstValue; }
        }

        public double SecondValue
        {
            get { return this._secondValue; }
        }
    }
}
