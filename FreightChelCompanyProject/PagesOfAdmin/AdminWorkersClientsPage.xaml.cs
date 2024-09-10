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
    /// Страница амдинистратора, предназначенная для управления сотрудниками и клиентами.
    /// </summary>
    public partial class AdminWorkersClientsPage : Page
    {
        public AdminWorkersClientsPage()
        {
            InitializeComponent();
            List<string> roleList = new List<string>()
            {
                "Любая",
                "Диспетчер",
                "Менеджер",
                "Бухгалтер"
            };
            choseSearchWorkerRole.ItemsSource = roleList;
            choseSearchWorkerRole.SelectedIndex = 0;

            List<string> genderList = new List<string>()
            {
                "Любой",
                "Мужской",
                "Женский"
            };
            choseSearchWorkerGender.ItemsSource = genderList;
            choseSearchWorkerGender.SelectedIndex = 0;
        }

        private void SearchNullWorkers()
        {
            choseSearchWorkerRole.SelectedIndex = 0;
            choseSearchWorkerGender.SelectedIndex = 0;
            inputSearchNumWorker.Text = "";
            inputSearchWorkerName.Text = "";
            dateGridWorkers.ItemsSource = FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId != 4).ToList();
        }

        private void SearchNullClients()
        {
            inputSearchNumClient.Text = "";
            inputSearchClientName.Text = "";
            inputSearchClientNumber.Text = "";
            inputSearchClientEmail.Text = "";
            dateGridClients.ItemsSource = FreightChelCompanyEntities.GetContext().Clients.ToList();
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullWorkers();
            SearchNullClients();
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }

        private int UpdateWorkers()
        {
            var workerList = FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId != 3).ToList();
            if (choseSearchWorkerRole.SelectedIndex > 0)
                workerList = workerList.Where(p => p.RoleId == choseSearchWorkerRole.SelectedIndex).ToList();

            if (choseSearchWorkerGender.SelectedIndex > 0)
            {
                switch (choseSearchWorkerGender.SelectedIndex)
                {
                    case 1:
                        workerList = workerList.Where(p => p.Gender.Contains("Муж")).ToList();
                        break;
                    case 2:
                        workerList = workerList.Where(p => p.Gender.Contains("Жен")).ToList();
                        break;
                }
            }

            workerList = workerList.Where(p => p.Id.ToString().Contains(inputSearchNumWorker.Text.ToString())).ToList();
            workerList = workerList.Where(p => p.Name.ToLower().Contains(inputSearchWorkerName.Text.ToLower().ToString())).ToList();

            if (workerList.Count() <= 0)
            {
                SearchNullWorkers();
                return 0;
            }
            else
            {
                dateGridWorkers.ItemsSource = workerList;
                return 1;
            }
        }

        private int UpdateClients()
        {
            var clientList = FreightChelCompanyEntities.GetContext().Clients.ToList();

            clientList = clientList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumClient.Text.ToLower().ToString())).ToList();
            clientList = clientList.Where(p => p.Name.ToLower().Contains(inputSearchClientName.Text.ToLower().ToString())).ToList();
            clientList = clientList.Where(p => p.Telephone.ToLower().Contains(inputSearchClientNumber.Text.ToLower().ToString())).ToList();
            clientList = clientList.Where(p => p.Email.ToLower().Contains(inputSearchClientEmail.Text.ToLower().ToString())).ToList();

            if (clientList.Count() <= 0)
            {
                SearchNullClients();
                return 0;
            }
            else
            {
                dateGridClients.ItemsSource = clientList;
                return 1;
            }
        }

        private void ButtonSearchWorkers(object sender, RoutedEventArgs e)
        {
            if (UpdateWorkers() == 0)
                MessageBox.Show("По вашему запросу сотрудников не найдено!", "Внимание");
        }

        private void ButtonSearchClients(object sender, RoutedEventArgs e)
        {
            if (UpdateClients() == 0)
                MessageBox.Show("По вашему запросу клиентов не найдено!", "Внимание");
        }

        private void InputSearchNumWorkerPreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void InputSearchNamePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char symbol in e.Text)
            {
                if (!Char.IsLetter(symbol) && symbol != ' ')
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void ButtonAddWorkerClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewWorker(null));
        }

        private void ButtonAddClientClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewClient(null));
        }

        private void ButtonEditWorkerClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewWorker((sender as Button).DataContext as Workers));
        }

        private void ButtonEditClientClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewClient((sender as Button).DataContext as Clients));
        }

        private void ButtonDeleteWorkerClick(object sender, RoutedEventArgs e)
        {
            var workerForRemove = (sender as Button).DataContext as Workers;
            var requestsForRemoving = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.NumWorker == workerForRemove.Id).ToList();
            var ordersForRemoving = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.NumWorker == workerForRemove.Id).ToList();
            var reportsForRemoving = FreightChelCompanyEntities.GetContext().Reports.Where(p => p.NumWorker == workerForRemove.Id).ToList();
           
            if (MessageBox.Show($"Вы точно хотите удалить сотрудника под номером [{workerForRemove.Id}]?",
                    "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (requestsForRemoving.Count() > 0 || ordersForRemoving.Count() > 0 || reportsForRemoving.Count() > 0)
                {
                    MessageBox.Show("Данный сотрудник не может быть удален, так как у него имеются рабочие записи!", "Ошибка");
                }
                else
                {
                    try
                    {
                        FreightChelCompanyEntities.GetContext().Workers.Remove(workerForRemove);
                        FreightChelCompanyEntities.GetContext().SaveChanges();
                        MessageBox.Show($"Данные сотрудника {workerForRemove.Name} успешно удалены!", "Внимание");
                        UpdateWorkers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                }
            }
        }

        private void ButtonDeleteClientClick(object sender, RoutedEventArgs e)
        {
            var clientForRemove = (sender as Button).DataContext as Clients;
            var requestsForRemoving = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.NumClient== clientForRemove.Id).ToList();
                      
            if (MessageBox.Show($"Вы точно хотите удалить клиента под номером [{clientForRemove.Id}]?",
                    "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (requestsForRemoving.Count() > 0)
                {
                    MessageBox.Show("Данный клиент не может быть удален, так как по нему имеются рабочие записи!", "Ошибка");
                }
                else
                {
                    try
                    {
                        FreightChelCompanyEntities.GetContext().Clients.Remove(clientForRemove);
                        FreightChelCompanyEntities.GetContext().SaveChanges();
                        MessageBox.Show($"Данные клиента {clientForRemove.Name} успешно удалены!", "Внимание");
                        UpdateClients();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                }
            }
        }
    }
}