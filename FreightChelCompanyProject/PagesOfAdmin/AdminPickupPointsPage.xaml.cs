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
    /// Страница амдинистратора, предназначенная для управления пунктами выдачи.
    /// </summary>
    public partial class AdminPickupPointsPage : Page
    {
        public AdminPickupPointsPage()
        {
            InitializeComponent();
        }

        private void ButtonAddPointClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewPickupPoint(null));
        }

        private void ButtonEditPointClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewPickupPoint((sender as Button).DataContext as PickupPoints));
        }

        private void ButtonDeletePointClick(object sender, RoutedEventArgs e)
        {
            var pointForRemove = (sender as Button).DataContext as PickupPoints;
            var requestsForRemove = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.AddressDel == pointForRemove.Address).ToList();
            
            if (MessageBox.Show($"Вы точно хотите удалить пункт выдачи под номером [{pointForRemove.Id}]?",
                    "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (requestsForRemove.Count() > 0)
                {
                    MessageBox.Show("Данный пункт выдачи не может быть удален, так как по нему созданы заявки!", "Ошибка");
                }
                else
                {
                    try
                    {
                        FreightChelCompanyEntities.GetContext().PickupPoints.Remove(pointForRemove);
                        FreightChelCompanyEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные были успешно удалены!", "Внимание");
                        UpdatePoints();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                }
            }
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }

        private void ButtonSearchPoints(object sender, RoutedEventArgs e)
        {
            if (UpdatePoints() == 0)
                MessageBox.Show("По вашему запросу пунктов выдачи не найдено!", "Внимание");
        }

        private int UpdatePoints()
        {
            var pointList = FreightChelCompanyEntities.GetContext().PickupPoints.ToList();

            pointList = pointList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumPoint.Text.ToLower())).ToList();
            pointList = pointList.Where(p => p.Address.ToLower().Contains(inputSearchPointName.Text.ToLower())).ToList();

            if (pointList.Count() <= 0)
            {
                SearchNullPoints();
                return 0;
            }
            else
            {
                dateGridPickupPoints.ItemsSource = pointList;
                return 1;
            }
        }

        private void SearchNullPoints()
        {
            inputSearchNumPoint.Text = "";
            inputSearchPointName.Text = "";
            dateGridPickupPoints.ItemsSource = FreightChelCompanyEntities.GetContext().PickupPoints.ToList();
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullPoints();
        }

        private void InputSearchNumPreviewTextInput(object sender, TextCompositionEventArgs e)
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