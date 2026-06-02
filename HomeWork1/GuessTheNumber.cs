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
    public partial class MainWindow : Window
    {
        private string textResume;
       private int attempts =0;
        private int min = 0;
        private int max = 2000;
        private bool playAgain = true;
        public MainWindow()
        {
            InitializeComponent();

            StartGame();
            while (playAgain)
            {
                MidGame();
                PlayAgain();
            }
           
        }



        private void StartGame()
        {
            MessageBox.Show("Задумайте число от 1 до 2000.\nНажмите OK, когда будете готовы.",
                 "Угадай число",
                 MessageBoxButton.OK,
                 MessageBoxImage.Information);
        }

        private void MidGame()
        {
            attempts++;
            var random = new Random();
            int number = random.Next(min, max);
            MessageBoxResult result = MessageBox.Show(
                        $"Ваше число равно {number}?",
                        $"Попытка #{attempts}",
                        MessageBoxButton.YesNoCancel,  
                        MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show(
                           $"Я угадал! Это число {number}.\n" +
                           $"Потребовалось попыток: {attempts}",
                           "Победа!",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);

               
            }

            else if (result == MessageBoxResult.No)
            {

                MessageBoxResult direction = MessageBox.Show(
                               $"Ваше число больше , чем {number}?",
                               "Подсказка",
                               MessageBoxButton.YesNo,
                               MessageBoxImage.Question);


                if (direction == MessageBoxResult.Yes)
                {
                    min = number + 1;

                }
                else if(direction == MessageBoxResult.No) { 
                  max = number - 1;
                }
            }
        }


        private void PlayAgain()
        {
            MessageBoxResult playChoice = MessageBox.Show(
                       "Хотите сыграть еще раз?",
                       "Новая игра",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question);

            if (playChoice == MessageBoxResult.Yes) {
            playAgain = true;
            }
            else if(playChoice == MessageBoxResult.No)
            {
                playAgain = false;
            }
        }
    }
}
