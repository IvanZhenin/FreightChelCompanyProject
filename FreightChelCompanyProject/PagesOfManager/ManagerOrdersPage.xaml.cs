using FreightChelCompanyProject.AppData;
using FreightChelCompanyProject.PagesOfBooker;
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

namespace FreightChelCompanyProject.PagesOfManager
{
    /// <summary>
    /// Страница менеджера, предназначенная для работы с заказами.
    /// </summary>
    public partial class ManagerOrdersPage : Page
    {
        private List<int> clientIds = new List<int>() { 0 };
        public ManagerOrdersPage()
        {
            InitializeComponent();
            List<string> statusList = new List<string>
            {
                "Любой",
                "В ожидании",
                "Выполняется",
                "Выполнен",
                "Отменен"
            };

            List<string> clientList = new List<string>() { "Любой" };
            foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
            {
                clientList.Add(client.Id + ". " + client.Name);
                clientIds.Add(client.Id);
            }

            choseSearchStatusOrder.ItemsSource = statusList;
            choseSearchStatusOrder.SelectedIndex = 0;
            choseSearchClientOrder.ItemsSource = clientList;
            choseSearchClientOrder.SelectedIndex = 0;
        }

        public int UpdateOrders()
        {
            var checkOrders = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.NumWorker == LoginSector.UserId && p.ArchStatus != 1).ToList();

            if (choseSearchStatusOrder.SelectedIndex > 0)
                checkOrders = checkOrders.Where(p => p.Status == choseSearchStatusOrder.SelectedItem.ToString()).ToList();

            if (choseSearchClientOrder.SelectedIndex > 0)
                checkOrders = checkOrders.Where(p => p.Requests.Clients.Id == clientIds[choseSearchClientOrder.SelectedIndex]).ToList();
            
            checkOrders = checkOrders.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumOrder.Text.ToLower())).ToList();
            checkOrders = checkOrders.Where(p => p.Requests.AddressDel.ToString().ToLower().Contains(inputSearchAddressOrder.Text.ToLower())).ToList();

            if (checkOrders.Count() <= 0)
            {
                SearchNullOrders();
                return 0;
            }
            else
            {
                listViewOrders.ItemsSource = checkOrders;
                return 1;
            }
        }
        private void ButtonSearchOrders(object sender, RoutedEventArgs e)
        {
            if (UpdateOrders() == 0)
                MessageBox.Show("По вашему запросу заказов не найдено!", "Внимание");
        }

        private void SearchNullOrders()
        {
            choseSearchStatusOrder.SelectedIndex = 0;
            choseSearchClientOrder.SelectedIndex = 0;
            inputSearchNumOrder.Text = "";
            inputSearchAddressOrder.Text = "";
            listViewOrders.ItemsSource = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.NumWorker == LoginSector.UserId && p.ArchStatus != 1).ToList();
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullOrders();
        }

        private void ButtonEditOrderClick(object sender, RoutedEventArgs e)
        {
            Orders order = (sender as Button).DataContext as Orders;
            var currentRequest = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.Id == order.Id).First();
            var reportCheck = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.Id == order.Id).ToList();

            if (reportCheck.Count() > 0)
            {
                MessageBox.Show("Вы не можете внести изменения, так как по данному заказу уже сформирован отчет!", "Внимание");
            }
            else
            {
                FrameSector.ManagerFrame.Navigate(new ManagerAddNewOrder(currentRequest, order));
                FrameSector.ManagerAssistFrame.Navigate(new ManagerTargetRequestInfo(currentRequest));
            }
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