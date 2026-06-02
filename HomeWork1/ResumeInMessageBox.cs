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
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                TextResume(i);
            }
        }

        private void TextResume(int x)
        {


            switch (x)
            {
                case 0:

                    MessageBox.Show("**Sarmat**\r\nЖелаемая должность: System Developer (Junior)\r\nEmail: xxxxxxxxxxxxxx@gmail.com", " Пользовательские данные");
                    break;
                case 1:
                    MessageBox.Show("\r\n\r\nМотивированный начинающий разработчик с фундаментальными знаниями в области системного программирования и разработки игр. Имеет практический опыт работы с языками C++, C# и Rust, а также движком Unreal Engine 5. Стремится применить академические знания и самообучение для решения сложных технических задач в роли Junior System Developer. Быстро обучаем, ориентирован на качество кода и оптимизацию производительности.\r\n", "Профессиональный профиль");
                    break;
                case 2:
                    MessageBox.Show("*   **Языки программирования:** C++ (Base), C# (Elementary), Rust (Elementary).\r\n*   **Игровые движки и инструменты:** Unreal Engine 5 (UE5).\r\n*   **Сетевое программирование:** WFP (Windows Filtering Platform) — базовое понимание принципов работы и фильтрации трафика.\r\n*   **Общие компетенции:** Понимание основ системной архитектуры, алгоритмов и структур данных, умение читать техническую документацию.", "Ключевые навыки");
                    break;
                case 3:
                    MessageBox.Show("\r\n**Начинающий разработчик / Самообразование**\r\n*Период: [Текущее время] – Настоящее время*\r\n\r\n*   Изучение принципов системного программирования и управления памятью на примере C++ и Rust.\r\n*   Практическое применение знаний в среде Unreal Engine 5: создание прототипов, работа с Blueprint и C++ кодом.\r\n*   Исследование механизмов сетевого взаимодействия и безопасности на уровне ОС (WFP).\r\n*   Написание тестовых проектов для закрепления синтаксиса и логики работы с C#.", "Опыт работы");
                    break;
                case 4:
                    MessageBox.Show("**AcademyTOP**\r\n*Специализация: Программирование и разработка программного обеспечения*\r\n\r\n*   Освоение базовых концепций информатики и алгоритмического мышления.\r\n*   Практические занятия по написанию кода на языках высокого уровня.\r\n", "Образование     (среднее 145.67 символов)");
                    break;
            }

        }

    }
}
