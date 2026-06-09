using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        List<string> sklad = new List<string>();
        List<decimal> cartPrices = new List<decimal>();

        public Form1()
        {
            InitializeComponent();
            sklad.Add("Мышь|500");
            sklad.Add("Клавиатура|1200");
            UpdateCombo();
        }

        void UpdateCombo()
        {
            comboBoxProducts.Items.Clear();
            foreach (string s in sklad)
            {
                string name = s.Split('|')[0];
                comboBoxProducts.Items.Add(name);
            }
            if (comboBoxProducts.Items.Count > 0)
                comboBoxProducts.SelectedIndex = 0;
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int index = comboBoxProducts.SelectedIndex;
            if (index >= 0 && index < sklad.Count)
            {
                string s = sklad[index];
                string price = s.Split('|')[1];
                txtPrice.Text = price;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex < 0)
                return;

            int index = comboBoxProducts.SelectedIndex;
            string s = sklad[index];
            string name = s.Split('|')[0];
            string priceText = s.Split('|')[1];

            decimal price = decimal.Parse(priceText);

            cartPrices.Add(price);
            listBoxCart.Items.Add(name + " — " + price.ToString("0.00") + " руб.");

            UpdateTotal();
        }

        void UpdateTotal()
        {
            decimal total = 0;
            foreach (decimal p in cartPrices)
                total += p;
            lblTotal.Text = "Итого: " + total.ToString("0.00") + " руб.";
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(sklad);
            f2.ShowDialog();
            UpdateCombo();
        }
    }
}
