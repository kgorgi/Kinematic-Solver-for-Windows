using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
