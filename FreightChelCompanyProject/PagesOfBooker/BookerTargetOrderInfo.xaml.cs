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
    /// Вспомогательная страница бухгалтера, содержащая информацию о выбранном заказе при добавлении/изменении отчета.
    /// </summary>
    public partial class BookerTargetOrderInfo : Page
    {
        public BookerTargetOrderInfo(Orders selectedOrder)
        {
            InitializeComponent();
            var selectedRequest = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.Id == selectedOrder.Id).First();
            var worker = FreightChelCompanyEntities.GetContext().Workers.Where(p => p.Id == selectedOrder.NumWorker).First();
            var client = FreightChelCompanyEntities.GetContext().Clients.Where(p => p.Id == selectedRequest.NumClient).First();
            currentWorkerText.Text = " Сотрудник: " + worker.Name;
            currentClientText.Text = " Клиент: " + client.Name;
            currentClientPhoneText.Text = " Номер клиента: " + client.PhoneNumber;
            currentClientEmailText.Text = " Почта клиента: " + client.Email;
            currentAddresDelText.Text = " Адрес доставки: " + selectedRequest.AddressDel;
            currentDateEndText.Text = " Дата создания: " + selectedOrder.DateStart.ToShortDateString(); 
            if (selectedOrder.DateEnd != null)
                currentDateEndText.Text +=  " || Дата завершения: " + selectedOrder.DateEnd.Value.ToShortDateString();
            currentWeightText.Text = " Общий вес: " + selectedRequest.TotalWeight.ToString() + " кг";
            dateGridProdsInOrder.ItemsSource = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == selectedOrder.Id).ToList();
        }
    }
}