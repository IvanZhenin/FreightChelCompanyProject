using FreightChelCompanyProject.AppData;
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

namespace FreightChelCompanyProject
{
    /// <summary>
    /// Окно авторизации пользователя.
    /// </summary>
    public partial class MainWindow : Window
    {
        private int ErrorSeconds = 5000;
        public MainWindow()
        {
            InitializeComponent();
            
            if (LoginSector.IsLoggedIn == true)
            {
                inputLoginText.Text = LoginSector.Login;
                inputPasswordText.Password = LoginSector.Password;
                checkRememberLogin.IsChecked = true;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки входа в аккаунт.
        /// </summary>
        private async void ButtonAutorisationCheck(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(inputLoginText.Text) || String.IsNullOrEmpty(inputPasswordText.Password))
            {
                MessageBox.Show("Пожалуйста, заполните оба поля!");
            }
            else
            {
                var targetUser = FreightChelCompanyEntities.GetContext().Workers.
                    Where(p => p.Login == inputLoginText.Text && p.Password == inputPasswordText.Password).ToList();

                if (targetUser.Count() > 0)
                {
                    LoginSector.UserId = targetUser[0].Id;
                    LoginSector.RoleId = targetUser[0].RoleId;
                    LoginSector.Name = targetUser[0].Name;
                    LoginSector.Login = targetUser[0].Login;
                    LoginSector.Password = targetUser[0].Password;

                    if (checkRememberLogin.IsChecked == true)
                    {
                        LoginSector.IsLoggedIn = true;
                    }
                    else
                    {
                        LoginSector.IsLoggedIn = false;
                    }

                    if (LoginSector.RoleId == 1)
                    {
                        DispatcherMenu dispatcherMenu = new DispatcherMenu();
                        dispatcherMenu.Show();
                        this.Close();
                    }
                    else if (LoginSector.RoleId == 2)
                    {
                        ManagerMenu managerMenu = new ManagerMenu();
                        managerMenu.Show();
                        this.Close();
                    }
                    else if (LoginSector.RoleId == 3)
                    {
                        BookerMenu bookerMenu = new BookerMenu();
                        bookerMenu.Show();
                        this.Close();
                    }
                    else
                    {
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show($"Неверно введен логин или пароль! Повторите следующую попытку через {ErrorSeconds / 1000} секунд.");
                    buttAuto.IsEnabled = false;
                    await Task.Delay(ErrorSeconds);
                    buttAuto.IsEnabled = true;
                    if (ErrorSeconds < 30000)
                    {
                        ErrorSeconds += 5000;
                    }
                }
            }
        }
    }
}