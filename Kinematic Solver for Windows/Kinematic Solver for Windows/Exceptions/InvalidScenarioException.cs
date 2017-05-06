using System;

namespace Kinematic_Solver_for_Windows.Exceptions
{
    public class InvalidScenarioException:Exception
    {
        public InvalidScenarioException()
        {
        }

        public InvalidScenarioException(string message)
        : base(message)
        {

        }
    }
}
