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
using System.Windows.Shapes;

namespace ОКФКС._1_3._0_
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        
        public Авторизация()
        {
            InitializeComponent();
        }
        const string adminPassword = "admin123";
        const string operatorPassword = "operator456";
        const string userPassword = "1234567890";
        
        private void Window_Activated(object sender, EventArgs e)
        {
            login_TB.Focus();
            
        }

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            login_TB.Text.ToLower();
            login_TB.Text.Trim();
            if(login_TB.Text == "admin" && passwordPB.Password == adminPassword)
            {
                IsAuthorized.result = true;
                MessageBox.Show("Добро пожаловать, админ!");
              
                
                AdminWindow adminWindow = new();
                adminWindow.Owner = this;

                Hide();
                this.Owner.Hide();

                adminWindow.ShowDialog();

           

            }
            else if(login_TB.Text == "operator" && passwordPB.Password == operatorPassword)
            {
                IsAuthorized.result = true;
                MessageBox.Show("Добро пожаловать, оператор!");

                OperatorWindow operatorWindow = new();
                operatorWindow.Owner = this;

                Hide();
                this.Owner.Hide();

                operatorWindow.ShowDialog();
                Close();
            }
            else if(login_TB.Text == "user" && passwordPB.Password == userPassword)
            {
                IsAuthorized.result = true;
                MessageBox.Show("Добро пожаловать, пользователь!");
                
                Close();
            }
        }

        private void login_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_TB.Foreground = Brushes.Black;
        }

        private void ForgotPasswordBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для пользователя admin - admin123\nДля пользователя operator - operator456\nДля пользователя user - 1234567890");
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Учтите, что чтобы пользоваться программой, необходимо пройти авторизацию.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            Close();
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
