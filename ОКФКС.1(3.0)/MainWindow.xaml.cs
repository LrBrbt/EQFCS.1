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

namespace ОКФКС._1_3._0_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] array;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void InfoBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №1 по дисциплине ОКФКС\nВыполнила студентка группы ИСП-31 Погодина В." +
                "\nДмитрий Александрович, спасибо, что проверили работоспособность кнопки :3");
        }

        private void numbersTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            numbersTB.Foreground = Brushes.Black;
        }

        private void calculateBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsAuthorized.result == true)
                {
                    array = numbersTB.Text.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                    if (array.Length != 3)
                    {
                        MessageBox.Show("Вы ввели не три числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (array.Length == 3)
                    {
                        int result = Average(array);

                        if (array[0] <= result)
                        {
                            resultTB.Text = Math.Round(Math.Sin(array[0]), 2).ToString();
                        }
                        else if (array[1] <= result)
                        {
                            resultTB.Text = Math.Round(Math.Cos(array[1]), 2).ToString();
                        }
                        else if (array[2] <= result)
                        {
                            resultTB.Text = Math.Round(Math.Tan(Math.Abs(array[2])), 2).ToString();
                        }
                        else
                        {
                            resultTB.Text = "0";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы должны авторизоваться, чтобы работать с программой");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте, правильность введенных данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        static int Average(int[] array)
        {
            int sum = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum / array.Length;

        }

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            Авторизация LogInWindow = new();
            LogInWindow.Owner = this;
            LogInWindow.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            numbersTB.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("Вы желаете завершить работу с программой?", "Выход из программы", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
