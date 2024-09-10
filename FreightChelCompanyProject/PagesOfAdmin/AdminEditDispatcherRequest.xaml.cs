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
    /// Страница амдинистратора, предназначенная для корректирования(редактирования) данных существующей заявки.
    /// </summary>
    public partial class AdminEditDispatcherRequest : Page
    {
        private Requests CurrentRequest = new Requests();
        private List<int> workerPos = new List<int>();
        private List<string> workerList = new List<string>();
        public AdminEditDispatcherRequest(Requests selectedRequest)
        {
            InitializeComponent();
            CurrentRequest = selectedRequest;
            textBlockPageStatus.Text = $"Изменение записи под номером [{selectedRequest.Id}]";
            List<string> statusList = new List<string>()
            {
                "На проверке",
                "Одобрена",
                "Отказана"
            };
            choseStatus.ItemsSource = statusList;
            choseStatus.SelectedItem = selectedRequest.Status;

            List<string> archList = new List<string>() { "Нет", "Да" };
            choseArchStatus.ItemsSource = archList;
            if (selectedRequest.ArchStatus == 1)
            {
                choseArchStatus.SelectedIndex = 1;
            }
            else
            {
                choseArchStatus.SelectedIndex = 0;
            }

            foreach (var worker in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 1))
            {
                workerPos.Add(worker.Id);
                workerList.Add(worker.Id + ". " + worker.Name);
            }
            choseWorker.ItemsSource = workerList;
            choseWorker.SelectedIndex = workerPos.IndexOf(selectedRequest.NumWorker);

            var clientName = FreightChelCompanyEntities.GetContext().Clients.Where(p => p.Id == selectedRequest.NumClient).First();
            inputClient.Text = clientName.Id.ToString() + ". " + clientName.Name;
            inputAddress.Text = selectedRequest.AddressDel;

            choseDateStart.SelectedDate = selectedRequest.DateStart;
            choseDateEnd.SelectedDate = selectedRequest.DateEnd;

            if (CurrentRequest.Status != "На проверке")
                choseWorker.IsEnabled = false;
        }

        private void UpdateRequestInfo()
        {
            CurrentRequest.NumWorker = workerPos[choseWorker.SelectedIndex];
            var currentReport = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.Id == CurrentRequest.Id).ToList();
            var currentOrder = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.Id == CurrentRequest.Id).ToList();
           
            if (choseArchStatus.SelectedIndex == 1)
            {
                CurrentRequest.ArchStatus = 1;
                if (currentReport.Count() > 0) 
                    currentReport[0].ArchStatus = 1;
                if (currentOrder.Count() > 0)
                    currentOrder[0].ArchStatus = 1;
            }
            else
            {
                CurrentRequest.ArchStatus = 0;
                if (currentReport.Count() > 0)
                    currentReport[0].ArchStatus = 0;
                if (currentOrder.Count() > 0)
                    currentOrder[0].ArchStatus = 0;
            }
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateRequestInfo();
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