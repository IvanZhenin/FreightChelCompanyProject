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

namespace FreightChelCompanyProject.PagesOfDispatcher
{
    /// <summary>
    /// Страница диспетчера, предназначенная для добавления новой заявки или редактирования существующей записи.
    /// </summary>
    public partial class DispatcherAddNewRequest : Page
    {
        private Requests CurrentRequest = new Requests();
        private List<int> clientPos = new List<int>();
        private List<string> clientsList = new List<string>();
        public DispatcherAddNewRequest(Requests selectedRequest)
        {
            InitializeComponent();
            foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
            {
                clientsList.Add(client.Id + ". " + client.Name);
                clientPos.Add(client.Id);
            }
            choseClient.ItemsSource = clientsList;

            List<string> pickupList = new List<string>();
            foreach (var pickup in FreightChelCompanyEntities.GetContext().PickupPoints)
            {
                pickupList.Add(pickup.Address);
            }
            choseAddressPickup.ItemsSource = pickupList;

            List<string> statusList = new List<string>
            {
                "На проверке"
            };
            inputWorker.Text = LoginSector.UserId.ToString() + ". " + LoginSector.Name;

            if (selectedRequest != null)
            {
                statusList.Add("Одобрена");
                statusList.Add("Отказана");
                choseStatus.ItemsSource = statusList;
                choseDateStart.SelectedDate = selectedRequest.DateStart;
                choseDateEnd.SelectedDate = selectedRequest.DateEnd;
            }
            else
            {
                choseStatus.ItemsSource = statusList;
                choseStatus.SelectedIndex = 0;
                choseStatus.IsEnabled = false;
                choseDateEnd.IsEnabled = false;
                choseDateStart.SelectedDate = DateTime.Today;
            }

            if (selectedRequest != null)
            {
                textBlockPageStatus.Text = $"Изменение записи под номером [{selectedRequest.Id}]";
                CurrentRequest = selectedRequest;
                choseClient.SelectedIndex = clientPos.IndexOf(selectedRequest.NumClient);
                foreach (var pick in pickupList)
                {
                    if (pick == selectedRequest.AddressDel)
                    {
                        checkPickup.IsChecked = true;
                        choseAddressPickup.SelectedItem = pick;
                        break;
                    }
                }
                if (checkPickup.IsChecked == false)
                {
                    ChoseWithoutPickup(checkPickup, null);
                    inputAddress.Text = selectedRequest.AddressDel;
                }

                choseStatus.SelectedItem = selectedRequest.Status;
            }
            else
            {
                textBlockPageStatus.Text = "Добавление новой записи";
                choseAddressPickup.Visibility = Visibility.Collapsed;
            }
        }
        private void ChoseWithPickup(object sender, RoutedEventArgs e)
        {
            inputAddress.Visibility = Visibility.Collapsed;
            choseAddressPickup.Visibility = Visibility.Visible;
        }

        private void ChoseWithoutPickup(object sender, RoutedEventArgs e)
        {
            choseAddressPickup.Visibility = Visibility.Collapsed;
            inputAddress.Visibility = Visibility.Visible;
        }

        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (choseClient.SelectedIndex < 0)
                errors.AppendLine("Необходимо указать клиента!");

            if (choseAddressPickup.Visibility == Visibility.Visible)
            {
                if (choseAddressPickup.SelectedIndex < 0)
                    errors.AppendLine("Необходимо указать пункт выдачи!");
            }
            else
            {
                if (String.IsNullOrEmpty(inputAddress.Text))
                    errors.AppendLine("Необходимо указать адрес доставки!");
            }

            if (textBlockPageStatus.Text[0] == 'И')
            {
                var checkProdsInOrder = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == CurrentRequest.Id).ToList();
                if (checkProdsInOrder.Count() <= 0 && choseStatus.SelectedItem.ToString() == "Одобрена")
                {
                    errors.AppendLine("Заявка не может быть одобрена, так как в ней отсутствуют товары!");
                }
                
                if (choseStatus.SelectedItem.ToString() == "Одобрена" && choseDateEnd.SelectedDate == null && checkProdsInOrder.Count() > 0)
                {
                    errors.AppendLine("При одобрении заявки необходимо указать дату завершения!");
                }
                else if (choseStatus.SelectedItem.ToString() == "Отказана" && choseDateEnd.SelectedDate == null)
                {
                    errors.AppendLine("При отказе заявки необходимо указать дату завершения!");
                }
                else if (choseStatus.SelectedItem.ToString() != "На проверке" && choseDateEnd.SelectedDate < choseDateStart.SelectedDate)
                {
                    errors.AppendLine("Дата завершения не может быть раньше даты создания заявки!");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentRequest.NumWorker = LoginSector.UserId;
            CurrentRequest.NumClient = clientPos[choseClient.SelectedIndex];
            CurrentRequest.DateStart = choseDateStart.SelectedDate.Value;

            if (CurrentRequest != null && choseStatus.SelectedItem.ToString() != "На проверке")
            {
                CurrentRequest.DateEnd = choseDateEnd.SelectedDate.Value;
            }
            else
            {
                CurrentRequest.DateEnd = null;
            }

            if (choseAddressPickup.Visibility == Visibility.Visible)
            {
                CurrentRequest.AddressDel = choseAddressPickup.SelectedItem.ToString();
            }
            else
            {
                CurrentRequest.AddressDel = inputAddress.Text;
            }

            if (CurrentRequest.Id <= 0)
            {
                CurrentRequest.Status = "На проверке";
                int targetId = 0;
                List<int> numList = new List<int>();
                foreach (var request in FreightChelCompanyEntities.GetContext().Requests)
                {
                    numList.Add(request.Id);
                }

                for (int i = 1; i < numList.Count(); i++)
                {
                    if (numList[0] > 1)
                    {
                        targetId = 1;
                        break;
                    }
                    else if (numList[i - 1] + 1 != numList[i])
                    {
                        targetId = numList[i - 1] + 1;
                        break;
                    }

                    targetId = numList[i] + 1;
                }

                CurrentRequest.Id = targetId;
                CurrentRequest.ArchStatus = 0;
                FreightChelCompanyEntities.GetContext().Requests.Add(CurrentRequest);
            }
            else
            {
                CurrentRequest.Status = choseStatus.SelectedItem.ToString();
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
                FrameSector.DispatcherFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.DispatcherFrame.GoBack();
        }
    }
}