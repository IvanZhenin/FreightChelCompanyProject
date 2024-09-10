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
    /// Страница диспетчера, предназначенная для работы со списком товаров заявки.
    /// </summary>
    public partial class DispatcherProductsInRequestPage : Page
    {
        private Requests CurrentRequest = new Requests();
        public DispatcherProductsInRequestPage(Requests selectedRequest)
        {
            InitializeComponent();
            CurrentRequest = selectedRequest;
            txtBlockStartPage.Text = $"Состав заявки номер [{selectedRequest.Id}]";
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dateGridProdsInRequest.ItemsSource = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == CurrentRequest.Id).ToList();
        }

        private void ButtonAddNewProdInRequestClick(object sender, RoutedEventArgs e)
        {
            if (CurrentRequest.Status == "Одобрена")
            {
                MessageBox.Show("Вы не можете добавить позицию, так как данная заявка одобрена!", "Внимание");
            }
            else if (CurrentRequest.Status == "Отказана")
            {
                MessageBox.Show("Вы не можете добавить позицию, так как данная заявка отказана!", "Внимание");
            }
            else
            {
                FrameSector.DispatcherFrame.Navigate(new DispatcherAddNewProductInRequest(CurrentRequest, null));
            }
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.DispatcherFrame.GoBack();
        }

        private void ButtonEditProdsInRequestClick(object sender, RoutedEventArgs e)
        {
            if (CurrentRequest.Status == "Одобрена")
            {
                MessageBox.Show("Вы не можете внести изменения, так как данная заявка одобрена!", "Внимание");
            }
            else if (CurrentRequest.Status == "Отказана")
            {
                MessageBox.Show("Вы не можете внести изменения, так как данная заявка отказана!", "Внимание");
            }
            else
            {
                FrameSector.DispatcherFrame.Navigate(new DispatcherAddNewProductInRequest(CurrentRequest, (sender as Button).DataContext as ProdsInRequests));
            }
        }

        private void ButtonDeleteProdsInRequestClick(object sender, RoutedEventArgs e)
        {
            var posForRemoving = (sender as Button).DataContext as ProdsInRequests;
            var posProduct = FreightChelCompanyEntities.GetContext().Products.Where(p => p.Id == posForRemoving.ProdId).First();

            if (CurrentRequest.Status == "Одобрена")
            {
                MessageBox.Show("Вы не можете удалить запись, так как данная заявка одобрена!", "Внимание");
            }
            else if (CurrentRequest.Status == "Отказана")
            {
                MessageBox.Show("Вы не можете удалить запись, так как данная заявка отказана!", "Внимание");
            }
            else
            {
                if (MessageBox.Show($"Вы точно хотите удалить позицию товара {posProduct.Name}?", "Внимание", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FreightChelCompanyEntities.GetContext().ProdsInRequests.Remove(posForRemoving);
                        FreightChelCompanyEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные успешно удалены!", "Внимание");
                        dateGridProdsInRequest.ItemsSource = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == CurrentRequest.Id).ToList();
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