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

namespace FreightChelCompanyProject.PagesOfBooker
{
    /// <summary>
    /// Вспомогательная страница бухгалтера, содержащая информацию о заказах.
    /// </summary>
    public partial class BookerOrdersListPage : Page
    {
        public BookerOrdersListPage()
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
            choseSearchStatusOrder.ItemsSource = statusList;
            choseSearchStatusOrder.SelectedIndex = 0;
        }

        private void ButtonAddReportClick(object sender, RoutedEventArgs e)
        {
            if (!(FrameSector.BookerFrame.Content is BookerAddNewReport))
            {
                Orders order = (sender as Button).DataContext as Orders;
                if (order.Status != "Выполнен" && order.Status != "Отменен")
                {
                    MessageBox.Show("Данный заказ не завершен!", "Внимание");
                }
                else
                {
                    FrameSector.BookerAssistFrame.Navigate(new BookerTargetOrderInfo(order));
                    FrameSector.BookerFrame.Navigate(new BookerAddNewReport(order, null));
                }
            }
        }
        public int UpdateOrders()
        {
            var checkReports = FreightChelCompanyEntities.GetContext().Reports;
            var checkOrders = FreightChelCompanyEntities.GetContext().Orders.Where(p => !checkReports.Any(c => c.Id == p.Id) && p.ArchStatus != 1).ToList();

            if (choseSearchStatusOrder.SelectedIndex > 0)
                checkOrders = checkOrders.Where(p => p.Status == choseSearchStatusOrder.SelectedItem.ToString()).ToList();

            checkOrders = checkOrders.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumOrder.Text.ToLower())).ToList();

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
            if (UpdateOrders()== 0)
                MessageBox.Show("По вашему запросу заказов не найдено!", "Внимание");
        }

        private void SearchNullOrders()
        {
            var checkReports = FreightChelCompanyEntities.GetContext().Reports;
            choseSearchStatusOrder.SelectedIndex = 0;
            inputSearchNumOrder.Text = "";
            listViewOrders.ItemsSource = FreightChelCompanyEntities.GetContext().Orders.Where(p => !checkReports.Any(c => c.Id == p.Id) && p.ArchStatus != 1).ToList();
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullOrders();
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