using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

   
    public partial class MainWindow : Window
    {
       private StackPanel panel;
        private Button button;
        private TextBox textBox;
        private TextBlock textBlock;
        public MainWindow()
        {
            InitializeComponent();
            panel = new StackPanel();
            panel.VerticalAlignment = VerticalAlignment.Center;
            button = new Button();
            button.Width = 260;
            button.Height = 30;
            button.Content = "enter me";
            button.Click += (s, e) => { convetDate(); };
             textBox = new TextBox();
            textBox.Width = 260;
            textBox.Height = 30;
           
            textBlock = new TextBlock();
            textBlock.Width = 260;
            textBlock.Height = 30;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontWeight = FontWeights.Bold;
            panel.Children.Add(button);
            panel.Children.Add(textBox);
            panel.Children.Add(textBlock);
            this.Content = panel;
        }

        private void convetDate()
        {
            try
            {
                DateTime date = DateTime.ParseExact(
                     textBox.Text.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string weekdayName = date.ToString("dddd", new CultureInfo("ru-RU")).ToLower();
                weekdayName = char.ToUpper(weekdayName[0]) + weekdayName.Substring(1);
                textBlock.Text = ($"{weekdayName}");
            }
            catch {
                textBlock.Text = "non existent, example 12.09.2018";
            }
        }

    }
}
