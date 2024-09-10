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

namespace FreightChelCompanyProject.PagesOfManager
{
    /// <summary>
    /// Вспомогательная страница менеджера, содержащая информацию о заявках.
    /// </summary>
    public partial class ManagerRequestsPage : Page
    {
        public ManagerRequestsPage()
        {
            InitializeComponent();
            List<string> statusList = new List<string>
            {
                "Любой",
                "На проверке",
                "Одобрена",
                "Отказана"
            };
            choseSearchStatusRequest.ItemsSource = statusList;
            choseSearchStatusRequest.SelectedIndex = 0;
        }

        private void ButtonAddOrderClick(object sender, RoutedEventArgs e)
        {
            if (FrameSector.ManagerFrame.Content is ManagerOrdersPage)
            {
                Requests request = (sender as Button).DataContext as Requests;
                if (request.Status != "Одобрена")
                {
                    MessageBox.Show("Данная заявка не одобрена!", "Внимание");
                }
                else
                {
                    FrameSector.ManagerAssistFrame.Navigate(new ManagerTargetRequestInfo(request));
                    FrameSector.ManagerFrame.Navigate(new ManagerAddNewOrder(request, null));
                }
            }
        }
        public int UpdateRequests()
        {
            var checkOrders = FreightChelCompanyEntities.GetContext().Orders;
            var checkRequests = FreightChelCompanyEntities.GetContext().Requests.Where(p => !checkOrders.Any(c => c.Id == p.Id) && p.ArchStatus != 1).ToList();

            if (choseSearchStatusRequest.SelectedIndex > 0)
                checkRequests = checkRequests.Where(p => p.Status == choseSearchStatusRequest.SelectedItem.ToString()).ToList();

            checkRequests = checkRequests.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumRequest.Text.ToLower())).ToList();

            if (checkRequests.Count() <= 0)
            {
                SearchNullRequests();
                return 0;
            }
            else
            {
                listViewRequests.ItemsSource = checkRequests;
                return 1;
            }
        }

        private void ButtonSearchRequests(object sender, RoutedEventArgs e)
        {
            if (UpdateRequests() == 0)
                MessageBox.Show("По вашему запросу заявок не найдено!", "Внимание");
        }

        private void SearchNullRequests()
        {
            var checkOrders = FreightChelCompanyEntities.GetContext().Orders;
            choseSearchStatusRequest.SelectedIndex = 0;
            inputSearchNumRequest.Text = "";
            listViewRequests.ItemsSource = FreightChelCompanyEntities.GetContext().Requests.Where(p => !checkOrders.Any(c => c.Id == p.Id) && p.ArchStatus != 1).ToList();
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullRequests();
        }
        private void InputSearchNumOrderPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char symbol in e.Text)
            {
                if (!Char.IsDigit(symbol))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}