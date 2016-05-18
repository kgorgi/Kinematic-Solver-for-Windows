using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinematic_Solver_for_Windows
{
    public partial class KinematicSolverGUI : Form
    {
        public KinematicSolverGUI()
        {
            InitializeComponent();
            displacementBtn.Select();
            displacementTextBox.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ratioButtonClicked(object sender, EventArgs e)
        {
            displacementTextBox.Enabled = true;
            timeTextBox.Enabled = true;
            accelTextBox.Enabled = true;
            initVeloTextBox.Enabled = true;
            finVeloTextBox.Enabled = true;

            RadioButton btn = (RadioButton)sender;
            switch (btn.Name)
            {
                case "displacementBtn":
                    displacementTextBox.Enabled = false;
                    displacementTextBox.Text = "";
                    break;
                case "timeBtn":
                    timeTextBox.Enabled = false;
                    timeTextBox.Text = "";
                    break;
                case "accelBtn":
                    accelTextBox.Enabled = false;
                    accelTextBox.Text = "";
                    break;
                case "initVeloBtn":
                    initVeloTextBox.Enabled = false;
                    initVeloTextBox.Text = "";
                    break;
                case "finVeloBtn":
                    finVeloTextBox.Enabled = false;
                    finVeloTextBox.Text = "";
                    break;
                default:
                    initVeloTextBox.Enabled = false;
                    initVeloTextBox.Text = "";
                break;
            }           
        }
    }
}
