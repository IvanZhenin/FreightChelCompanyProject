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
    /// Страница диспетчера, предназначенная для добавления нового товара в список заявки или редактирования существующей записи.
    /// </summary>
    public partial class DispatcherAddNewProductInRequest : Page
    {
        private Requests CurrentRequest = new Requests();
        private ProdsInRequests CurrentPos = new ProdsInRequests();
        public DispatcherAddNewProductInRequest(Requests selectedRequest, ProdsInRequests selectedPosition)
        {
            InitializeComponent();
            CurrentRequest = selectedRequest;
            inputNumRequest.Text = (selectedRequest.Id).ToString();
            var prodList = FreightChelCompanyEntities.GetContext().Products.ToList();
            var prodInRequestList = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == selectedRequest.Id).Select(p => p.ProdId);
            prodList = prodList.Where(p => !prodInRequestList.Contains(p.Id)).ToList();

            List<string> prodNames = new List<string>();
            foreach (var prod in prodList)
            {
                prodNames.Add(prod.Name);
            }
            choseProduct.ItemsSource = prodNames;

            if (selectedPosition != null)
            {
                choseProduct.Visibility = Visibility.Collapsed;
                CurrentPos = selectedPosition;
                textBlockPageStatus.Text = $"Изменение позиции в заявке номер [{selectedRequest.Id}]";
                var actualPos = FreightChelCompanyEntities.GetContext().Products.Where(p => p.Id == selectedPosition.ProdId).First();
                inputProduct.Text = actualPos.Name;
                inputQuantity.Text = selectedPosition.Quantity.ToString();
            }
            else
            {
                inputProduct.Visibility = Visibility.Collapsed;
                textBlockPageStatus.Text = $"Добавление позиции в заявке номер [{selectedRequest.Id}]";
            }
        }
        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (choseProduct.Visibility == Visibility.Visible)
            {
                if (choseProduct.SelectedIndex < 0)
                    errors.AppendLine("Необходимо выбрать товар!");
            }

            if (String.IsNullOrEmpty(inputQuantity.Text))
            {
                errors.AppendLine("Необходимо указать количество товара!");
            }
            else
            {
                bool checkErrorsInQuan = false;
                foreach (char symb in inputQuantity.Text)
                {
                    if (!Char.IsDigit(symb))
                    {
                        checkErrorsInQuan = true;
                        break;
                    }
                }

                if (checkErrorsInQuan == true)
                {
                    errors.AppendLine("Количество товара не может содержать какие-либо символы помимо цифр!");
                }
                else if (Convert.ToInt32(inputQuantity.Text) > 100 || Convert.ToInt32(inputQuantity.Text) < 1)
                {
                    errors.AppendLine("Количество товара не может быть меньше 1 и не должно превышать 100 единиц!");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentPos.RequeId = Convert.ToInt32(inputNumRequest.Text);
            if (choseProduct.Visibility == Visibility.Visible)
            {
                var actualChose = FreightChelCompanyEntities.GetContext().Products.Where(p => p.Name == choseProduct.SelectedItem.ToString()).First();
                CurrentPos.ProdId = actualChose.Id;
            }
            CurrentPos.Quantity = Convert.ToInt32(inputQuantity.Text);

            if (textBlockPageStatus.Text[0] != 'И')
                FreightChelCompanyEntities.GetContext().ProdsInRequests.Add(CurrentPos);

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

        private void InputQuantityPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var symbol in e.Text)
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