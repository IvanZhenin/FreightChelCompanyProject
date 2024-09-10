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
    /// Страница администратора, предназначенная для просмотра общей статистики заказов
    /// </summary>
    public partial class AdminCheckOrderStatsPage : Page
    {
        private List<int> managersIds = new List<int>() { 0 };
        private List<string> managersNames = new List<string>() { "Любой" };
        private List<int> clientsIds = new List<int>() { 0 };
        private List<string> clientsNames = new List<string>() { "Любой" };
        public AdminCheckOrderStatsPage()
        {
            InitializeComponent();
            List<string> listProds = new List<string>();
            foreach (var prod in FreightChelCompanyEntities.GetContext().Products)
            {
                listProds.Add(prod.Id + ". " + prod.Name);
            }
            listBoxProducts.ItemsSource = listProds;

            foreach (var manager in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 2))
            {
                managersIds.Add(manager.Id);
                managersNames.Add(manager.Id + ". " + manager.Name);
            }
            choseManagerOrder.ItemsSource = managersNames;
            choseManagerOrder.SelectedIndex = 0;

            foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
            {
                clientsIds.Add(client.Id);
                clientsNames.Add(client.Id + ". " + client.Name);
            }
            choseClientOrder.ItemsSource= clientsNames;
            choseClientOrder.SelectedIndex = 0;

            List <string> yearList = new List<string>() { "Любой" };
            for (int i = 2022; i < DateTime.Today.Year+1; i++)
            {
                yearList.Add(i.ToString());
            }
            choseYearOrders.ItemsSource = yearList;
            choseYearOrders.SelectedIndex = 0;

            List<string> monthList = new List<string>() { "Любой", "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", 
                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
            choseMonthOrders.ItemsSource = monthList;
            choseMonthOrders.SelectedIndex = 0;
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SearchNullOrders();
        }

        private void SearchNullOrders()
        {
            var orderList = FreightChelCompanyEntities.GetContext().Orders.ToList();
            choseManagerOrder.SelectedIndex = 0;
            choseClientOrder.SelectedIndex = 0;
            choseYearOrders.SelectedIndex = 0;
            choseMonthOrders.SelectedIndex = 0;
            inputTotalQuanOrders.Text = orderList.Count().ToString();
            inputWaitingOrders.Text = orderList.Where(p => p.Status == "В ожидании").Count().ToString();
            inputProccesingOrders.Text = orderList.Where(p => p.Status == "Выполняется").Count().ToString();
            inputCompleteOrders.Text = orderList.Where(p => p.Status == "Выполнен").Count().ToString();
            inputRefuseOrders.Text = orderList.Where(p => p.Status == "Отменен").Count().ToString();
            listBoxProducts.SelectedItems.Clear();

            decimal potnSum = 0;
            decimal factSum = 0;
            var orderIds = orderList.Select(p => p.Id).ToList();
            var reqList = FreightChelCompanyEntities.GetContext().Requests.Where(p => orderIds.Contains(p.Id)).ToList();
            foreach (var req in reqList)
            {
                if (req.CheckOrder != "Отменен")
                {
                    var reportCheck = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.Id == req.Id).ToList();
                    if (reportCheck.Count() > 0)
                    {
                        factSum += reportCheck[0].Amount;
                    }
                    else
                    {
                        var prodList = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == req.Id).ToList();
                        foreach (var prod in FreightChelCompanyEntities.GetContext().Products)
                        {
                            foreach (var pos in prodList)
                            {
                                if (pos.ProdId == prod.Id)
                                {
                                    potnSum += (prod.Price * pos.Quantity);
                                }
                            }
                        }
                    }
                }
            }
            inputPotencSumOrders.Text = Math.Round(potnSum, 2).ToString();
            inputActualSumOrders.Text = Math.Round(factSum, 2).ToString();
        }

        private void UpdateOrders()
        {
            var orderList = FreightChelCompanyEntities.GetContext().Orders.ToList();

            if (choseManagerOrder.SelectedIndex > 0)
            {
                orderList = orderList.Where(p => p.NumWorker == managersIds[choseManagerOrder.SelectedIndex]).ToList();
            }

            if (choseClientOrder.SelectedIndex > 0)
            {
                orderList = orderList.Where(p => p.Requests.NumClient == clientsIds[choseClientOrder.SelectedIndex]).ToList();
            }

            if (choseYearOrders.SelectedIndex > 0)
            {
                string yearCheck = choseYearOrders.SelectedItem.ToString();
                orderList = orderList.Where(p => p.DateStart.Year == Convert.ToInt32(yearCheck)).ToList();
            }

            if (choseMonthOrders.SelectedIndex > 0)
            {
                orderList = orderList.Where(p => p.DateStart.Month == choseMonthOrders.SelectedIndex).ToList();
            }

            if (orderList.Count() <= 0)
            {
                SearchNullOrders();
                MessageBox.Show("По вашему запросу заказов не найдено!", "Внимание");
                return;
            }

            decimal potnSum = 0;
            decimal factSum = 0;
            var orderIds = orderList.Select(p => p.Id).ToList();
            var reqList = FreightChelCompanyEntities.GetContext().Requests.Where(p => orderIds.Contains(p.Id)).ToList();
            List<int> prodsList = new List<int>();
            if (listBoxProducts.SelectedItems.Count > 0)
            {
                foreach (var item in listBoxProducts.SelectedItems)
                {
                    prodsList.Add(Convert.ToInt32(item.ToString().Split('.')[0]));
                }
            }
            var reqIds = reqList.Select(p => p.Id).ToList();
            var prodsInRequList = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => prodsList.Contains(p.ProdId) && reqIds.Contains(p.RequeId))
                .GroupBy(p => p.RequeId).Where(g => g.Count() == prodsList.Count()).SelectMany(g => g).ToList();
            var posInReqIds = prodsInRequList.Select(p => p.RequeId).ToList();
            if (listBoxProducts.SelectedItems.Count > 0)
                reqList = reqList.Where(p => posInReqIds.Contains(p.Id)).ToList();

            if (reqList.Count() <= 0)
            {
                SearchNullOrders();
                MessageBox.Show("По вашему запросу заказов не найдено!", "Внимание");
                return;
            }
                
            foreach (var req in reqList)
            {
                if (req.CheckOrder != "Отменен")
                {
                    var reportCheck = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.Id == req.Id).ToList();
                    if (reportCheck.Count() > 0)
                    {
                        factSum += reportCheck[0].Amount;
                    }
                    else
                    {
                        var prodList = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == req.Id).ToList();
                        foreach (var prod in FreightChelCompanyEntities.GetContext().Products)
                        {
                            foreach (var pos in prodList)
                            {
                                if (pos.ProdId == prod.Id)
                                {
                                    potnSum += (prod.Price * pos.Quantity);
                                }
                            }
                        }
                    }
                }
            }

            var finalRequeIds = reqList.Select(p => p.Id).ToList();
            orderList = orderList.Where(p => finalRequeIds.Contains(p.Id)).ToList();

            inputTotalQuanOrders.Text = orderList.Count().ToString();
            inputWaitingOrders.Text = orderList.Where(p => p.Status == "В ожидании").Count().ToString();
            inputProccesingOrders.Text = orderList.Where(p => p.Status == "Выполняется").Count().ToString();
            inputCompleteOrders.Text = orderList.Where(p => p.Status == "Выполнен").Count().ToString();
            inputRefuseOrders.Text = orderList.Where(p => p.Status == "Отменен").Count().ToString();
            inputPotencSumOrders.Text = Math.Round(potnSum, 2).ToString();
            inputActualSumOrders.Text = Math.Round(factSum, 2).ToString();
        }
        private void ButtonSearchStats(object sender, RoutedEventArgs e)
        {
            UpdateOrders();
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }

        private void ButtonClearChoseProds(object sender, RoutedEventArgs e)
        {
            listBoxProducts.SelectedValue = 0;
        }
    }
}