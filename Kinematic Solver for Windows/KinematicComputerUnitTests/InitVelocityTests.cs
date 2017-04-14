using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;
using Kinematic_Solver_for_Windows.Exceptions;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class InitVelocityTests
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
            SolveInitalVelocity com = InitTest(1, -1, 1, 0.5, 1);
            com.CalculateInitialVelocity();   
       }

        private static SolveInitalVelocity InitTest(double D, double T, double A, double Vf, int skip)
        {
            SolveInitalVelocity compute = new SolveInitalVelocity();
            if (skip != 0)
            {
                compute.D = D;
            }
            if (skip != 1)
            {
                compute.T = T;
            }
            if (skip != 2)
            {
                compute.A = A;
            }
            if (skip != 3)
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double D, double T, double A, double Vf, double ans)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                SolveInitalVelocity com = InitTest(D, T, A, Vf, i);

                try
                {
                    Assert.AreEqual(ans, com.CalculateInitialVelocity(), "Variable Skipped #: " + i.ToString());
                }
                catch (TwoPossibleAnswersException ex)
                {
                    double ansABS = Math.Abs(ans);
                    Assert.AreEqual(ansABS, Math.Abs(ex.FirstValue), "Variable Skipped #: " + i.ToString());
                    Assert.AreEqual(ansABS, Math.Abs(ex.SecondValue), "Variable Skipped #: " + i.ToString());
                }   
            }
        }
    }
}
