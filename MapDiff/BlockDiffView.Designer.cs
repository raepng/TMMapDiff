namespace MapDiff
{
    partial class BlockDiffView
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
            diffListBox = new ListBox();
            SuspendLayout();
            // 
            // diffListBox
            // 
            diffListBox.Dock = DockStyle.Fill;
            diffListBox.FormattingEnabled = true;
            diffListBox.ItemHeight = 15;
            diffListBox.Location = new Point(0, 0);
            diffListBox.Name = "diffListBox";
            diffListBox.Size = new Size(800, 450);
            diffListBox.TabIndex = 0;
            // 
            // BlockDiffView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(diffListBox);
            Name = "BlockDiffView";
            Text = "BlockDiffView";
            ResumeLayout(false);
        }

        #endregion

        private ListBox diffListBox;
    }
}