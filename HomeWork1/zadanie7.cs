using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

   
    public partial class MainWindow : Window
    {
       private StackPanel panel;
        private RadioButton radioButton;
      //  private Button button;
        private TextBox textBox;
        private TextBlock textBlock;
        private string[] timeUnits = { "Годы", "Месяцы", "Дни", "Минуты", "Секунды" };
        private int selectedIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            panel = new StackPanel();
            panel.VerticalAlignment = VerticalAlignment.Center;
             textBox = new TextBox();
            textBox.Width = 260;
            textBox.Height = 30;
           
            textBlock = new TextBlock();
            textBlock.Width = 260;
            textBlock.Height = 30;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontWeight = FontWeights.Bold;
            //panel.Children.Add(button);
            panel.Children.Add(textBlock);
            panel.Children.Add(textBox);
            Buttons();
            
            this.Content = panel;
        }

        private void Buttons()
        {
           for (int i = 0; i < timeUnits.Length; i++)
            {
                radioButton = new RadioButton();
                radioButton.Width = 260;
                radioButton.Height = 30;

                radioButton.Content = timeUnits[i];
                radioButton.Style = (Style)Application.Current.FindResource(typeof(ToggleButton));
                int currentIndex = i;
                radioButton.Click += (s, e) => { btn_click(); selectedIndex = currentIndex; };
                panel.Children.Add(radioButton); 
            }
        }

        private void btn_click()
        {
            DateTime now = DateTime.Now; 
            DateTime targetDate;
            if (!DateTime.TryParseExact(textBox.Text, "dd.MM.yyyy",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None,
        out targetDate))
            {
                textBlock.Text = "Неверный формат!\nВведите: ДД.ММ.ГГГГ";
              
                return;
            }

            TimeSpan diff = targetDate - now;
            string result = "";

            switch (selectedIndex)
            {

                case 0:
                   
                    double years = diff.TotalDays / 365.25;
                    result = $"{years:F2} лет";
                    break;

                case 1:
                    
                    double months = diff.TotalDays / 30.44;
                    result = $"{months:F2} месяцев";
                    break;

                case 2:
                    result = $"{Math.Floor(diff.TotalDays)} дней";
                    break;

                case 3:
                    result = $"{Math.Floor(diff.TotalMinutes)} минут";
                    break;

                case 4:
                    result = $"{Math.Floor(diff.TotalSeconds)} секунд";
                    break;
            }
            textBlock.Text = result;
        }
    }
}
