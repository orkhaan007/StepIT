using System.Drawing;

namespace FileCopier
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.FromLbl = new System.Windows.Forms.Label();
            this.ToLbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.FromtextBox = new System.Windows.Forms.TextBox();
            this.TotextBox = new System.Windows.Forms.TextBox();
            this.FromFileSelectBtn = new System.Windows.Forms.Button();
            this.ToFileSelectBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendBtn = new System.Windows.Forms.Button();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.AbortBtn = new System.Windows.Forms.Button();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FromLbl
            // 
            this.FromLbl.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.FromLbl.Location = new System.Drawing.Point(35, 50);
            this.FromLbl.Name = "FromLbl";
            this.FromLbl.Size = new System.Drawing.Size(105, 27);
            this.FromLbl.TabIndex = 0;
            this.FromLbl.Text = "From";
            // 
            // ToLbl
            // 
            this.ToLbl.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.ToLbl.Location = new System.Drawing.Point(35, 99);
            this.ToLbl.Name = "ToLbl";
            this.ToLbl.Size = new System.Drawing.Size(52, 24);
            this.ToLbl.TabIndex = 1;
            this.ToLbl.Text = "To";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "FromFileDialog";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "ToFileDialog";
            // 
            // FromtextBox
            // 
            this.FromtextBox.Location = new System.Drawing.Point(114, 48);
            this.FromtextBox.Multiline = true;
            this.FromtextBox.Name = "FromtextBox";
            this.FromtextBox.Size = new System.Drawing.Size(321, 26);
            this.FromtextBox.TabIndex = 2;
            // 
            // TotextBox
            // 
            this.TotextBox.Location = new System.Drawing.Point(114, 100);
            this.TotextBox.Multiline = true;
            this.TotextBox.Name = "TotextBox";
            this.TotextBox.Size = new System.Drawing.Size(321, 25);
            this.TotextBox.TabIndex = 3;
            // 
            // FromFileSelectBtn
            // 
            this.FromFileSelectBtn.Location = new System.Drawing.Point(449, 48);
            this.FromFileSelectBtn.Name = "FromFileSelectBtn";
            this.FromFileSelectBtn.Size = new System.Drawing.Size(75, 26);
            this.FromFileSelectBtn.TabIndex = 4;
            this.FromFileSelectBtn.Text = "File...";
            this.FromFileSelectBtn.UseVisualStyleBackColor = true;
            this.FromFileSelectBtn.Click += new System.EventHandler(this.FromFileSelectBtn_Click_1);
            // 
            // ToFileSelectBtn
            // 
            this.ToFileSelectBtn.Location = new System.Drawing.Point(449, 98);
            this.ToFileSelectBtn.Name = "ToFileSelectBtn";
            this.ToFileSelectBtn.Size = new System.Drawing.Size(75, 27);
            this.ToFileSelectBtn.TabIndex = 5;
            this.ToFileSelectBtn.Text = "File...";
            this.ToFileSelectBtn.UseVisualStyleBackColor = true;
            this.ToFileSelectBtn.Click += new System.EventHandler(this.ToFileSelectBtn_Click_1);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Lime;
            this.progressBar.Location = new System.Drawing.Point(39, 153);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(194, 23);
            this.progressBar.TabIndex = 6;
            // 
            // SuspendBtn
            // 
            this.SuspendBtn.Location = new System.Drawing.Point(250, 153);
            this.SuspendBtn.Name = "SuspendBtn";
            this.SuspendBtn.Size = new System.Drawing.Size(63, 23);
            this.SuspendBtn.TabIndex = 7;
            this.SuspendBtn.Text = "Suspend";
            this.SuspendBtn.UseVisualStyleBackColor = true;
            this.SuspendBtn.Click += new System.EventHandler(this.SuspendBtn_Click);
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.Location = new System.Drawing.Point(319, 153);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(56, 23);
            this.ResumeBtn.TabIndex = 8;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = true;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // AbortBtn
            // 
            this.AbortBtn.Location = new System.Drawing.Point(381, 153);
            this.AbortBtn.Name = "AbortBtn";
            this.AbortBtn.Size = new System.Drawing.Size(54, 23);
            this.AbortBtn.TabIndex = 9;
            this.AbortBtn.Text = "Abort";
            this.AbortBtn.UseVisualStyleBackColor = true;
            this.AbortBtn.Click += new System.EventHandler(this.AbortBtn_Click);
            // 
            // CopyBtn
            // 
            this.CopyBtn.Location = new System.Drawing.Point(449, 153);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(75, 23);
            this.CopyBtn.TabIndex = 10;
            this.CopyBtn.Text = "Copy";
            this.CopyBtn.UseVisualStyleBackColor = true;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 199);
            this.Controls.Add(this.CopyBtn);
            this.Controls.Add(this.AbortBtn);
            this.Controls.Add(this.ResumeBtn);
            this.Controls.Add(this.SuspendBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ToFileSelectBtn);
            this.Controls.Add(this.FromFileSelectBtn);
            this.Controls.Add(this.TotextBox);
            this.Controls.Add(this.FromtextBox);
            this.Controls.Add(this.ToLbl);
            this.Controls.Add(this.FromLbl);
            this.Name = "Form1";
            this.Text = "File Copier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FromLbl;
        private System.Windows.Forms.Label ToLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox FromtextBox;
        private System.Windows.Forms.TextBox TotextBox;
        private System.Windows.Forms.Button FromFileSelectBtn;
        private System.Windows.Forms.Button ToFileSelectBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button SuspendBtn;
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.Button AbortBtn;
        private System.Windows.Forms.Button CopyBtn;
    }
}

