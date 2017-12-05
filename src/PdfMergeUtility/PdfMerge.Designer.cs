namespace PdfMergeUtility
{
    partial class PdfMerge
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.txtSaveAs = new System.Windows.Forms.TextBox();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnSaveAs);
            this.panel1.Controls.Add(this.txtSaveAs);
            this.panel1.Controls.Add(this.btnSourcePath);
            this.panel1.Controls.Add(this.txtSourcePath);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 112);
            this.panel1.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(4, 57);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(428, 51);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Convert to PDF";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(357, 30);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 20);
            this.btnSaveAs.TabIndex = 3;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSaveAs
            // 
            this.txtSaveAs.Location = new System.Drawing.Point(4, 30);
            this.txtSaveAs.Name = "txtSaveAs";
            this.txtSaveAs.Size = new System.Drawing.Size(347, 20);
            this.txtSaveAs.TabIndex = 2;
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.Location = new System.Drawing.Point(357, 4);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(75, 20);
            this.btnSourcePath.TabIndex = 1;
            this.btnSourcePath.Text = "Search";
            this.btnSourcePath.UseVisualStyleBackColor = true;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(4, 4);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(347, 20);
            this.txtSourcePath.TabIndex = 0;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select your svg source directory...";
            //
            // saveFileDialog
            //
            this.saveFileDialog.Filter = "PDF Document|*.pdf";
            // 
            // PdfMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 142);
            this.Controls.Add(this.panel1);
            this.Name = "PdfMerge";
            this.Text = "PdfMerge";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.TextBox txtSaveAs;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

