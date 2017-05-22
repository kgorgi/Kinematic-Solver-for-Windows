using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;
using Kinematic_Solver_for_Windows.Exceptions;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class InitialVelocityTests
    {
        [TestMethod]
        public void Basic()
        {
            IterateVariables(337.5, 5, 15, 105, 30);
        }

        [TestMethod]
        public void Decimals()
        {
            IterateVariables(46.75, 5.5, 2, 14, 3);
        }

        [TestMethod]
        public void Negative()
        {
            IterateVariables(-95, 5, -6, -34, -4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScenarioException))]
        public void ImpossibleScenario()
        {
            SolveInitialVelocity com = InitTest(1, -1, 1, 0.5, 'T');
            com.CalculateInitialVelocity();   
        }
        
        /* For the Parameter Skip:
         * Displacement = D
         * Time = T
         * Acceleration = A
         * Final Velocity = F
         */
        private static SolveInitialVelocity InitTest(double D, double T, double A, double Vf, char skip)
        {
            SolveInitialVelocity compute = new SolveInitialVelocity();
            if (skip != 'D')
            {
                compute.D = D;
            }
            if (skip != 'T')
            {
                compute.T = T;
            }
            if (skip != 'A')
            {
                compute.A = A;
            }
            if (skip != 'F')
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double D, double T, double A, double Vf, double ans)
        {
            char[] skip = { 'D', 'T', 'A', 'F' };

            int i;
            for (i = 0; i < 4; i++)
            {
                SolveInitialVelocity com = InitTest(D, T, A, Vf, skip[i]);

                try
                {
                    Assert.AreEqual(ans, com.CalculateInitialVelocity(), "Variable Skipped: " + skip[i]);
                }
                catch (TwoPossibleAnswersException ex)
                {
                    double ansABS = Math.Abs(ans);
                    Assert.AreEqual(ansABS, Math.Abs(ex.FirstValue), "Variable Skipped #: " + skip[i]);
                    Assert.AreEqual(ansABS, Math.Abs(ex.SecondValue), "Variable Skipped #: " + skip[i]);
                }   
            }
        }
    }
}
