namespace WinFormsApp1
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtEdit;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtEdit = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            
            this.txtEdit.Location = new Point(12, 12);
            this.txtEdit.Multiline = true;
            this.txtEdit.ScrollBars = ScrollBars.Vertical;
            this.txtEdit.Size = new Size(460, 300);

            
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new Point(12, 325);
            this.btnSave.Size = new Size(140, 35);
            this.btnSave.Click += btnSave_Click;

           
            this.btnCancel.Text = "Отменить";
            this.btnCancel.Location = new Point(170, 325);
            this.btnCancel.Size = new Size(140, 35);
            this.btnCancel.Click += btnCancel_Click;

            
            this.Text = "Редактирование";
            this.ClientSize = new Size(484, 375);
            this.Controls.Add(this.txtEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}