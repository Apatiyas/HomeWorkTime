namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxProducts;
        private TextBox txtPrice;
        private ListBox listBoxCart;
        private Label lblTotal;
        private Button btnAddToCart;
        private Button btnOpenForm2;
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
            this.comboBoxProducts = new ComboBox();
            this.txtPrice = new TextBox();
            this.listBoxCart = new ListBox();
            this.lblTotal = new Label();
            this.btnAddToCart = new Button();
            this.btnOpenForm2 = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new Point(12, 30);
            this.comboBoxProducts.Size = new Size(200, 23);

           
            this.label1.Text = "Товар:";
            this.label1.Location = new Point(12, 10);
            this.label1.Size = new Size(100, 17);

            this.txtPrice.Location = new Point(220, 30);
            this.txtPrice.Size = new Size(80, 23);
            this.txtPrice.ReadOnly = true;

        
            this.label2.Text = "Цена:";
            this.label2.Location = new Point(220, 10);
            this.label2.Size = new Size(80, 17);

         
            this.btnAddToCart.Text = "Добавить";
            this.btnAddToCart.Location = new Point(12, 60);
            this.btnAddToCart.Size = new Size(100, 30);
            this.btnAddToCart.Click += btnAddToCart_Click;

          
            this.listBoxCart.Location = new Point(12, 100);
            this.listBoxCart.Size = new Size(288, 130);

           
            this.lblTotal.Text = "Итого: 0 руб.";
            this.lblTotal.Location = new Point(12, 240);
            this.lblTotal.Size = new Size(200, 20);
            this.lblTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            
            this.btnOpenForm2.Text = "Товары";
            this.btnOpenForm2.Location = new Point(200, 60);
            this.btnOpenForm2.Size = new Size(100, 30);
            this.btnOpenForm2.Click += btnOpenForm2_Click;

            
            this.Text = "Продажи";
            this.ClientSize = new Size(315, 280);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.listBoxCart);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnOpenForm2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
