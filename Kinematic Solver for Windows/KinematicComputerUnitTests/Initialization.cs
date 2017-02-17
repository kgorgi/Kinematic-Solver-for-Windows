using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinematic_Solver_for_Windows;

namespace KinematicComputerUnitTests
{
    //Test Class for the Initalization of KinematicComputer (also checks edge cases)

    [TestClass]
    public class Initialization
    {
        [TestMethod]
        public void InitDisplacement()
        {
            double displace = 100;
            KinematicComputer compute = new KinematicComputer();
            compute.Displacement = displace;
            Assert.AreEqual(displace, compute.Displacement, 0, "Displacement failed to be set correctly.");
        }

        [TestMethod]
        public void InitTime()
        {
            double time = 5;
            KinematicComputer compute = new KinematicComputer();
            compute.Time = time;
            Assert.AreEqual(time, compute.Time, 0, "Time failed to be set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitTimeException()
        {
            double time = 0;
            KinematicComputer compute = new KinematicComputer();
            compute.Time = time;
        }

        [TestMethod]
        public void InitAcceleration()
        {
            double accel = 52;
            KinematicComputer compute = new KinematicComputer();
            compute.Acceleration = accel;
            Assert.AreEqual(accel, compute.Acceleration, 0, "Acceleration failed to be set correctly.");
        }

        [TestMethod]
        public void InitInitialVelocity()
        {
            double initVelo = -30;
            KinematicComputer compute = new KinematicComputer();
            compute.InitVelocity = initVelo;
            Assert.AreEqual(initVelo, compute.InitVelocity, 0, "Initial Velocity failed to be set correctly.");
        }

        [TestMethod]
        public void InitFinalVelocity()
        {
            double finVelo = 1997;
            KinematicComputer compute = new KinematicComputer();
            compute.FinVelocity = finVelo;
            Assert.AreEqual(finVelo, compute.FinVelocity, 0, "Final Velocity failed to be set correctly.");
        }
    }
}
