namespace GlobalOPT
{
    partial class Form1
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
            this.output = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.matricesNumeric = new System.Windows.Forms.NumericUpDown();
            this.bfiNumeric = new System.Windows.Forms.NumericUpDown();
            this.algorithmSelection = new System.Windows.Forms.ComboBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.depthNumeric = new System.Windows.Forms.NumericUpDown();
            this.thresholdNumeric = new System.Windows.Forms.NumericUpDown();
            this.matricesLabel = new System.Windows.Forms.Label();
            this.bfiLabel = new System.Windows.Forms.Label();
            this.iterationNumeric = new System.Windows.Forms.NumericUpDown();
            this.RunButton = new System.Windows.Forms.Button();
            this.depthLabel = new System.Windows.Forms.Label();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.killServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hidingTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dockerTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.matricesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfiNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationNumeric)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.Black;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.ForeColor = System.Drawing.Color.White;
            this.output.Location = new System.Drawing.Point(441, 2);
            this.output.Margin = new System.Windows.Forms.Padding(2);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(634, 540);
            this.output.TabIndex = 16;
            this.output.Text = "";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Enabled = false;
            this.iterationLabel.Location = new System.Drawing.Point(9, 94);
            this.iterationLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(99, 29);
            this.iterationLabel.TabIndex = 6;
            this.iterationLabel.Text = "Iteration";
            // 
            // matricesNumeric
            // 
            this.matricesNumeric.Enabled = false;
            this.matricesNumeric.Location = new System.Drawing.Point(316, 183);
            this.matricesNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.matricesNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.matricesNumeric.Name = "matricesNumeric";
            this.matricesNumeric.Size = new System.Drawing.Size(108, 35);
            this.matricesNumeric.TabIndex = 11;
            // 
            // bfiNumeric
            // 
            this.bfiNumeric.Enabled = false;
            this.bfiNumeric.Location = new System.Drawing.Point(315, 277);
            this.bfiNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.bfiNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bfiNumeric.Name = "bfiNumeric";
            this.bfiNumeric.Size = new System.Drawing.Size(108, 35);
            this.bfiNumeric.TabIndex = 15;
            // 
            // algorithmSelection
            // 
            this.algorithmSelection.Enabled = false;
            this.algorithmSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmSelection.FormattingEnabled = true;
            this.algorithmSelection.Items.AddRange(new object[] {
            "Use Last Parameters Or Default"});
            this.algorithmSelection.Location = new System.Drawing.Point(14, 43);
            this.algorithmSelection.Margin = new System.Windows.Forms.Padding(7);
            this.algorithmSelection.Name = "algorithmSelection";
            this.algorithmSelection.Size = new System.Drawing.Size(410, 41);
            this.algorithmSelection.TabIndex = 5;
            this.algorithmSelection.SelectedIndexChanged += new System.EventHandler(this.algorithmSelection_SelectedIndexChanged);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Enabled = false;
            this.thresholdLabel.Location = new System.Drawing.Point(9, 141);
            this.thresholdLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(123, 29);
            this.thresholdLabel.TabIndex = 9;
            this.thresholdLabel.Text = "Threshold";
            // 
            // depthNumeric
            // 
            this.depthNumeric.Enabled = false;
            this.depthNumeric.Location = new System.Drawing.Point(316, 230);
            this.depthNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.depthNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.depthNumeric.Name = "depthNumeric";
            this.depthNumeric.Size = new System.Drawing.Size(108, 35);
            this.depthNumeric.TabIndex = 14;
            // 
            // thresholdNumeric
            // 
            this.thresholdNumeric.Enabled = false;
            this.thresholdNumeric.Location = new System.Drawing.Point(316, 136);
            this.thresholdNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.thresholdNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.thresholdNumeric.Name = "thresholdNumeric";
            this.thresholdNumeric.Size = new System.Drawing.Size(108, 35);
            this.thresholdNumeric.TabIndex = 13;
            // 
            // matricesLabel
            // 
            this.matricesLabel.AutoSize = true;
            this.matricesLabel.Enabled = false;
            this.matricesLabel.Location = new System.Drawing.Point(9, 188);
            this.matricesLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.matricesLabel.Name = "matricesLabel";
            this.matricesLabel.Size = new System.Drawing.Size(223, 29);
            this.matricesLabel.TabIndex = 10;
            this.matricesLabel.Text = "Number of Matrices";
            // 
            // bfiLabel
            // 
            this.bfiLabel.AutoSize = true;
            this.bfiLabel.Enabled = false;
            this.bfiLabel.Location = new System.Drawing.Point(9, 282);
            this.bfiLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.bfiLabel.Name = "bfiLabel";
            this.bfiLabel.Size = new System.Drawing.Size(50, 29);
            this.bfiLabel.TabIndex = 8;
            this.bfiLabel.Text = "BFI";
            // 
            // iterationNumeric
            // 
            this.iterationNumeric.Enabled = false;
            this.iterationNumeric.Location = new System.Drawing.Point(316, 89);
            this.iterationNumeric.Margin = new System.Windows.Forms.Padding(2);
            this.iterationNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iterationNumeric.Name = "iterationNumeric";
            this.iterationNumeric.Size = new System.Drawing.Size(108, 35);
            this.iterationNumeric.TabIndex = 12;
            // 
            // RunButton
            // 
            this.RunButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RunButton.Enabled = false;
            this.RunButton.Location = new System.Drawing.Point(14, 343);
            this.RunButton.Margin = new System.Windows.Forms.Padding(7);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(410, 37);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Enabled = false;
            this.depthLabel.Location = new System.Drawing.Point(9, 235);
            this.depthLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(77, 29);
            this.depthLabel.TabIndex = 7;
            this.depthLabel.Text = "Depth";
            // 
            // algorithmLabel
            // 
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Enabled = false;
            this.algorithmLabel.Location = new System.Drawing.Point(134, 9);
            this.algorithmLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(115, 29);
            this.algorithmLabel.TabIndex = 4;
            this.algorithmLabel.Text = "Algorithm";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killServicesToolStripMenuItem,
            this.restartServicesToolStripMenuItem,
            this.clearConsoleToolStripMenuItem,
            this.aboutUsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // killServicesToolStripMenuItem
            // 
            this.killServicesToolStripMenuItem.Name = "killServicesToolStripMenuItem";
            this.killServicesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.killServicesToolStripMenuItem.Text = "Kill Services";
            this.killServicesToolStripMenuItem.Click += new System.EventHandler(this.killServicesToolStripMenuItem_Click);
            // 
            // restartServicesToolStripMenuItem
            // 
            this.restartServicesToolStripMenuItem.Name = "restartServicesToolStripMenuItem";
            this.restartServicesToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.restartServicesToolStripMenuItem.Text = "Restart Services";
            this.restartServicesToolStripMenuItem.Click += new System.EventHandler(this.restartServicesToolStripMenuItem_Click_1);
            // 
            // clearConsoleToolStripMenuItem
            // 
            this.clearConsoleToolStripMenuItem.Name = "clearConsoleToolStripMenuItem";
            this.clearConsoleToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.clearConsoleToolStripMenuItem.Text = "Clear Console";
            this.clearConsoleToolStripMenuItem.Click += new System.EventHandler(this.clearConsoleToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hidingTimer
            // 
            this.hidingTimer.Enabled = true;
            this.hidingTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.76608F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.23392F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.output, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1077, 544);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.algorithmLabel);
            this.panel1.Controls.Add(this.iterationLabel);
            this.panel1.Controls.Add(this.matricesNumeric);
            this.panel1.Controls.Add(this.bfiNumeric);
            this.panel1.Controls.Add(this.RunButton);
            this.panel1.Controls.Add(this.algorithmSelection);
            this.panel1.Controls.Add(this.depthNumeric);
            this.panel1.Controls.Add(this.thresholdLabel);
            this.panel1.Controls.Add(this.depthLabel);
            this.panel1.Controls.Add(this.thresholdNumeric);
            this.panel1.Controls.Add(this.matricesLabel);
            this.panel1.Controls.Add(this.iterationNumeric);
            this.panel1.Controls.Add(this.bfiLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 540);
            this.panel1.TabIndex = 20;
            // 
            // dockerTimer
            // 
            this.dockerTimer.Enabled = true;
            this.dockerTimer.Interval = 1000;
            this.dockerTimer.Tick += new System.EventHandler(this.dockerTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1077, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Form1";
            this.Text = "GlobalOPT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.matricesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bfiNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationNumeric)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox output;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.NumericUpDown matricesNumeric;
        private System.Windows.Forms.NumericUpDown bfiNumeric;
        private System.Windows.Forms.ComboBox algorithmSelection;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.NumericUpDown depthNumeric;
        private System.Windows.Forms.NumericUpDown thresholdNumeric;
        private System.Windows.Forms.Label matricesLabel;
        private System.Windows.Forms.Label bfiLabel;
        private System.Windows.Forms.NumericUpDown iterationNumeric;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restartServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.Timer hidingTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killServicesToolStripMenuItem;
        private System.Windows.Forms.Timer dockerTimer;
    }
}

