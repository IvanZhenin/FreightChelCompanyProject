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
    /// Страница амдинистратора, предназначенная для просмотра списка товаров заказа.
    /// </summary>
    public partial class AdminCheckProdsInRequestPage : Page
    {
        private Requests CurrentRequest = new Requests();
        public AdminCheckProdsInRequestPage(Requests selectedRequest)
        {
            InitializeComponent();
            CurrentRequest = selectedRequest;
            txtBlockStartPage.Text = $"Состав заявки номер [{selectedRequest.Id}]";
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            dateGridProdsInRequest.ItemsSource = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == CurrentRequest.Id).ToList();
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }
    }
}