using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;
using Kinematic_Solver_for_Windows.Exceptions;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class FinVelocityTests
    {
        [TestMethod]
        public void Basic()
        {
            IterateVariables(337.5, 5, 15, 30, 105);
        }

        [TestMethod]
        public void Decimals()
        {
            IterateVariables(46.75, 5.5, 2, 3, 14);
        }

        [TestMethod]
        public void Negative()
        {
            IterateVariables(-95, 5, -6, -4, -34);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScenarioException))]
        public void ImpossibleScenario()
        {
            SolveFinVelocity com = InitTest(1, -1, -5, 0.5, 1);
            com.CalculateFinVelocity();   
       }

        private static SolveFinVelocity InitTest(double D, double T, double A, double Vi, int skip)
        {
            SolveFinVelocity compute = new SolveFinVelocity();
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
                compute.Vi = Vi;
            }

            return compute;
        }

        private static void IterateVariables(double D, double T, double A, double Vi, double ans)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                SolveFinVelocity com = InitTest(D, T, A, Vi, i);

                try
                {
                    Assert.AreEqual(ans, com.CalculateFinVelocity(), "Variable Skipped #: " + i.ToString());
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
