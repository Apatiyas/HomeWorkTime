using System;
using System.Collections.Generic;
using System.Linq;
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

    public class Static
    {
        public int ordinalNumber { get; set; } = 0;
        public Border border { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

    }
    public partial class MainWindow : Window
    {
        private string textResume;
        private Point startPos;
        private Point endPos;
        private Canvas canvas;
        private List<Static> list = new List<Static>();
        
        private int nextNumber = 1;
        private bool isDrawing = false;
        public MainWindow()
        {
          
            InitializeComponent();
            this.MouseLeftButtonDown += Window_MouseLeftButtonDown;
            this.MouseLeftButtonUp += Window_MouseLeftButtonUp;
            this.MouseRightButtonDown += Window_MouseRightButtonDown;
        

            this.MouseMove += MainWindow_MouseMove;
             canvas = new Canvas();
            canvas.Background = Brushes.White;
            this.SizeChanged += (s, e) =>
            {
                canvas.Width = this.ActualWidth;
                canvas.Height = this.ActualHeight;
            };
            this.Content =canvas;


        }

     

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (e.ClickCount == 2)
                {
                    
                    double xM = e.GetPosition(canvas).X;
                    double yM = e.GetPosition(canvas).Y;

                    Static minStatic = null;
                    foreach (var item in list)
                    {
                        if (xM >= item.X && xM <= item.X + item.Width &&
                            yM >= item.Y && yM <= item.Y + item.Height)
                        {
                            if (minStatic == null)
                            {
                                minStatic = item;
                            }
                            else if (minStatic.ordinalNumber > item.ordinalNumber)
                            {
                                minStatic = item;
                            }
                        }
                    }

                    if (minStatic != null)
                    {
                        list.Remove(minStatic);
                        canvas.Children.Remove(minStatic.border);
                    }

                    return; // Не начинаем рисование
                }
            }
            else if (e.ClickCount == 1)
            {
                Point endPos = e.GetPosition(canvas);

                if (Math.Abs(endPos.X - startPos.X) < 10 || Math.Abs(endPos.Y - startPos.Y) < 10)
                {
                    MessageBox.Show("error static < 10X10");
                    return;
                }



                TextBlock textBlock = new TextBlock();
                textBlock.Text = nextNumber.ToString();
                textBlock.Foreground = Brushes.Black;
                textBlock.FontSize = 14;
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;

                Static statics = new Static();
                statics.border = new Border();
                statics.ordinalNumber = nextNumber;
                statics.border.Background = Brushes.Green;
                statics.Width = Math.Abs(endPos.X - startPos.X);
                statics.Height = Math.Abs(endPos.Y - startPos.Y);
                statics.border.Width = statics.Width;
                statics.border.Height = statics.Height;
                statics.X = Math.Min(endPos.X, startPos.X);
                statics.Y = Math.Min(endPos.Y, startPos.Y);
                Canvas.SetLeft(statics.border, statics.X);
                Canvas.SetTop(statics.border, statics.Y);
                canvas.Children.Add(statics.border);
               statics.border.Child = textBlock;
                list.Add(statics);


                nextNumber++;
            } 
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPos = e.GetPosition(this);

            

        }
        





        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
         double xM = e.GetPosition(this).X;
         double yM = e.GetPosition(this).Y;
            Static maxStatic = null;
            foreach (var item in list) {
                if (xM >= item.X && xM <= item.X + item.Width &&
                   yM >= item.Y && yM <= item.Y + item.Height)
                {
                    if (maxStatic == null)
                    {
                        maxStatic = item;
                    }
                    else if (maxStatic.ordinalNumber < item.ordinalNumber)
                    {
                        maxStatic = item;
                    }

                   
                }

               
            }
            if (maxStatic != null)
            {
                double area = maxStatic.Width * maxStatic.Height;
                this.Title = $"Статик #{maxStatic.ordinalNumber}: площадь={area}, координаты=({maxStatic.X}, {maxStatic.Y})";
            }

        }

        
    }
}
