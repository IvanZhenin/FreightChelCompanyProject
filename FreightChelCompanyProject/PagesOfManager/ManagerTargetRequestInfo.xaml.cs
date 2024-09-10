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
    /// Вспомогательная страница менеджера, содержащая информацию о выбранной заявке при добавлении/изменении заказа.
    /// </summary>
    public partial class ManagerTargetRequestInfo : Page
    {
        public ManagerTargetRequestInfo(Requests selectedRequest)
        {
            InitializeComponent();
            var worker = FreightChelCompanyEntities.GetContext().Workers.Where(p => p.Id == selectedRequest.NumWorker).First();
            var client = FreightChelCompanyEntities.GetContext().Clients.Where(p => p.Id == selectedRequest.NumClient).First();
            currentWorkerText.Text = " Сотрудник: " + worker.Name;
            currentClientText.Text = " Клиент: " + client.Name;
            currentClientPhoneText.Text = " Номер клиента: " + client.PhoneNumber;
            currentClientEmailText.Text = " Почта клиента: " + client.Email;
            currentAddresDelText.Text = " Адрес доставки: " + selectedRequest.AddressDel;
            currentDateText.Text = " Дата создания: " + selectedRequest.DateStart.ToShortDateString() + " || Дата завершения: ";
            if (selectedRequest.DateEnd != null)
                currentDateText.Text += selectedRequest.DateEnd.Value.ToShortDateString();
            currentWeightText.Text = " Общий вес: " + selectedRequest.TotalWeight.ToString() + " кг";
            dateGridProdsInRequest.ItemsSource = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == selectedRequest.Id).ToList();
        }
    }
}
