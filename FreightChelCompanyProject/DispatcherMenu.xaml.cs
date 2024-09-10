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
using FreightChelCompanyProject.PagesOfDispatcher;

namespace FreightChelCompanyProject
{
    /// <summary>
    /// Главное рабочее окно диспетчера.
    /// </summary>
    public partial class DispatcherMenu : Window
    {
        public DispatcherMenu()
        {
            InitializeComponent();
            FrameSector.DispatcherFrame = dispatcherTargetFrame;
            FrameSector.DispatcherAssistFrame = dispatcherAssistFrame;
            textUserPosition.Text = "Диспетчер " + LoginSector.Name + " | Уникальный номер [" + LoginSector.UserId + "]";
            buttonAssistUp.Visibility = Visibility.Collapsed;

            FrameSector.DispatcherAssistFrame.Navigate(new DispatcherAssistPage());
            FrameSector.DispatcherFrame.Navigate(new DispatcherRequestsPage());
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

        private void ButtonAddRequestClick(object sender, RoutedEventArgs e)
        {
            if (FrameSector.DispatcherFrame.Content is DispatcherRequestsPage)
            {
                FrameSector.DispatcherFrame.Navigate(new DispatcherAddNewRequest(null));
            }
        }

        private void ButtonRebootClick(object sender, RoutedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DispatcherMenu dispatcherMenu = new DispatcherMenu();
            dispatcherMenu.Show();
            this.Close();
        }
    }
}