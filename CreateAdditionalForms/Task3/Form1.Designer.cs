namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtContent;
        private Button btnLoad;
        private Button btnEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtContent = new TextBox();
            this.btnLoad = new Button();
            this.btnEdit = new Button();
            this.SuspendLayout();

           
            this.txtContent.Location = new Point(12, 12);
            this.txtContent.Multiline = true;
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = ScrollBars.Vertical;
            this.txtContent.Size = new Size(460, 300);

            
            this.btnLoad.Text = "Загрузить файл";
            this.btnLoad.Location = new Point(12, 325);
            this.btnLoad.Size = new Size(140, 35);
            this.btnLoad.Click += btnLoad_Click;

          
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new Point(170, 325);
            this.btnEdit.Size = new Size(140, 35);
            this.btnEdit.Click += btnEdit_Click;

          
            this.Text = "Просмотр файла";
            this.ClientSize = new Size(484, 375);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnEdit);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
