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
using System.Windows.Shapes;
using FreightChelCompanyProject.PagesOfAdmin;

namespace FreightChelCompanyProject
{
    /// <summary>
    /// Главное рабочее окно администратора.
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
            FrameSector.AdminFrame = adminTargetFrame;
            textUserPosition.Text = "Администратор " + LoginSector.Name + " | Уникальный номер [" + LoginSector.UserId + "]";

            FrameSector.AdminFrame.Navigate(new AdminMainPage());
        }

        private void ButtonLogoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void ButtonRebootClick(object sender, RoutedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}