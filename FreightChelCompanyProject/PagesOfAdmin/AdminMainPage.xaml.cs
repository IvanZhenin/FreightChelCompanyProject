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

namespace FreightChelCompanyProject.PagesOfAdmin
{
    /// <summary>
    /// Главная страница администратора, панель, содержащая ссылки с переходом на страницы управлением разными данными.
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void ButtonPickupPointsClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminPickupPointsPage());
        }

        private void ButtonProductsCategoriesClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminProductsCategoriesPage());
        }

        private void ButtonClientsWorkersClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminWorkersClientsPage());
        }

        private void ButtonOrdersReportsClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminOrdersReportsPage());
        }

        private void ButtonOrdersStatsClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminCheckOrderStatsPage());
        }
    }
}