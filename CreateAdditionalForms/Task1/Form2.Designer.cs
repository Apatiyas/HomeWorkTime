namespace WinFormsApp1
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxMask;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Label labelResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxMask = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // textBoxFolder
            this.textBoxFolder.Location = new System.Drawing.Point(12, 12);
            this.textBoxFolder.Size = new System.Drawing.Size(300, 20);

            // buttonBrowse
            this.buttonBrowse.Location = new System.Drawing.Point(320, 10);
            this.buttonBrowse.Size = new System.Drawing.Size(80, 23);
            this.buttonBrowse.Text = "Обзор";
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);

            // textBoxMask
            this.textBoxMask.Location = new System.Drawing.Point(12, 45);
            this.textBoxMask.Size = new System.Drawing.Size(100, 20);
            this.textBoxMask.Text = "*.doc";

            // buttonSearch
            this.buttonSearch.Location = new System.Drawing.Point(120, 43);
            this.buttonSearch.Size = new System.Drawing.Size(80, 23);
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            // listBoxFiles
            this.listBoxFiles.Location = new System.Drawing.Point(12, 75);
            this.listBoxFiles.Size = new System.Drawing.Size(388, 200);

            // labelResult
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(210, 48);

            // Form2
            this.ClientSize = new System.Drawing.Size(412, 290);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxMask);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.labelResult);
            this.Text = "Поиск файлов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}