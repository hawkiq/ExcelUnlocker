namespace ExcelDecrypter
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
            this.unlockBtnProcess = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.filelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unlockBtnProcess
            // 
            this.unlockBtnProcess.BackColor = System.Drawing.Color.LightGreen;
            this.unlockBtnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unlockBtnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unlockBtnProcess.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unlockBtnProcess.ForeColor = System.Drawing.Color.ForestGreen;
            this.unlockBtnProcess.Location = new System.Drawing.Point(172, 12);
            this.unlockBtnProcess.Name = "unlockBtnProcess";
            this.unlockBtnProcess.Size = new System.Drawing.Size(146, 36);
            this.unlockBtnProcess.TabIndex = 0;
            this.unlockBtnProcess.Text = "Unlock";
            this.unlockBtnProcess.UseVisualStyleBackColor = false;
            this.unlockBtnProcess.Click += new System.EventHandler(this.UnlockBtnProcess_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xlsm";
            this.openFileDialog.Filter = "Excel files (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm|All files (*.*)|*.*";
            this.openFileDialog.Title = "Please Select Excel file";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.openFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFileBtn.Location = new System.Drawing.Point(12, 12);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(101, 36);
            this.openFileBtn.TabIndex = 1;
            this.openFileBtn.Text = "Open Excel file";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // filelbl
            // 
            this.filelbl.Location = new System.Drawing.Point(9, 51);
            this.filelbl.Name = "filelbl";
            this.filelbl.Size = new System.Drawing.Size(309, 23);
            this.filelbl.TabIndex = 2;
            this.filelbl.Text = "Please Select file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 75);
            this.Controls.Add(this.filelbl);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.unlockBtnProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Excel Unlocker by hawkiq";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button unlockBtnProcess;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Label filelbl;
    }
}

