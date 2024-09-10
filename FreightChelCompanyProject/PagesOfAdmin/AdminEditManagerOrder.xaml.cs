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
    /// Страница амдинистратора, предназначенная для корректирования(редактирования) данных существующего заказа по заявке.
    /// </summary>
    public partial class AdminEditManagerOrder : Page
    {
        private Orders CurrentOrder = new Orders();
        private List<int> workerPos = new List<int>();
        private List<string> workerList = new List<string>();
        public AdminEditManagerOrder(Orders selectedOrder)
        {
            InitializeComponent();
            CurrentOrder = selectedOrder;
            textBlockPageStatus.Text = $"Изменение записи под номером [{selectedOrder.Id}]";
            List<string> statusList = new List<string>()
            {
                "В ожидании",
                "Выполняется",
                "Выполнен",
                "Отказан"
            };
            choseStatus.ItemsSource = statusList;
            choseStatus.SelectedItem = selectedOrder.Status;

            List<string> archList = new List<string>() { "Нет", "Да" };
            choseArchStatus.ItemsSource = archList;
            if (selectedOrder.ArchStatus == 1)
            {
                choseArchStatus.SelectedIndex = 1;
            }
            else
            {
                choseArchStatus.SelectedIndex = 0;
            }

            foreach (var worker in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 2))
            {
                workerPos.Add(worker.Id);
                workerList.Add(worker.Id + ". " + worker.Name);
            }
            choseWorker.ItemsSource = workerList;
            choseWorker.SelectedIndex = workerPos.IndexOf(selectedOrder.NumWorker);

            var requestId = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.Id == selectedOrder.Id).First();
            var clientName = FreightChelCompanyEntities.GetContext().Clients.Where(p => p.Id == requestId.NumClient).First();
            inputClient.Text = clientName.Id.ToString() + ". " + clientName.Name;
            inputDateStart.SelectedDate = selectedOrder.DateStart;
            inputDateEnd.SelectedDate = selectedOrder.DateEnd;

            if (CurrentOrder.Status != "В ожидании")
                choseWorker.IsEnabled = false;
        }

        private void UpdateOrderInfo()
        {
            CurrentOrder.NumWorker = workerPos[choseWorker.SelectedIndex];
            var currentReport = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.Id == CurrentOrder.Id).ToList();
            var currentRequest = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.Id == CurrentOrder.Id).ToList();
            if (choseArchStatus.SelectedIndex == 1)
            {
                CurrentOrder.ArchStatus = 1;
                if (currentReport.Count() > 0)
                    currentReport[0].ArchStatus = 1;
                if (currentRequest.Count() > 0)
                    currentRequest[0].ArchStatus = 1;
            }
            else
            {
                CurrentOrder.ArchStatus = 0;
                if (currentReport.Count() > 0)
                    currentReport[0].ArchStatus = 0;
                if (currentRequest.Count() > 0)
                    currentRequest[0].ArchStatus = 0;
            }
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateOrderInfo();
                FreightChelCompanyEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!", "Внимание");
                FrameSector.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }
    }
}