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
            SolveTime ST = InitTest(-1, 0, 5, 5, 0);
            ST.CalculateTime();
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroVelo()
        {
            SolveTime ST = InitTest(-1, 0, 5, -5, 0);
            ST.CalculateTime();
        }

        private static SolveTime InitTest(double D, double A, double Vi, double Vf, int skip)
        {
            SolveTime compute = new SolveTime();
            if (skip != 0)
            {
                compute.D = D;
            }
            if (skip != 1)
            {
                compute.A = A;
            }
            if (skip != 2)
            {
                compute.Vi = Vi;
            }
            if (skip != 3)
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double D, double A, double Vi, double Vf, double ans)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                SolveTime com = InitTest(D, A, Vi, Vf, i);
                try
                {
                    Assert.AreEqual(ans, com.CalculateTime(), "Variable Skipped #: " + i.ToString());
                }
                catch (TwoPossibleAnswersException ex)
                {
                    if(ex.FirstValue != ans && ex.SecondValue != ans)
                    {
                        Assert.Fail();
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
