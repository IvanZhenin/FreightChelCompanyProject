using FreightChelCompanyProject.AppData;
using FreightChelCompanyProject.PagesOfManager;
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

namespace FreightChelCompanyProject
{
    /// <summary>
    /// Главное рабочее окно менеджера.
    /// </summary>
    public partial class ManagerMenu : Window
    {
        public ManagerMenu()
        {
            InitializeComponent();
            FrameSector.ManagerFrame = managerTargetFrame;
            FrameSector.ManagerAssistFrame = managerAssistFrame;
            textUserPosition.Text = "Менеджер " + LoginSector.Name + " | Уникальный номер [" + LoginSector.UserId + "]";
            buttonAssistUp.Visibility = Visibility.Collapsed;

            FrameSector.ManagerAssistFrame.Navigate(new ManagerRequestsPage());
            FrameSector.ManagerFrame.Navigate(new ManagerOrdersPage());
        }

        private void ButtonLogoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonAssistClick(object sender, RoutedEventArgs e)
        {
            if (buttonAssistUp.Visibility == Visibility.Collapsed)
            {
                buttonAssistUp.Visibility = Visibility.Visible;
                buttonAssistBack.Visibility = Visibility.Collapsed;
                assistColumn.MaxWidth = 0;
            }
            else
            {
                buttonAssistUp.Visibility = Visibility.Collapsed;
                buttonAssistBack.Visibility = Visibility.Visible;
                assistColumn.MaxWidth = 650;
            }
        }
        private void ButtonRebootClick(object sender, RoutedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ManagerMenu managerMenu = new ManagerMenu();
            managerMenu.Show();
            this.Close();
        }
    }
}