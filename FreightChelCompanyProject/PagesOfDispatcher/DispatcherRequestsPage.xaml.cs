using FreightChelCompanyProject.AppData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

namespace FreightChelCompanyProject.PagesOfDispatcher
{
    /// <summary>
    /// Страница диспетчера, предназначенная для работы с заявками.
    /// </summary>
    public partial class DispatcherRequestsPage : Page
    {
        private List <int> clientIds = new List<int>() { 0 };
        public DispatcherRequestsPage()
        {
            InitializeComponent();
            List<string> statusList = new List<string>
            {
                "Любой",
                "На проверке",
                "Одобрена",
                "Отказана"
            };

            List<string> clientList = new List<string>() { "Любой" };
            foreach(var client in FreightChelCompanyEntities.GetContext().Clients)
            {
                clientList.Add(client.Id + ". " + client.Name);
                clientIds.Add(client.Id);
            }

            choseSearchStatusRequest.ItemsSource = statusList;
            choseSearchStatusRequest.SelectedIndex = 0;
            choseSearchClientRequest.ItemsSource = clientList;
            choseSearchClientRequest.SelectedIndex = 0;
        }

        public int UpdateRequests()
        {
            var checkRequests = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.NumWorker == LoginSector.UserId && p.ArchStatus != 1).ToList();

            if (choseSearchStatusRequest.SelectedIndex > 0)
                checkRequests = checkRequests.Where(p => p.Status == choseSearchStatusRequest.SelectedItem.ToString()).ToList();

            if (choseSearchClientRequest.SelectedIndex > 0)
                checkRequests = checkRequests.Where(p => p.Clients.Id == clientIds[choseSearchClientRequest.SelectedIndex]).ToList();

            checkRequests = checkRequests.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumRequest.Text.ToLower())).ToList();
            checkRequests = checkRequests.Where(p => p.AddressDel.ToLower().Contains(inputSearchAddressRequest.Text.ToLower())).ToList();

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
            choseSearchStatusRequest.SelectedIndex = 0;
            choseSearchClientRequest.SelectedIndex = 0;
            inputSearchNumRequest.Text = "";
            inputSearchAddressRequest.Text = "";
            listViewRequests.ItemsSource = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.NumWorker == LoginSector.UserId && p.ArchStatus != 1).ToList();
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullRequests();
        }

        private void ButtonEditRequestClick(object sender, RoutedEventArgs e)
        {
            Requests request = (sender as Button).DataContext as Requests;
            var orderCheck = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.Id == request.Id).ToList();
            if (orderCheck.Count() > 0)
            {
                MessageBox.Show("Вы не можете внести изменения, так как по данной заявке уже сформирован заказ!", "Внимание");
            }
            else
            {
                FrameSector.DispatcherFrame.Navigate(new DispatcherAddNewRequest(request));
            }
        }

        private void ButtonGoProdsInRequestClick(object sender, RoutedEventArgs e)
        {
            FrameSector.DispatcherFrame.Navigate(new DispatcherProductsInRequestPage((sender as Button).DataContext as Requests));
        }

        private void InputSearchNumRequestPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach(char symbol in e.Text)
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