using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class Fuel
    {
        public string Name;
        public decimal Price;

        public Fuel(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class MainWindow : Window
    {
        ComboBox comboFuel;
        TextBlock labelPrice;
        RadioButton radioLiters;
        RadioButton radioAmount;
        TextBox textLiters;
        TextBox textAmount;
        TextBlock resultFuel;
        TextBlock unitFuel;
        GroupBox groupFuelResult;

        CheckBox[] cafeChecks = new CheckBox[6];
        TextBox[] cafeQtys = new TextBox[6];
        string[] cafeNames = { "Хот-дог", "Гамбургер", "Картофель фри", "Кока-Кола", "Кофе", "Чай" };
        decimal[] cafePrices = { 85, 95, 60, 40, 35, 25 };

        TextBox textTotal;
        TextBlock resultCafe;
        decimal totalRevenue = 0;

        System.Windows.Threading.DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            this.Background = new SolidColorBrush(Color.FromRgb(240, 245, 255));

            StackPanel mainPanel = new StackPanel();
            mainPanel.Margin = new Thickness(10);

            TextBlock title = new TextBlock();
            title.Text = "BEST OIL";
            title.FontSize = 22;
            title.FontWeight = FontWeights.Bold;
            title.Foreground = new SolidColorBrush(Color.FromRgb(30, 100, 200));
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.Margin = new Thickness(0, 0, 0, 10);
            mainPanel.Children.Add(title);

            Grid grid = new Grid();
            grid.Margin = new Thickness(0, 0, 0, 10);
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // ТОПЛИВО
            GroupBox fuelBox = new GroupBox();
            fuelBox.Header = "Топливо";
            fuelBox.Margin = new Thickness(5);
            fuelBox.Padding = new Thickness(10);
            fuelBox.Background = Brushes.White;

            StackPanel fuelPanel = new StackPanel();

            comboFuel = new ComboBox();
            comboFuel.Margin = new Thickness(0, 5, 0, 5);
            comboFuel.Items.Add(new Fuel("АИ-95", 54.99m));
            comboFuel.Items.Add(new Fuel("АИ-95 Премиум", 59.99m));
            comboFuel.Items.Add(new Fuel("ДТ", 52.50m));
            comboFuel.Items.Add(new Fuel("Газ", 27.30m));
            comboFuel.SelectedIndex = 0;
            comboFuel.SelectionChanged += ComboFuelChanged;
            fuelPanel.Children.Add(comboFuel);

            labelPrice = new TextBlock();
            labelPrice.FontWeight = FontWeights.Bold;
            labelPrice.Foreground = Brushes.Red;
            labelPrice.Margin = new Thickness(0, 0, 0, 10);
            fuelPanel.Children.Add(labelPrice);

            radioLiters = new RadioButton();
            radioLiters.Content = "Литры";
            radioLiters.IsChecked = true;
            radioLiters.Checked += RadioChanged;
            fuelPanel.Children.Add(radioLiters);

            radioAmount = new RadioButton();
            radioAmount.Content = "Сумма";
            radioAmount.Checked += RadioChanged;
            fuelPanel.Children.Add(radioAmount);

            StackPanel row1 = new StackPanel();
            row1.Orientation = Orientation.Horizontal;
            row1.Margin = new Thickness(0, 5, 0, 5);
            row1.Children.Add(new TextBlock() { Text = "Литры: ", VerticalAlignment = VerticalAlignment.Center });
            textLiters = new TextBox();
            textLiters.Width = 80;
            textLiters.TextChanged += TextChangedEvent;
            row1.Children.Add(textLiters);
            fuelPanel.Children.Add(row1);

            StackPanel row2 = new StackPanel();
            row2.Orientation = Orientation.Horizontal;
            row2.Margin = new Thickness(0, 5, 0, 5);
            row2.Children.Add(new TextBlock() { Text = "Сумма: ", VerticalAlignment = VerticalAlignment.Center });
            textAmount = new TextBox();
            textAmount.Width = 80;
            textAmount.IsEnabled = false;
            textAmount.TextChanged += TextChangedEvent;
            row2.Children.Add(textAmount);
            fuelPanel.Children.Add(row2);

            groupFuelResult = new GroupBox();
            groupFuelResult.Header = "К оплате";
            groupFuelResult.FontWeight = FontWeights.Bold;
            groupFuelResult.Margin = new Thickness(0, 10, 0, 0);

            StackPanel resultRow = new StackPanel();
            resultRow.Orientation = Orientation.Horizontal;
            resultRow.HorizontalAlignment = HorizontalAlignment.Center;

            resultFuel = new TextBlock();
            resultFuel.Text = "0.00";
            resultFuel.FontSize = 18;
            resultFuel.FontWeight = FontWeights.Bold;
            resultFuel.Background = new SolidColorBrush(Color.FromRgb(255, 249, 196));
            resultFuel.Padding = new Thickness(10);
            resultFuel.MinWidth = 80;
            resultFuel.TextAlignment = TextAlignment.Center;

            unitFuel = new TextBlock();
            unitFuel.Text = "руб.";
            unitFuel.FontSize = 16;
            unitFuel.VerticalAlignment = VerticalAlignment.Center;
            unitFuel.Margin = new Thickness(5, 0, 0, 0);

            resultRow.Children.Add(resultFuel);
            resultRow.Children.Add(unitFuel);
            groupFuelResult.Content = resultRow;
            fuelPanel.Children.Add(groupFuelResult);

            fuelBox.Content = fuelPanel;
            Grid.SetColumn(fuelBox, 0);
            grid.Children.Add(fuelBox);

            // МИНИ-КАФЕ
            GroupBox cafeBox = new GroupBox();
            cafeBox.Header = "Мини-кафе";
            cafeBox.Margin = new Thickness(5);
            cafeBox.Padding = new Thickness(10);
            cafeBox.Background = Brushes.White;

            StackPanel cafePanel = new StackPanel();

            for (int i = 0; i < 6; i++)
            {
                StackPanel row = new StackPanel();
                row.Orientation = Orientation.Horizontal;
                row.Margin = new Thickness(0, 3, 0, 3);

                cafeChecks[i] = new CheckBox();
                cafeChecks[i].Content = cafeNames[i];
                cafeChecks[i].Width = 130;
                cafeChecks[i].Checked += CafeCheckChanged;
                cafeChecks[i].Unchecked += CafeCheckChanged;
                row.Children.Add(cafeChecks[i]);

                TextBlock priceText = new TextBlock();
                priceText.Text = cafePrices[i].ToString("F2") + " руб";
                priceText.Width = 70;
                priceText.Foreground = Brushes.Red;
                priceText.VerticalAlignment = VerticalAlignment.Center;
                row.Children.Add(priceText);

                cafeQtys[i] = new TextBox();
                cafeQtys[i].Width = 50;
                cafeQtys[i].Text = "0";
                cafeQtys[i].IsEnabled = false;
                cafeQtys[i].TextAlignment = TextAlignment.Center;
                cafeQtys[i].TextChanged += TextChangedEvent;
                row.Children.Add(cafeQtys[i]);

                cafePanel.Children.Add(row);
            }

            // К оплате для кафе
            GroupBox cafeResultBox = new GroupBox();
            cafeResultBox.Header = "К оплате";
            cafeResultBox.FontWeight = FontWeights.Bold;
            cafeResultBox.Margin = new Thickness(0, 10, 0, 0);

            StackPanel cafeResultRow = new StackPanel();
            cafeResultRow.Orientation = Orientation.Horizontal;
            cafeResultRow.HorizontalAlignment = HorizontalAlignment.Center;

            resultCafe = new TextBlock();
            resultCafe.Text = "0.00";
            resultCafe.FontSize = 18;
            resultCafe.FontWeight = FontWeights.Bold;
            resultCafe.Background = new SolidColorBrush(Color.FromRgb(255, 249, 196));
            resultCafe.Padding = new Thickness(10);
            resultCafe.MinWidth = 80;
            resultCafe.TextAlignment = TextAlignment.Center;

            TextBlock unitCafe = new TextBlock();
            unitCafe.Text = "руб.";
            unitCafe.FontSize = 16;
            unitCafe.VerticalAlignment = VerticalAlignment.Center;
            unitCafe.Margin = new Thickness(5, 0, 0, 0);

            cafeResultRow.Children.Add(resultCafe);
            cafeResultRow.Children.Add(unitCafe);
            cafeResultBox.Content = cafeResultRow;
            cafePanel.Children.Add(cafeResultBox);

            cafeBox.Content = cafePanel;
            Grid.SetColumn(cafeBox, 1);
            grid.Children.Add(cafeBox);

            mainPanel.Children.Add(grid);

            // НИЗ
            Border bottom = new Border();
            bottom.Background = Brushes.White;
            bottom.CornerRadius = new CornerRadius(8);
            bottom.Padding = new Thickness(15);
            bottom.BorderBrush = new SolidColorBrush(Color.FromRgb(144, 202, 249));
            bottom.BorderThickness = new Thickness(1);

            StackPanel bottomPanel = new StackPanel();

            StackPanel totalRow = new StackPanel();
            totalRow.Orientation = Orientation.Horizontal;
            totalRow.HorizontalAlignment = HorizontalAlignment.Center;
            totalRow.Margin = new Thickness(0, 0, 0, 10);
            totalRow.Children.Add(new TextBlock() { Text = "ИТОГО: ", FontSize = 18, FontWeight = FontWeights.Bold, VerticalAlignment = VerticalAlignment.Center });

            textTotal = new TextBox();
            textTotal.Text = "0.00";
            textTotal.FontSize = 18;
            textTotal.FontWeight = FontWeights.Bold;
            textTotal.Background = new SolidColorBrush(Color.FromRgb(200, 230, 201));
            textTotal.IsReadOnly = true;
            textTotal.TextAlignment = TextAlignment.Center;
            textTotal.Width = 150;
            totalRow.Children.Add(textTotal);
            totalRow.Children.Add(new TextBlock() { Text = " руб.", FontSize = 18, FontWeight = FontWeights.Bold, VerticalAlignment = VerticalAlignment.Center });
            bottomPanel.Children.Add(totalRow);

            Button btnCalc = new Button();
            btnCalc.Content = "Рассчитать";
            btnCalc.Width = 140;
            btnCalc.Height = 40;
            btnCalc.FontWeight = FontWeights.Bold;
            btnCalc.Background = new SolidColorBrush(Color.FromRgb(76, 175, 80));
            btnCalc.Foreground = Brushes.White;
            btnCalc.Margin = new Thickness(5);
            btnCalc.Click += BtnCalcClick;
            bottomPanel.Children.Add(btnCalc);

            bottom.Child = bottomPanel;
            mainPanel.Children.Add(bottom);

            this.Content = mainPanel;

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += TimerTick;

            UpdatePrice();
        }

        void ComboFuelChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrice();
            Calc();
        }

        void UpdatePrice()
        {
            Fuel f = (Fuel)comboFuel.SelectedItem;
            if (f != null)
                labelPrice.Text = "Цена: " + f.Price.ToString("F2") + " руб/л";
        }

        void RadioChanged(object sender, RoutedEventArgs e)
        {
            if (radioLiters.IsChecked == true)
            {
                textLiters.IsEnabled = true;
                textAmount.IsEnabled = false;
                groupFuelResult.Header = "К оплате";
                unitFuel.Text = "руб.";
            }
            else
            {
                textLiters.IsEnabled = false;
                textAmount.IsEnabled = true;
                groupFuelResult.Header = "К выдаче";
                unitFuel.Text = "л.";
            }
            textLiters.Text = "";
            textAmount.Text = "";
            Calc();
        }

        void CafeCheckChanged(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (cafeChecks[i] == sender)
                {
                    cafeQtys[i].IsEnabled = cafeChecks[i].IsChecked == true;
                    if (!cafeQtys[i].IsEnabled)
                        cafeQtys[i].Text = "0";
                }
            }
            Calc();
        }

        void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            Calc();
        }

        void Calc()
        {
            Fuel f = (Fuel)comboFuel.SelectedItem;
            decimal fuelTotal = 0;

            if (f != null)
            {
                if (radioLiters.IsChecked == true)
                {
                    decimal liters;
                    if (decimal.TryParse(textLiters.Text, out liters) && liters > 0)
                        fuelTotal = liters * f.Price;
                }
                else
                {
                    decimal amount;
                    if (decimal.TryParse(textAmount.Text, out amount) && amount > 0)
                        fuelTotal = amount / f.Price;
                }
            }

            resultFuel.Text = fuelTotal.ToString("F2");

            decimal cafeTotal = 0;
            for (int i = 0; i < 6; i++)
            {
                if (cafeChecks[i].IsChecked == true)
                {
                    int qty;
                    if (int.TryParse(cafeQtys[i].Text, out qty) && qty > 0)
                        cafeTotal += cafePrices[i] * qty;
                }
            }

            resultCafe.Text = cafeTotal.ToString("F2");
            textTotal.Text = (fuelTotal + cafeTotal).ToString("F2");
        }

        void BtnCalcClick(object sender, RoutedEventArgs e)
        {
            decimal total;
            if (decimal.TryParse(textTotal.Text, out total) && total > 0)
            {
                totalRevenue += total;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Ничего не выбрано!");
            }
        }

        void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBoxResult result = MessageBox.Show("Очистить форму?", "Новый клиент", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                comboFuel.SelectedIndex = 0;
                radioLiters.IsChecked = true;
                textLiters.Text = "";
                textAmount.Text = "";
                groupFuelResult.Header = "К оплате";
                unitFuel.Text = "руб.";
                for (int i = 0; i < 6; i++)
                {
                    cafeChecks[i].IsChecked = false;
                    cafeQtys[i].Text = "0";
                    cafeQtys[i].IsEnabled = false;
                }
            }
            else
            {
                timer.Start();
            }
        }
    }
}
