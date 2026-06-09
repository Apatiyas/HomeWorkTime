namespace WinFormsApp1
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtPrice;
        private ListBox listBoxProducts;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClose;
        private Label label1;
        private Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new TextBox();
            this.txtPrice = new TextBox();
            this.listBoxProducts = new ListBox();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.btnClose = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            // label1
            this.label1.Text = "Название:";
            this.label1.Location = new Point(12, 10);
            this.label1.Size = new Size(100, 17);

            // txtName
            this.txtName.Location = new Point(12, 30);
            this.txtName.Size = new Size(180, 23);

            // label2
            this.label2.Text = "Цена:";
            this.label2.Location = new Point(200, 10);
            this.label2.Size = new Size(80, 17);

            // txtPrice
            this.txtPrice.Location = new Point(200, 30);
            this.txtPrice.Size = new Size(80, 23);

            // btnAdd
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new Point(12, 60);
            this.btnAdd.Size = new Size(100, 30);
            this.btnAdd.Click += btnAdd_Click;

            // btnDelete
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new Point(120, 60);
            this.btnDelete.Size = new Size(100, 30);
            this.btnDelete.Click += btnDelete_Click;

            // listBoxProducts
            this.listBoxProducts.Location = new Point(12, 100);
            this.listBoxProducts.Size = new Size(268, 150);

            // btnClose
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new Point(200, 260);
            this.btnClose.Size = new Size(80, 30);
            this.btnClose.Click += btnClose_Click;

            // Form2
            this.Text = "Редактирование товаров";
            this.ClientSize = new Size(295, 310);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.listBoxProducts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}