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
    /// Страница амдинистратора, предназначенная для управления заказами и отчетами.
    /// </summary>
    public partial class AdminOrdersReportsPage : Page
    {
        private List<string> clientNames = new List<string>() { "Любой" };
        private List<int> clientId = new List<int>() { 0 };
        private List<string> dispatcherNames = new List<string>() { "Любой" };
        private List<int> dispatcherId = new List<int>() { 0 };
        private List<string> managerNames = new List<string>() { "Любой" };
        private List<int> managerId = new List<int>() { 0 };
        private List<string> bookerNames = new List<string>() { "Любой" };
        private List<int> bookerId = new List<int>() { 0 };
        private List<string> statusListRequest = new List<string>()
        {
            "Любой",
            "На проверке",
            "Одобрена",
            "Отказана"
        };
        private List<string> statusList = new List<string>()
        {
            "Любой",
            "В ожидании",
            "Выполняется",
            "Выполнен",
            "Отказан"
        };

        public AdminOrdersReportsPage()
        {
            InitializeComponent();
            List <string> archList = new List<string>() { "Нет", "Да" };
            choseSearchArchStatusRequest.ItemsSource = archList;
            choseSearchArchStatusRequest.SelectedIndex = 0;
            choseSearchArchStatusOrder.ItemsSource = archList;
            choseSearchArchStatusOrder.SelectedIndex = 0;
            choseSearchArchStatusReport.ItemsSource = archList;
            choseSearchArchStatusReport.SelectedIndex = 0;

            foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
            {
                clientNames.Add(client.Id.ToString() + ". " + client.Name);
                clientId.Add(client.Id);
            }
            choseSearchClientRequest.ItemsSource = clientNames;
            choseSearchClientRequest.SelectedIndex = 0;
            choseSearchClientOrder.ItemsSource = clientNames;
            choseSearchClientOrder.SelectedIndex = 0;

            foreach (var worker in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 1))
            {
                dispatcherNames.Add(worker.Id.ToString() + ". " + worker.Name);
                dispatcherId.Add(worker.Id);
            }
            choseSearchWorkerRequest.ItemsSource = dispatcherNames;
            choseSearchWorkerRequest.SelectedIndex = 0;

            choseSearchStatusRequest.ItemsSource = statusListRequest;
            choseSearchStatusRequest.SelectedIndex = 0;

            foreach (var worker in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 2))
            {
                managerNames.Add(worker.Id.ToString() + ". " + worker.Name);
                managerId.Add(worker.Id);
            }
            choseSearchWorkerOrder.ItemsSource = managerNames;
            choseSearchWorkerOrder.SelectedIndex = 0;

            choseSearchStatusOrder.ItemsSource = statusList;
            choseSearchStatusOrder.SelectedIndex = 0;

            foreach (var worker in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 3))
            {
                bookerNames.Add(worker.Id.ToString() + ". " + worker.Name);
                bookerId.Add(worker.Id);
            }
            choseSearchWorkerReport.ItemsSource = bookerNames;
            choseSearchWorkerReport.SelectedIndex = 0;
        }

        private void ButtonEditOrderClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminEditManagerOrder((sender as Button).DataContext as Orders));
        }

        private void SearchNullRequests()
        {
            choseSearchWorkerRequest.SelectedIndex = 0;
            choseSearchStatusRequest.SelectedIndex = 0;
            choseSearchClientRequest.SelectedIndex = 0;
            choseSearchArchStatusRequest.SelectedIndex = 0;
            inputSearchNumRequest.Text = "";
            inputSearchAddressRequest.Text = "";
            listViewRequests.ItemsSource = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.ArchStatus != 1).ToList();
        }

        private void SearchNullOrders()
        {
            choseSearchWorkerOrder.SelectedIndex = 0;
            choseSearchStatusOrder.SelectedIndex = 0;
            choseSearchClientOrder.SelectedIndex = 0;
            choseSearchArchStatusOrder.SelectedIndex = 0;
            inputSearchNumOrder.Text = "";
            inputSearchAddressOrder.Text = "";
            listViewOrders.ItemsSource = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.ArchStatus != 1).ToList();
        }

        private void SearchNullReports()
        {
            choseSearchWorkerReport.SelectedIndex = 0;
            choseSearchArchStatusReport.SelectedIndex = 0;
            inputSearchNumReport.Text = "";
            inputSearchTextReport.Text = "";
            listViewReports.ItemsSource = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.ArchStatus != 1).ToList();
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullRequests();
            SearchNullOrders();
            SearchNullReports();
        }

        private int UpdateRequests()
        {
            var requestList = FreightChelCompanyEntities.GetContext().Requests.ToList();

            if (choseSearchArchStatusRequest.SelectedIndex == 0)
            {
                requestList = requestList.Where(p => p.ArchStatus != 1).ToList();
            }
            else
            {
                requestList = requestList.Where(p => p.ArchStatus == 1).ToList();
            }

            if (choseSearchWorkerRequest.SelectedIndex > 0)
                requestList = requestList.Where(p => p.NumWorker == dispatcherId[choseSearchWorkerRequest.SelectedIndex]).ToList();
            if (choseSearchStatusRequest.SelectedIndex > 0)
                requestList = requestList.Where(p => p.Status == choseSearchStatusRequest.SelectedItem.ToString()).ToList();
            if (choseSearchClientRequest.SelectedIndex > 0)
                requestList = requestList.Where(p => p.Clients.Id == clientId[choseSearchClientRequest.SelectedIndex]).ToList();

            requestList = requestList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumRequest.Text.ToLower())).ToList();
            requestList = requestList.Where(p => p.AddressDel.ToLower().Contains(inputSearchAddressRequest.Text.ToLower())).ToList();

            if (requestList.Count() <= 0)
            {
                SearchNullRequests();
                return 0;
            }
            else
            {
                listViewRequests.ItemsSource = requestList;
                return 1;
            }
        }

        private int UpdateOrders()
        {
            var orderList = FreightChelCompanyEntities.GetContext().Orders.ToList();

            if (choseSearchArchStatusOrder.SelectedIndex == 0)
            {
                orderList = orderList.Where(p => p.ArchStatus != 1).ToList();
            }
            else
            {
                orderList = orderList.Where(p => p.ArchStatus == 1).ToList();
            }

            if (choseSearchWorkerOrder.SelectedIndex > 0)
                orderList = orderList.Where(p => p.NumWorker == managerId[choseSearchWorkerOrder.SelectedIndex]).ToList();
            if (choseSearchStatusOrder.SelectedIndex > 0)
                orderList = orderList.Where(p => p.Status == choseSearchStatusOrder.SelectedItem.ToString()).ToList();
            if (choseSearchClientOrder.SelectedIndex > 0)
                orderList = orderList.Where(p => p.Requests.Clients.Id == clientId[choseSearchClientOrder.SelectedIndex]).ToList();

            orderList = orderList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumOrder.Text.ToLower())).ToList();
            orderList = orderList.Where(p => p.Requests.AddressDel.ToLower().Contains(inputSearchAddressOrder.Text.ToLower())).ToList();

            if (orderList.Count() <= 0)
            {
                SearchNullOrders();
                return 0;
            }
            else
            {
                listViewOrders.ItemsSource = orderList;
                return 1;
            }
        }

        private int UpdateReports()
        {
            var reportList = FreightChelCompanyEntities.GetContext().Reports.ToList();

            if (choseSearchArchStatusReport.SelectedIndex == 0)
            {
                reportList = reportList.Where(p => p.ArchStatus != 1).ToList();
            }
            else
            {
                reportList = reportList.Where(p => p.ArchStatus == 1).ToList();
            }

            if (choseSearchWorkerReport.SelectedIndex > 0)
                reportList = reportList.Where(p => p.NumWorker == bookerId[choseSearchWorkerReport.SelectedIndex]).ToList();

            reportList = reportList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumReport.Text.ToLower())).ToList();
            reportList = reportList.Where(p => p.Text.ToLower().Contains(inputSearchTextReport.Text.ToLower())).ToList();

            if (reportList.Count() <= 0)
            {
                SearchNullReports();
                return 0;
            }
            else
            {
                listViewReports.ItemsSource = reportList;
                return 1;
            }
        }

        private void ButtonSearchRequests(object sender, RoutedEventArgs e)
        {
            if (UpdateRequests() == 0)
                MessageBox.Show("По вашему запросу заявок не найдено!", "Внимание");
        }

        private void ButtonSearchOrders(object sender, RoutedEventArgs e)
        {
            if (UpdateOrders() == 0)
                MessageBox.Show("По вашему запросу заказов не найдено!", "Внимание");
        }

        private void ButtonSearchReports(object sender, RoutedEventArgs e)
        {
            if (UpdateReports() == 0)
                MessageBox.Show("По вашему запросу отчетов не найдено!", "Внимание");
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

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }

        private void ButtonOrderProdsClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminCheckProdsInRequestPage((sender as Button).DataContext as Requests));
        }

        private void ButtonEditReportClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminEditBookerReport((sender as Button).DataContext as Reports));
        }

        private void ButtonGoProdsInRequestClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminCheckProdsInRequestPage((sender as Button).DataContext as Requests));
        }

        private void ButtonEditRequestClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminEditDispatcherRequest((sender as Button).DataContext as Requests));
        }
    }
}