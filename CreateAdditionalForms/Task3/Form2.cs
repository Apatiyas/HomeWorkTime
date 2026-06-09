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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsApp1
{

    public partial class Form2 : Form
    {
        public string EditedText { get; private set; }

        public Form2(string text)
        {
            InitializeComponent();
            txtEdit.Text = text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditedText = txtEdit.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
