using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{

    public partial class Form2 : Form
    {
        List<string> sklad;

        public Form2(List<string> sklad)
        {
            InitializeComponent();
            this.sklad = sklad;
            UpdateList();
        }

        void UpdateList()
        {
            listBoxProducts.Items.Clear();
            foreach (string s in sklad)
            {
                string name = s.Split('|')[0];
                listBoxProducts.Items.Add(name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string price = txtPrice.Text.Trim();

            if (name == "" || price == "")
            {
                MessageBox.Show("Заполните название и цену!");
                return;
            }

            sklad.Add(name + "|" + price);
            UpdateList();
            txtName.Clear();
            txtPrice.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedIndex >= 0)
            {
                sklad.RemoveAt(listBoxProducts.SelectedIndex);
                UpdateList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
