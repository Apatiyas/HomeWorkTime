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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                textBoxFolder.Text = fbd.SelectedPath;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listBoxFiles.Items.Clear();

            try
            {
                string[] files = Directory.GetFiles(textBoxFolder.Text, textBoxMask.Text, SearchOption.AllDirectories);

                foreach (string file in files)
                    listBoxFiles.Items.Add(file);

                labelResult.Text = "Найдено: " + files.Length;
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
