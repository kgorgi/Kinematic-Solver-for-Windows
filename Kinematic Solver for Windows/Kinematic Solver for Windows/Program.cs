using System;
using System.Windows.Forms;

namespace Kinematic_Solver_for_Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KinematicSolverGUI());
        }
    }
}
