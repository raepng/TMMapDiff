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
            diffViewControl = new DiffViewControl();
            progressUpdateTimer = new System.Windows.Forms.Timer(components);
            addedRemovedListBox = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(diffCalcProgress, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
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
            tableLayoutPanel2.Controls.Add(diffViewControl, 0, 0);
            tableLayoutPanel2.Controls.Add(addedRemovedListBox, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(794, 415);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // diffViewControl
            // 
            diffViewControl.BackColor = SystemColors.ActiveCaptionText;
            diffViewControl.Location = new Point(3, 3);
            diffViewControl.Name = "diffViewControl";
            diffViewControl.Size = new Size(150, 150);
            diffViewControl.TabIndex = 0;
            // 
            // progressUpdateTimer
            // 
            progressUpdateTimer.Interval = 500;
            progressUpdateTimer.Tick += progressUpdateTimer_Tick;
            // 
            // addedRemovedListBox
            // 
            addedRemovedListBox.Dock = DockStyle.Fill;
            addedRemovedListBox.FormattingEnabled = true;
            addedRemovedListBox.ItemHeight = 15;
            addedRemovedListBox.Location = new Point(400, 3);
            addedRemovedListBox.Name = "addedRemovedListBox";
            addedRemovedListBox.Size = new Size(391, 409);
            addedRemovedListBox.TabIndex = 1;
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
            tableLayoutPanel2.ResumeLayout(false);
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
    }
}