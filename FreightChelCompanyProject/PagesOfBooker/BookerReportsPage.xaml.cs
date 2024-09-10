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
    /// Страница бухгалтера, предназначенная для работы с отчетами.
    /// </summary>
    public partial class BookerReportsPage : Page
    {
        public BookerReportsPage()
        {
            InitializeComponent();
        }

        private void ButtonEditReportClick(object sender, RoutedEventArgs e)
        {
            var currentReport = (sender as Button).DataContext as Reports;
            var currentOrder = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.Id == currentReport.Id).First();

            FrameSector.BookerAssistFrame.Navigate(new BookerTargetOrderInfo(currentOrder));
            FrameSector.BookerFrame.Navigate(new BookerAddNewReport(currentOrder, currentReport));
        }

        private int UpdateReports()
        {
            var reportList = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.NumWorker == LoginSector.UserId && p.ArchStatus != 1).ToList();

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
        private void ButtonSearchReports(object sender, RoutedEventArgs e)
        {
            if (UpdateReports() == 0)
                MessageBox.Show("По вашему запросу отчетов не найдено!", "Внимание");
        }

        private void SearchNullReports()
        {
            inputSearchNumReport.Text = "";
            inputSearchTextReport.Text = "";
            listViewReports.ItemsSource = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.NumWorker == LoginSector.UserId && p.ArchStatus != 1).ToList();
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullReports();
        }
        private void InputSearchNumReportPreviewTextInput(object sender, TextCompositionEventArgs e)
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