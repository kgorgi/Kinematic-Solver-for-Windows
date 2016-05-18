namespace Kinematic_Solver_for_Windows
{
    partial class KinematicSolverGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KinematicSolverGUI));
            this.displacementTextBox = new System.Windows.Forms.TextBox();
            this.displacementLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.accelTextBox = new System.Windows.Forms.TextBox();
            this.initVeloTextBox = new System.Windows.Forms.TextBox();
            this.finVeloTextBox = new System.Windows.Forms.TextBox();
            this.calcBtn = new System.Windows.Forms.Button();
            this.displacementBtn = new System.Windows.Forms.RadioButton();
            this.finVeloBtn = new System.Windows.Forms.RadioButton();
            this.initVeloBtn = new System.Windows.Forms.RadioButton();
            this.accelBtn = new System.Windows.Forms.RadioButton();
            this.timeBtn = new System.Windows.Forms.RadioButton();
            this.displacementUnitLabel = new System.Windows.Forms.Label();
            this.timeUnitLabel = new System.Windows.Forms.Label();
            this.accelUnit1Label = new System.Windows.Forms.Label();
            this.initVeloUnitLabel = new System.Windows.Forms.Label();
            this.finVeloUnitLabel = new System.Windows.Forms.Label();
            this.accelUnit2Label = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.titleImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // displacementTextBox
            // 
            this.displacementTextBox.Location = new System.Drawing.Point(198, 204);
            this.displacementTextBox.Name = "displacementTextBox";
            this.displacementTextBox.Size = new System.Drawing.Size(214, 20);
            this.displacementTextBox.TabIndex = 0;
            // 
            // displacementLabel
            // 
            this.displacementLabel.AutoSize = true;
            this.displacementLabel.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displacementLabel.Location = new System.Drawing.Point(39, 201);
            this.displacementLabel.Name = "displacementLabel";
            this.displacementLabel.Size = new System.Drawing.Size(0, 21);
            this.displacementLabel.TabIndex = 1;
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(198, 234);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(214, 20);
            this.timeTextBox.TabIndex = 6;
            // 
            // accelTextBox
            // 
            this.accelTextBox.Location = new System.Drawing.Point(198, 260);
            this.accelTextBox.Name = "accelTextBox";
            this.accelTextBox.Size = new System.Drawing.Size(214, 20);
            this.accelTextBox.TabIndex = 7;
            // 
            // initVeloTextBox
            // 
            this.initVeloTextBox.Location = new System.Drawing.Point(198, 286);
            this.initVeloTextBox.Name = "initVeloTextBox";
            this.initVeloTextBox.Size = new System.Drawing.Size(214, 20);
            this.initVeloTextBox.TabIndex = 8;
            // 
            // finVeloTextBox
            // 
            this.finVeloTextBox.Location = new System.Drawing.Point(198, 312);
            this.finVeloTextBox.Name = "finVeloTextBox";
            this.finVeloTextBox.Size = new System.Drawing.Size(214, 20);
            this.finVeloTextBox.TabIndex = 9;
            // 
            // calcBtn
            // 
            this.calcBtn.Location = new System.Drawing.Point(358, 338);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new System.Drawing.Size(75, 23);
            this.calcBtn.TabIndex = 10;
            this.calcBtn.Text = "Calculate";
            this.calcBtn.UseVisualStyleBackColor = true;
            // 
            // displacementBtn
            // 
            this.displacementBtn.AutoSize = true;
            this.displacementBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displacementBtn.Location = new System.Drawing.Point(13, 204);
            this.displacementBtn.Name = "displacementBtn";
            this.displacementBtn.Size = new System.Drawing.Size(154, 22);
            this.displacementBtn.TabIndex = 11;
            this.displacementBtn.TabStop = true;
            this.displacementBtn.Text = " Displacement:";
            this.displacementBtn.UseVisualStyleBackColor = true;
            this.displacementBtn.CheckedChanged += new System.EventHandler(this.ratioButtonClicked);
            // 
            // finVeloBtn
            // 
            this.finVeloBtn.AutoSize = true;
            this.finVeloBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finVeloBtn.Location = new System.Drawing.Point(13, 310);
            this.finVeloBtn.Name = "finVeloBtn";
            this.finVeloBtn.Size = new System.Drawing.Size(150, 22);
            this.finVeloBtn.TabIndex = 12;
            this.finVeloBtn.TabStop = true;
            this.finVeloBtn.Text = " Final Velocity:";
            this.finVeloBtn.UseVisualStyleBackColor = true;
            this.finVeloBtn.CheckedChanged += new System.EventHandler(this.ratioButtonClicked);
            // 
            // initVeloBtn
            // 
            this.initVeloBtn.AutoSize = true;
            this.initVeloBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initVeloBtn.Location = new System.Drawing.Point(13, 283);
            this.initVeloBtn.Name = "initVeloBtn";
            this.initVeloBtn.Size = new System.Drawing.Size(159, 22);
            this.initVeloBtn.TabIndex = 13;
            this.initVeloBtn.TabStop = true;
            this.initVeloBtn.Text = " Initial Velocity:";
            this.initVeloBtn.UseVisualStyleBackColor = true;
            this.initVeloBtn.CheckedChanged += new System.EventHandler(this.ratioButtonClicked);
            // 
            // accelBtn
            // 
            this.accelBtn.AutoSize = true;
            this.accelBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accelBtn.Location = new System.Drawing.Point(13, 257);
            this.accelBtn.Name = "accelBtn";
            this.accelBtn.Size = new System.Drawing.Size(145, 22);
            this.accelBtn.TabIndex = 14;
            this.accelBtn.TabStop = true;
            this.accelBtn.Text = " Acceleration:";
            this.accelBtn.UseVisualStyleBackColor = true;
            this.accelBtn.CheckedChanged += new System.EventHandler(this.ratioButtonClicked);
            // 
            // timeBtn
            // 
            this.timeBtn.AutoSize = true;
            this.timeBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeBtn.Location = new System.Drawing.Point(13, 231);
            this.timeBtn.Name = "timeBtn";
            this.timeBtn.Size = new System.Drawing.Size(80, 22);
            this.timeBtn.TabIndex = 15;
            this.timeBtn.TabStop = true;
            this.timeBtn.Text = " Time:";
            this.timeBtn.UseVisualStyleBackColor = true;
            this.timeBtn.CheckedChanged += new System.EventHandler(this.ratioButtonClicked);
            // 
            // displacementUnitLabel
            // 
            this.displacementUnitLabel.AutoSize = true;
            this.displacementUnitLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.displacementUnitLabel.Location = new System.Drawing.Point(418, 206);
            this.displacementUnitLabel.Name = "displacementUnitLabel";
            this.displacementUnitLabel.Size = new System.Drawing.Size(24, 18);
            this.displacementUnitLabel.TabIndex = 16;
            this.displacementUnitLabel.Text = "m";
            // 
            // timeUnitLabel
            // 
            this.timeUnitLabel.AutoSize = true;
            this.timeUnitLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.timeUnitLabel.Location = new System.Drawing.Point(418, 235);
            this.timeUnitLabel.Name = "timeUnitLabel";
            this.timeUnitLabel.Size = new System.Drawing.Size(17, 18);
            this.timeUnitLabel.TabIndex = 17;
            this.timeUnitLabel.Text = "s";
            // 
            // accelUnit1Label
            // 
            this.accelUnit1Label.AutoSize = true;
            this.accelUnit1Label.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.accelUnit1Label.Location = new System.Drawing.Point(418, 262);
            this.accelUnit1Label.Name = "accelUnit1Label";
            this.accelUnit1Label.Size = new System.Drawing.Size(44, 18);
            this.accelUnit1Label.TabIndex = 18;
            this.accelUnit1Label.Text = "m/s";
            // 
            // initVeloUnitLabel
            // 
            this.initVeloUnitLabel.AutoSize = true;
            this.initVeloUnitLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.initVeloUnitLabel.Location = new System.Drawing.Point(418, 287);
            this.initVeloUnitLabel.Name = "initVeloUnitLabel";
            this.initVeloUnitLabel.Size = new System.Drawing.Size(44, 18);
            this.initVeloUnitLabel.TabIndex = 19;
            this.initVeloUnitLabel.Text = "m/s";
            // 
            // finVeloUnitLabel
            // 
            this.finVeloUnitLabel.AutoSize = true;
            this.finVeloUnitLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.finVeloUnitLabel.Location = new System.Drawing.Point(418, 314);
            this.finVeloUnitLabel.Name = "finVeloUnitLabel";
            this.finVeloUnitLabel.Size = new System.Drawing.Size(44, 18);
            this.finVeloUnitLabel.TabIndex = 20;
            this.finVeloUnitLabel.Text = "m/s";
            // 
            // accelUnit2Label
            // 
            this.accelUnit2Label.AutoSize = true;
            this.accelUnit2Label.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.accelUnit2Label.Location = new System.Drawing.Point(458, 260);
            this.accelUnit2Label.Name = "accelUnit2Label";
            this.accelUnit2Label.Size = new System.Drawing.Size(15, 13);
            this.accelUnit2Label.TabIndex = 21;
            this.accelUnit2Label.Text = "2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(266, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(206, 183);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // titleImage
            // 
            this.titleImage.Image = ((System.Drawing.Image)(resources.GetObject("titleImage.Image")));
            this.titleImage.Location = new System.Drawing.Point(12, 12);
            this.titleImage.Name = "titleImage";
            this.titleImage.Size = new System.Drawing.Size(248, 183);
            this.titleImage.TabIndex = 23;
            this.titleImage.TabStop = false;
            // 
            // KinematicSolverGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 371);
            this.Controls.Add(this.titleImage);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.finVeloUnitLabel);
            this.Controls.Add(this.initVeloUnitLabel);
            this.Controls.Add(this.timeUnitLabel);
            this.Controls.Add(this.displacementUnitLabel);
            this.Controls.Add(this.timeBtn);
            this.Controls.Add(this.accelBtn);
            this.Controls.Add(this.initVeloBtn);
            this.Controls.Add(this.finVeloBtn);
            this.Controls.Add(this.displacementBtn);
            this.Controls.Add(this.calcBtn);
            this.Controls.Add(this.finVeloTextBox);
            this.Controls.Add(this.initVeloTextBox);
            this.Controls.Add(this.accelTextBox);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.displacementLabel);
            this.Controls.Add(this.displacementTextBox);
            this.Controls.Add(this.accelUnit2Label);
            this.Controls.Add(this.accelUnit1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "KinematicSolverGUI";
            this.Text = "Kinematic Solver for Windows";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox displacementTextBox;
        private System.Windows.Forms.Label displacementLabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.TextBox accelTextBox;
        private System.Windows.Forms.TextBox initVeloTextBox;
        private System.Windows.Forms.TextBox finVeloTextBox;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.RadioButton displacementBtn;
        private System.Windows.Forms.RadioButton finVeloBtn;
        private System.Windows.Forms.RadioButton initVeloBtn;
        private System.Windows.Forms.RadioButton accelBtn;
        private System.Windows.Forms.RadioButton timeBtn;
        private System.Windows.Forms.Label displacementUnitLabel;
        private System.Windows.Forms.Label timeUnitLabel;
        private System.Windows.Forms.Label accelUnit1Label;
        private System.Windows.Forms.Label initVeloUnitLabel;
        private System.Windows.Forms.Label finVeloUnitLabel;
        private System.Windows.Forms.Label accelUnit2Label;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox titleImage;
    }
}

