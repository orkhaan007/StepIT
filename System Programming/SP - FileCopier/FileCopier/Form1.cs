using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileCopier
{
    public partial class Form1 : Form
    {
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void FromFileSelectBtn_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FromtextBox.Text = openFileDialog1.FileName;
            }
        }
        private void ToFileSelectBtn_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                TotextBox.Text = openFileDialog2.FileName;
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            thread = new Thread(CopyFile);
            thread.Start();
        }

        private void CopyFile()
        {
            string srcPath = FromtextBox.Text;
            string destPath = TotextBox.Text;

            if (string.IsNullOrEmpty(srcPath) || string.IsNullOrEmpty(destPath))
            {
                MessageBox.Show("Please select source and destination files.");
                return;
            }

            if (!File.Exists(srcPath))
            {
                MessageBox.Show("Source file does not exist.");
                return;
            }

            using (FileStream fsRead = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    var len = 10;
                    var fileSize = fsRead.Length;
                    byte[] buffer = new byte[len];

                    while (fileSize > 0)
                    {
                        len = fsRead.Read(buffer, 0, Math.Min(buffer.Length, (int)fileSize));
                        fsWrite.Write(buffer, 0, len);

                        fileSize -= len;

                        int progressPercentage = fileSize <= 0 ? 0 : (int)(((double)(fsRead.Length - fileSize) / fsRead.Length) * 100);
                        progressBar.Value = progressPercentage;

                        Thread.Sleep(5);
                    }

                    MessageBox.Show("File copied successfully.");
                }
            }
        }

        private void SuspendBtn_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Suspend();
            }
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
            }
        }

        private void AbortBtn_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
                thread.Join();
            }
        }
    }
}
