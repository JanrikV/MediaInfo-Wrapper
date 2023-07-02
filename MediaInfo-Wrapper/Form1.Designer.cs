
namespace MediaInfoWrapper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectedFile = new System.Windows.Forms.TextBox();
            this.openMediaFile = new System.Windows.Forms.Button();
            this.MediaInfoDataBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SelectedFile
            // 
            this.SelectedFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SelectedFile.Font = new System.Drawing.Font("Source Code Pro", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFile.Location = new System.Drawing.Point(28, 44);
            this.SelectedFile.Name = "SelectedFile";
            this.SelectedFile.Size = new System.Drawing.Size(294, 24);
            this.SelectedFile.TabIndex = 0;
            this.SelectedFile.Text = "Select a File...";
            // 
            // openMediaFile
            // 
            this.openMediaFile.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openMediaFile.Location = new System.Drawing.Point(28, 87);
            this.openMediaFile.Name = "openMediaFile";
            this.openMediaFile.Size = new System.Drawing.Size(107, 32);
            this.openMediaFile.TabIndex = 1;
            this.openMediaFile.Text = "Select file";
            this.openMediaFile.UseVisualStyleBackColor = true;
            this.openMediaFile.Click += new System.EventHandler(this.OpenMediaFile_Click);
            // 
            // MediaInfoDataBox
            // 
            this.MediaInfoDataBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MediaInfoDataBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MediaInfoDataBox.Font = new System.Drawing.Font("Source Sans Pro Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.MediaInfoDataBox.Location = new System.Drawing.Point(28, 150);
            this.MediaInfoDataBox.Name = "MediaInfoDataBox";
            this.MediaInfoDataBox.Size = new System.Drawing.Size(639, 303);
            this.MediaInfoDataBox.TabIndex = 2;
            this.MediaInfoDataBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(742, 529);
            this.Controls.Add(this.MediaInfoDataBox);
            this.Controls.Add(this.openMediaFile);
            this.Controls.Add(this.SelectedFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MediaInfo Wrapper | v1.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox SelectedFile;
        private System.Windows.Forms.Button openMediaFile;
        private System.Windows.Forms.RichTextBox MediaInfoDataBox;
    }
}

