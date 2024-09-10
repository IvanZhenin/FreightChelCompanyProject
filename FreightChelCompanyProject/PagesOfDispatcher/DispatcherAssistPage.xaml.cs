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
using FreightChelCompanyProject.AppData;

namespace FreightChelCompanyProject.PagesOfDispatcher
{
    /// <summary>
    /// Вспомогательная страница диспетчера, содержащая информацию о клиентах и товарах.
    /// </summary>
    public partial class DispatcherAssistPage : Page
    {
        public DispatcherAssistPage()
        {
            InitializeComponent();
            List<string> categoriesList = new List<string>();
            categoriesList.Add("Любая");
            foreach (var pos in FreightChelCompanyEntities.GetContext().Categories)
            {
                categoriesList.Add(pos.Name);
            }
            choseSearchCategorieProduct.ItemsSource = categoriesList;
            choseSearchCategorieProduct.SelectedIndex = 0;
        }

        private int UpdateInfoClients()
        {
            var clientsList = FreightChelCompanyEntities.GetContext().Clients.ToList();
            clientsList = clientsList.Where(p => p.Name.ToLower().Contains(inputSearchNameClient.Text.ToLower())).ToList();
            clientsList = clientsList.Where(p => p.Telephone.ToLower().Contains(inputSearchPhoneClient.Text.ToLower())).ToList();

            if (clientsList.Count() <= 0)
            {
                SearchNullClients();
                return 0;
            }
            else
            {
                dateGridClients.ItemsSource = clientsList.OrderBy(p => p.Id);
                return 1;
            }
        }
        private int UpdateInfoProducts()
        {
            var prodsList = FreightChelCompanyEntities.GetContext().Products.ToList();
            if (choseSearchCategorieProduct.SelectedIndex > 0)
                prodsList = prodsList.Where(p => p.Categories.Name == choseSearchCategorieProduct.SelectedItem.ToString()).ToList();

            prodsList = prodsList.Where(p => p.Name.ToLower().Contains(inputSearchNameProduct.Text.ToLower())).ToList();

            if (prodsList.Count() <= 0)
            {
                SearchNullProducts();
                return 0;
            }
            else
            {
                dateGridProds.ItemsSource = prodsList.OrderBy(p => p.Id);
                return 1;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки поиска клиентов.
        /// </summary>
        private void ButtonSearchClient(object sender, RoutedEventArgs e)
        {
            if(UpdateInfoClients() == 0)
                MessageBox.Show("По вашему запросу клиентов не найдено!", "Внимание");
        }

        /// <summary>
        /// Обработчик нажатия кнопки поиска товаров.
        /// </summary>
        private void ButtonSearchProduct(object sender, RoutedEventArgs e)
        {
            if(UpdateInfoProducts() == 0)
                MessageBox.Show("По вашему запросу товаров не найдено!", "Внимание");
        }

        private void SearchNullClients()
        {
            inputSearchNameClient.Text = "";
            inputSearchPhoneClient.Text = "";
            dateGridClients.ItemsSource = FreightChelCompanyEntities.GetContext().Clients.ToList();
        }

        private void SearchNullProducts()
        {
            inputSearchNameProduct.Text = "";
            choseSearchCategorieProduct.SelectedIndex = 0;
            dateGridProds.ItemsSource = FreightChelCompanyEntities.GetContext().Products.ToList();
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullClients();
            SearchNullProducts();
        }

        private void InputSearchPhoneClientPreviewTextInput(object sender, TextCompositionEventArgs e)
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