namespace MapDiff
{
    partial class DiffView
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            diffCalcProgress = new ProgressBar();
            tableLayoutPanel2 = new TableLayoutPanel();
            addedRemovedListBox = new ListBox();
            panel1 = new Panel();
            diffViewControl = new DiffViewControl();
            groupBox1 = new GroupBox();
            helpBtn = new Button();
            ppbUpDown = new NumericUpDown();
            label1 = new Label();
            progressUpdateTimer = new System.Windows.Forms.Timer(components);
            showGrassCheckBox = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ppbUpDown).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(diffCalcProgress, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // diffCalcProgress
            // 
            diffCalcProgress.Dock = DockStyle.Bottom;
            diffCalcProgress.Location = new Point(3, 424);
            diffCalcProgress.Name = "diffCalcProgress";
            diffCalcProgress.Size = new Size(794, 23);
            diffCalcProgress.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(addedRemovedListBox, 1, 0);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 78);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(794, 340);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // addedRemovedListBox
            // 
            addedRemovedListBox.Dock = DockStyle.Fill;
            addedRemovedListBox.FormattingEnabled = true;
            addedRemovedListBox.ItemHeight = 15;
            addedRemovedListBox.Location = new Point(400, 3);
            addedRemovedListBox.Name = "addedRemovedListBox";
            addedRemovedListBox.Size = new Size(391, 334);
            addedRemovedListBox.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(diffViewControl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(391, 334);
            panel1.TabIndex = 2;
            // 
            // diffViewControl
            // 
            diffViewControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            diffViewControl.BackColor = SystemColors.ActiveCaptionText;
            diffViewControl.Location = new Point(18, 19);
            diffViewControl.Name = "diffViewControl";
            diffViewControl.Size = new Size(150, 216);
            diffViewControl.TabIndex = 0;
            diffViewControl.Scroll += diffViewControl_Scroll;
            diffViewControl.MouseMove += diffViewControl_MouseMove;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(showGrassCheckBox);
            groupBox1.Controls.Add(helpBtn);
            groupBox1.Controls.Add(ppbUpDown);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 69);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // helpBtn
            // 
            helpBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            helpBtn.Location = new Point(710, 24);
            helpBtn.Name = "helpBtn";
            helpBtn.Size = new Size(75, 23);
            helpBtn.TabIndex = 3;
            helpBtn.Text = "Help";
            helpBtn.UseVisualStyleBackColor = true;
            helpBtn.Click += helpBtn_Click;
            // 
            // ppbUpDown
            // 
            ppbUpDown.Location = new Point(115, 22);
            ppbUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            ppbUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ppbUpDown.Name = "ppbUpDown";
            ppbUpDown.Size = new Size(120, 23);
            ppbUpDown.TabIndex = 2;
            ppbUpDown.Value = new decimal(new int[] { 15, 0, 0, 0 });
            ppbUpDown.ValueChanged += ppbUpDown_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Pixels per Block";
            // 
            // progressUpdateTimer
            // 
            progressUpdateTimer.Interval = 500;
            progressUpdateTimer.Tick += progressUpdateTimer_Tick;
            // 
            // showGrassCheckBox
            // 
            showGrassCheckBox.AutoSize = true;
            showGrassCheckBox.Location = new Point(263, 25);
            showGrassCheckBox.Name = "showGrassCheckBox";
            showGrassCheckBox.Size = new Size(86, 19);
            showGrassCheckBox.TabIndex = 4;
            showGrassCheckBox.Text = "Show Grass";
            showGrassCheckBox.UseVisualStyleBackColor = true;
            showGrassCheckBox.CheckedChanged += showGrassCheckBox_CheckedChanged;
            // 
            // DiffView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "DiffView";
            Text = "DiffView";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ppbUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private ProgressBar diffCalcProgress;
        private System.Windows.Forms.Timer progressUpdateTimer;
        private TableLayoutPanel tableLayoutPanel2;
        private DiffViewControl diffViewControl;
        private ListBox addedRemovedListBox;
        private GroupBox groupBox1;
        private NumericUpDown ppbUpDown;
        private Label label1;
        private Panel panel1;
        private Button helpBtn;
        private CheckBox showGrassCheckBox;
    }
}