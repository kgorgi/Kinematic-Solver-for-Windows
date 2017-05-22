using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;
using Kinematic_Solver_for_Windows.Exceptions;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Basic()
        {
            IterateVariables(337.5, 15, 30, 105, 5);
        }

        [TestMethod]
        public void Decimals()
        {
            IterateVariables(46.75, 2, 3, 14, 5.5);
        }

        [TestMethod]
        public void Negative()
        {
            IterateVariables(-95, -6, -4, -34, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroAccel()
        {
            SolveTime ST = InitTest(-1, 0, 5, 5, 'D');
            ST.CalculateTime();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidScenarioException))]
        public void InvalidScenario()
        {
            SolveTime ST = InitTest(-1, 13, 5, 2, 'D');
            ST.CalculateTime();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroVelo()
        {
            SolveTime ST = InitTest(-1, 5, 5, -5, 'A');
            ST.CalculateTime();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroInitVeloQuad()
        {
            SolveTime ST = InitTest(5, 0, 0, -1, 'F');
            ST.CalculateTime();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroFinVeloQuad()
        {
            SolveTime ST = InitTest(5, 0, -1, 0, 'I');
            ST.CalculateTime();
        }

        /* For the Parameter Skip:
         * Displacement = D
         * Acceleration = A
         * Initial Velocity = I
         * Final Velocity = F
         */
        private static SolveTime InitTest(double D, double A, double Vi, double Vf, char skip)
        {
            SolveTime compute = new SolveTime();
            if (skip != 'D')
            {
                compute.D = D;
            }
            if (skip != 'A')
            {
                compute.A = A;
            }
            if (skip != 'I')
            {
                compute.Vi = Vi;
            }
            if (skip != 'F')
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double D, double A, double Vi, double Vf, double ans)
        {
            char[] skip = { 'D', 'A', 'I', 'F' };

            int i;
            for (i = 0; i < 4; i++)
            {
                SolveTime com = InitTest(D, A, Vi, Vf, skip[i]);
                try
                {
                    Assert.AreEqual(ans, com.CalculateTime(), "Variable Skipped: " + skip[i]);
                }
                catch (TwoPossibleAnswersException ex)
                {
                    if (ex.FirstValue != ans && ex.SecondValue != ans)
                    {
                        string msg = "1st Value: " + ex.FirstValue.ToString() + " 2nd Value: " + ex.SecondValue.ToString() + "\n";
                        Assert.Fail(msg + "Variable Skipped: " + skip[i]);
                    }
                }
            }
        }
    }

    [TestClass]
    public class QuadraticTests
    {
        [TestMethod]
        public void SameRoots()
        {

            Assert.AreEqual(0, SolveTime.QuadEquation(1, 0, 0));
        }

        [TestMethod]
        public void DifferentRoots()
        {
            try
            {
                SolveTime.QuadEquation(1, -3, 2);
            }
            catch (TwoPossibleAnswersException ex)
            {
                Assert.AreEqual(2, ex.FirstValue);
                Assert.AreEqual(1, ex.SecondValue);
            }
        }

        [TestMethod]
        public void Root1()
        {
            Assert.AreEqual(1, SolveTime.QuadEquation(1, 0, -1));
        }

        [TestMethod]
        public void Root2()
        {
            Assert.AreEqual(1, SolveTime.QuadEquation(-1, 0, 1));
        }
    }
}