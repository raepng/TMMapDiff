namespace MapDiff
{
    partial class LoadView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mapOldTxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            mapNewTxt = new TextBox();
            selectOldBtn = new Button();
            selectNewBtn = new Button();
            openMapDialog = new OpenFileDialog();
            showDiffBtn = new Button();
            SuspendLayout();
            // 
            // mapOldTxt
            // 
            mapOldTxt.Location = new Point(53, 12);
            mapOldTxt.Name = "mapOldTxt";
            mapOldTxt.Size = new Size(714, 23);
            mapOldTxt.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 1;
            label1.Text = "Old";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "New";
            // 
            // mapNewTxt
            // 
            mapNewTxt.Location = new Point(53, 41);
            mapNewTxt.Name = "mapNewTxt";
            mapNewTxt.Size = new Size(714, 23);
            mapNewTxt.TabIndex = 3;
            // 
            // selectOldBtn
            // 
            selectOldBtn.AutoSize = true;
            selectOldBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            selectOldBtn.Location = new Point(773, 12);
            selectOldBtn.Name = "selectOldBtn";
            selectOldBtn.Size = new Size(26, 25);
            selectOldBtn.TabIndex = 4;
            selectOldBtn.Text = "...";
            selectOldBtn.UseVisualStyleBackColor = true;
            selectOldBtn.Click += selectOldBtn_Click;
            // 
            // selectNewBtn
            // 
            selectNewBtn.AutoSize = true;
            selectNewBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            selectNewBtn.Location = new Point(773, 39);
            selectNewBtn.Name = "selectNewBtn";
            selectNewBtn.Size = new Size(26, 25);
            selectNewBtn.TabIndex = 5;
            selectNewBtn.Text = "...";
            selectNewBtn.UseVisualStyleBackColor = true;
            selectNewBtn.Click += selectNewBtn_Click;
            // 
            // openMapDialog
            // 
            openMapDialog.FileName = "openFileDialog1";
            // 
            // showDiffBtn
            // 
            showDiffBtn.Location = new Point(713, 70);
            showDiffBtn.Name = "showDiffBtn";
            showDiffBtn.Size = new Size(75, 23);
            showDiffBtn.TabIndex = 6;
            showDiffBtn.Text = "Show Diff";
            showDiffBtn.UseVisualStyleBackColor = true;
            showDiffBtn.Click += showDiffBtn_Click;
            // 
            // LoadView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 102);
            Controls.Add(showDiffBtn);
            Controls.Add(selectNewBtn);
            Controls.Add(selectOldBtn);
            Controls.Add(mapNewTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mapOldTxt);
            Name = "LoadView";
            Text = "MapDiff";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mapOldTxt;
        private Label label1;
        private Label label2;
        private TextBox mapNewTxt;
        private Button selectOldBtn;
        private Button selectNewBtn;
        private OpenFileDialog openMapDialog;
        private Button showDiffBtn;
    }
}
