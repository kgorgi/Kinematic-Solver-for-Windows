using System;

namespace Kinematic_Solver_for_Windows.Exceptions
{
    public class TwoPossibleAnswersException:Exception
    {
        private double firstValue;
        private double secondValue;
        public TwoPossibleAnswersException()
        {

        }

        public TwoPossibleAnswersException(string message)
        : base(message)
        {

        }

        public TwoPossibleAnswersException(double value1, double value2)
        {
            this.firstValue = value1;
            this.secondValue = value2;
        }

        public double FirstValue
        {
            get { return this.firstValue; }
        }

        public double SecondValue
        {
            get { return this.secondValue; }
        }
    }
}
