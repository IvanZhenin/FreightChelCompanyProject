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
    /// Страница менеджера, предназначенная для добавления нового заказа или редактирования существующей записи.
    /// </summary>
    public partial class ManagerAddNewOrder : Page
    {
        private Requests CurrentRequest = new Requests();
        private Orders CurrentOrder = new Orders();
        private List<int> clientPos = new List<int>();
        private List<string> clientsList = new List<string>();
        public ManagerAddNewOrder(Requests selectedRequest, Orders selectedOrder)
        {
            InitializeComponent();
            CurrentRequest = selectedRequest;
            var client = FreightChelCompanyEntities.GetContext().Clients.Where(p => p.Id == selectedRequest.NumClient).First();
            List<string> statusList = new List<string>
            {
                "В ожидании"
            };
            inputWorker.Text = LoginSector.UserId.ToString() + ". " + LoginSector.Name;
            inputClient.Text = client.Id + ". " + client.Name;

            if (selectedOrder != null)
            {
                statusList.Add("Выполняется");
                statusList.Add("Выполнен");
                statusList.Add("Отменен");
                choseStatus.ItemsSource = statusList;
            }
            else
            {
                choseStatus.ItemsSource = statusList;
                choseStatus.SelectedIndex = 0;
                choseStatus.IsEnabled = false;
                inputDateEnd.IsEnabled = false;
            }

            if (selectedOrder != null)
            {
                textBlockPageStatus.Text = $"Изменение записи по заявке номер [{selectedRequest.Id}]";
                inputDateEnd.SelectedDate = selectedOrder.DateEnd;
                CurrentOrder = selectedOrder;
                choseStatus.SelectedItem = selectedOrder.Status;
                inputDateStart.SelectedDate = selectedOrder.DateStart;
                inputDateEnd.SelectedDate= selectedOrder.DateEnd;
            }
            else
            {
                textBlockPageStatus.Text = $"Добавление заказа по заявке номер [{selectedRequest.Id}]";
                inputDateStart.SelectedDate = DateTime.Today;
            }
        }

        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            
            if (textBlockPageStatus.Text[0] == 'И')
            {
                if (inputDateEnd.SelectedDate is null && (choseStatus.SelectedItem.ToString() == "Выполнен" || choseStatus.SelectedItem.ToString() == "Отменен"))
                {
                    errors.AppendLine("Необходимо указать дату завершения при выполнении или отмене заказа!");
                }
                else if (inputDateEnd.SelectedDate != null && (choseStatus.SelectedItem.ToString() == "Выполнен" 
                    || choseStatus.SelectedItem.ToString() == "Отменен") && inputDateEnd.SelectedDate.Value < CurrentOrder.DateStart)
                {
                    errors.AppendLine("Дата завершения заказа не может быть раньше даты создания!");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentOrder.NumWorker = LoginSector.UserId;
            CurrentOrder.Status = choseStatus.SelectedItem.ToString();
            CurrentOrder.DateStart = inputDateStart.SelectedDate.Value;

            if (choseStatus.SelectedItem.ToString() == "Выполнен" || choseStatus.SelectedItem.ToString() == "Отменен")
            {
                CurrentOrder.DateEnd = inputDateEnd.SelectedDate;
            }
            else
            {
                CurrentOrder.DateEnd = null;
            }

            if (CurrentOrder.Id <= 0)
            {
                CurrentOrder.Status = "В ожидании";
                CurrentOrder.Id = CurrentRequest.Id;
                CurrentOrder.ArchStatus = 0;
                FreightChelCompanyEntities.GetContext().Orders.Add(CurrentOrder);
            }
           
            return 1;
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            if (CheckErrors() == 0)
                return;

            try
            {
                FreightChelCompanyEntities.GetContext().SaveChanges();
                if (textBlockPageStatus.Text[0] != 'И')
                {
                    MessageBox.Show("Данные успешно добавлены!", "Внимание");
                }
                else
                {
                    MessageBox.Show("Измения успешно сохранены!", "Внимание");
                }
                FrameSector.ManagerFrame.GoBack();
                FrameSector.ManagerAssistFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.ManagerFrame.GoBack();
            FrameSector.ManagerAssistFrame.GoBack();
        }
    }
}