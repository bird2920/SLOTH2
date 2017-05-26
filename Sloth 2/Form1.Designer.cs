namespace Sloth_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbInputPath = new System.Windows.Forms.TextBox();
            this.btnInputPath = new System.Windows.Forms.Button();
            this.tbOutputPath = new System.Windows.Forms.TextBox();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGO = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.tbDateModifiedYear = new System.Windows.Forms.TextBox();
            this.tbSplitChar = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblPattern = new System.Windows.Forms.Label();
            this.tbPattern = new System.Windows.Forms.TextBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.cbRecursive = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cbDeleteEmptyDir = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInputPath
            // 
            this.tbInputPath.Location = new System.Drawing.Point(93, 40);
            this.tbInputPath.Name = "tbInputPath";
            this.tbInputPath.Size = new System.Drawing.Size(336, 20);
            this.tbInputPath.TabIndex = 0;
            this.tbInputPath.TextChanged += new System.EventHandler(this.PathChange_SaveProperties);
            // 
            // btnInputPath
            // 
            this.btnInputPath.Location = new System.Drawing.Point(12, 37);
            this.btnInputPath.Name = "btnInputPath";
            this.btnInputPath.Size = new System.Drawing.Size(75, 23);
            this.btnInputPath.TabIndex = 1;
            this.btnInputPath.Text = "InputPath";
            this.btnInputPath.UseVisualStyleBackColor = true;
            this.btnInputPath.Click += new System.EventHandler(this.InputPath_Click);
            // 
            // tbOutputPath
            // 
            this.tbOutputPath.Location = new System.Drawing.Point(93, 66);
            this.tbOutputPath.Name = "tbOutputPath";
            this.tbOutputPath.Size = new System.Drawing.Size(336, 20);
            this.tbOutputPath.TabIndex = 2;
            this.tbOutputPath.TextChanged += new System.EventHandler(this.PathChange_SaveProperties);
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Location = new System.Drawing.Point(12, 64);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(75, 23);
            this.btnOutputPath.TabIndex = 3;
            this.btnOutputPath.Text = "Output Path";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.OutputPath_Click);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(435, 38);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 49);
            this.btnGO.TabIndex = 9;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.GO_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.tbDateModifiedYear);
            this.groupBox1.Controls.Add(this.tbSplitChar);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 73);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Type";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(168, 43);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(51, 17);
            this.radioButton6.TabIndex = 22;
            this.radioButton6.Text = "None";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(375, 20);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(97, 17);
            this.radioButton5.TabIndex = 21;
            this.radioButton5.Text = "By Date Taken";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.ByDateTaken_CheckedChanged);
            // 
            // tbDateModifiedYear
            // 
            this.tbDateModifiedYear.Enabled = false;
            this.tbDateModifiedYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDateModifiedYear.Location = new System.Drawing.Point(127, 40);
            this.tbDateModifiedYear.Name = "tbDateModifiedYear";
            this.tbDateModifiedYear.Size = new System.Drawing.Size(35, 22);
            this.tbDateModifiedYear.TabIndex = 20;
            this.tbDateModifiedYear.Visible = false;
            // 
            // tbSplitChar
            // 
            this.tbSplitChar.Enabled = false;
            this.tbSplitChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSplitChar.Location = new System.Drawing.Point(334, 17);
            this.tbSplitChar.Name = "tbSplitChar";
            this.tbSplitChar.Size = new System.Drawing.Size(35, 22);
            this.tbSplitChar.TabIndex = 19;
            this.tbSplitChar.Text = "_";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 43);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(115, 17);
            this.radioButton4.TabIndex = 17;
            this.radioButton4.Text = "By Date Modified <";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.ByLastAccessed_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(166, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(162, 17);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.Text = "By File Name: Split Character";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.BySeparator_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(97, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.Text = "By Date";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.ByDate_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "By Extension";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.ByExtension_CheckedChanged);
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(12, 9);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(78, 13);
            this.lblPattern.TabIndex = 23;
            this.lblPattern.Text = "Search Pattern";
            // 
            // tbPattern
            // 
            this.tbPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPattern.Location = new System.Drawing.Point(96, 6);
            this.tbPattern.Name = "tbPattern";
            this.tbPattern.Size = new System.Drawing.Size(63, 22);
            this.tbPattern.TabIndex = 22;
            this.tbPattern.Text = "*.*";
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.Location = new System.Drawing.Point(12, 188);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(497, 277);
            this.lbLog.TabIndex = 24;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(536, 6);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 25;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(475, 5);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(34, 26);
            this.btnExpand.TabIndex = 26;
            this.btnExpand.Text = ">>";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.Expand_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnExportLog
            // 
            this.btnExportLog.Location = new System.Drawing.Point(535, 35);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(75, 25);
            this.btnExportLog.TabIndex = 27;
            this.btnExportLog.Text = "Export Log";
            this.btnExportLog.UseVisualStyleBackColor = true;
            this.btnExportLog.Click += new System.EventHandler(this.WriteLogFile);
            // 
            // cbRecursive
            // 
            this.cbRecursive.AutoSize = true;
            this.cbRecursive.Location = new System.Drawing.Point(165, 8);
            this.cbRecursive.Name = "cbRecursive";
            this.cbRecursive.Size = new System.Drawing.Size(136, 17);
            this.cbRecursive.TabIndex = 28;
            this.cbRecursive.Text = "Include Sub-Directories";
            this.cbRecursive.UseVisualStyleBackColor = true;
            this.cbRecursive.CheckedChanged += new System.EventHandler(this.cbRecursive_CheckedChanged);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(9, 468);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 29;
            this.lblProgress.Text = "Progress";
            // 
            // cbDeleteEmptyDir
            // 
            this.cbDeleteEmptyDir.AutoSize = true;
            this.cbDeleteEmptyDir.Location = new System.Drawing.Point(307, 8);
            this.cbDeleteEmptyDir.Name = "cbDeleteEmptyDir";
            this.cbDeleteEmptyDir.Size = new System.Drawing.Size(142, 17);
            this.cbDeleteEmptyDir.TabIndex = 30;
            this.cbDeleteEmptyDir.Text = "Delete Empty Directories";
            this.cbDeleteEmptyDir.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(521, 488);
            this.Controls.Add(this.cbDeleteEmptyDir);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.cbRecursive);
            this.Controls.Add(this.btnExportLog);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.tbPattern);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnOutputPath);
            this.Controls.Add(this.tbOutputPath);
            this.Controls.Add(this.btnInputPath);
            this.Controls.Add(this.tbInputPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(633, 1024);
            this.MinimumSize = new System.Drawing.Size(537, 468);
            this.Name = "Form1";
            this.Text = "Sloth 2 - Fast File Organizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInputPath;
        private System.Windows.Forms.Button btnInputPath;
        private System.Windows.Forms.TextBox tbOutputPath;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.TextBox tbPattern;
        private System.Windows.Forms.TextBox tbSplitChar;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnExpand;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnExportLog;
        private System.Windows.Forms.TextBox tbDateModifiedYear;
        private System.Windows.Forms.CheckBox cbRecursive;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.CheckBox cbDeleteEmptyDir;
    }
}

