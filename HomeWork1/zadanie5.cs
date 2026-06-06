using System;
using System.Collections.Generic;
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
        private const int EscapeDistance = 150; 
        private readonly Random _random = new Random();
        private Canvas canvas;
        private Border border;
        public MainWindow()
        {
          
            InitializeComponent();

            canvas = new Canvas();
            canvas.Background = Brushes.White;

            border = new Border();
            border.Width = 100;
            border.Height = 50;
            border.Background = Brushes.Green ;

            Canvas.SetLeft(border, 100);
            Canvas.SetTop(border, 100);

            canvas.Children.Add(border);

            this.Content = canvas;

          
            canvas.MouseMove += Window_MouseMove;
            
            this.Height = 450;
            this.Width = 800;
        }


        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           
            Point mousePos = e.GetPosition(canvas);

            
            double staticLeft = Canvas.GetLeft(border);
            double staticTop = Canvas.GetTop(border);
            double staticWidth = border.ActualWidth;
            double staticHeight = border.ActualHeight;

          
            double staticCenterX = staticLeft + staticWidth / 2;
            double staticCenterY = staticTop + staticHeight / 2;

            
            double distance = Math.Sqrt(
                Math.Pow(mousePos.X - staticCenterX, 2) +
                Math.Pow(mousePos.Y - staticCenterY, 2));

           
            if (distance < EscapeDistance)
            {
               
                double deltaX = staticCenterX - mousePos.X;
                double deltaY = staticCenterY - mousePos.Y;

              
                double length = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                if (length > 0)
                {
                    deltaX /= length;
                    deltaY /= length;
                }

                double speedMultiplier = 1 - (distance / EscapeDistance);
                double moveDistance = EscapeDistance * 0.3 * speedMultiplier;
                double newLeft = staticLeft + deltaX * moveDistance;
                double newTop = staticTop + deltaY * moveDistance;
                double maxLeft = canvas.ActualWidth - staticWidth;
                double maxTop = canvas.ActualHeight - staticHeight;

                newLeft = Math.Max(0, Math.Min(newLeft, maxLeft));
                newTop = Math.Max(0, Math.Min(newTop, maxTop));

             
                if (newLeft <= 0 || newLeft >= maxLeft)
                {
                    newTop += (_random.NextDouble() - 0.5) * 50;
                    newLeft = Math.Max(0, Math.Min(newLeft, maxLeft));
                }
                if (newTop <= 0 || newTop >= maxTop)
                {
                    newLeft += (_random.NextDouble() - 0.5) * 50;
                    newTop = Math.Max(0, Math.Min(newTop, maxTop));
                }
         Canvas.SetLeft(border, newLeft);
                Canvas.SetTop(border, newTop);
            }
        }



    }
}
