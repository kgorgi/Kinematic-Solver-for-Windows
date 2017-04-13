using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;

namespace KinematicComputerUnitTests
{
    [TestClass]
    public class DisplacementTests
    {
        [TestMethod]
        public void Basic()
        {
            IterateVariables(5, 15, 30, 105, 337.5);
        }

        [TestMethod]
        public void Decimals()
        {
            IterateVariables(5.5, 2, 3, 14, 46.75);
        }

        [TestMethod]
        public void Negative()
        {
            IterateVariables(5, -6, -4, -34, -95);
        }

        private static SolveDisplacement InitTest(double T, double A, double Vi, double Vf, int skip)
        {
            SolveDisplacement compute = new SolveDisplacement();
            if(skip != 1)
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
            if (skip != 4)
            {
                compute.Vf = Vf;
            }

            return compute;
        }

        private static void IterateVariables(double T, double A, double Vi, double Vf, double ans)
        {
            int i;
            for (i = 1; i < 5; i++)
            {
                SolveDisplacement com = InitTest(T, A, Vi, Vf, i);
                Console.WriteLine(com.CalcuateDisplacement());
                Assert.AreEqual(ans, com.CalcuateDisplacement());
            }
        }
    }
}
