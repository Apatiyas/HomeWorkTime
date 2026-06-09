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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            dialog.Title = "Выберите текстовый файл";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtContent.Text = File.ReadAllText(dialog.FileName);
                    btnEdit.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить файл!");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(txtContent.Text);
            form2.FormClosed += Form2_FormClosed;
            form2.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = (Form2)sender;
            if (form2.DialogResult == DialogResult.OK)
            {
                txtContent.Text = form2.EditedText;
            }
        }
    }
}
