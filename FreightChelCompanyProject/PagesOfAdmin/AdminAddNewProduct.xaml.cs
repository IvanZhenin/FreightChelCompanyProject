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
    /// Страница амдинистратора, предназначенная для добавления нового товара или редактирования существующей записи.
    /// </summary>
    public partial class AdminAddNewProduct : Page
    {
        private Products CurrentProduct = new Products();
        private List<int> categoryPos = new List<int>();
        private List<string> categoryList = new List<string>();
        public AdminAddNewProduct(Products selectedProduct)
        {
            InitializeComponent();
            foreach (var category in FreightChelCompanyEntities.GetContext().Categories)
            {
                categoryPos.Add(category.Id);
                categoryList.Add(category.Id + ". " + category.Name);
            }
            choseProdCategory.ItemsSource = categoryList;

            if (selectedProduct != null)
            {
                textBlockPageStatus.Text = $"Изменение данных товара под номером [{selectedProduct.Id}]";
                CurrentProduct = selectedProduct;
                inputProductName.Text = CurrentProduct.Name;
                inputProdEquip.Text = CurrentProduct.Equipment;
                inputProdWeight.Text = Math.Round((decimal)CurrentProduct.Weight, 3).ToString();
                inputProdPrice.Text = Math.Round((decimal)CurrentProduct.Price, 2).ToString();
                choseProdCategory.SelectedIndex = categoryPos.IndexOf(selectedProduct.CategoryId);
            }
            else
            {
                textBlockPageStatus.Text = "Добавление нового товара";
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }

        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(inputProductName.Text))
            {
                errors.AppendLine("Необходимо указать название товара!");
            }
            else
            {
                bool checkName = false;
                foreach (var prod in FreightChelCompanyEntities.GetContext().Products)
                {
                    if (textBlockPageStatus.Text[0] == 'И')
                    {
                        if (prod.Name == inputProductName.Text && prod.Name != CurrentProduct.Name)
                        {
                            checkName = true;
                            break;
                        }
                    }
                    else
                    {
                        if (prod.Name == inputProductName.Text)
                        {
                            checkName = true;
                            break;
                        }
                    }
                }

                if (checkName == true)
                {
                    errors.AppendLine("Данное название уже занято, выберите другое!");
                }
            }

            if (choseProdCategory.SelectedIndex < 0)
            {
                errors.AppendLine("Необходимо выбрать категорию товара!");
            }

            if (String.IsNullOrEmpty(inputProdEquip.Text))
            {
                errors.AppendLine("Необходимо указать комплектацию товара!");
            }
            else if (inputProdEquip.Text.Length < 15)
            {
                errors.AppendLine("Комплектация товара должна содержать минимум 15 символов!");
            }

            if (String.IsNullOrEmpty(inputProdWeight.Text))
            {
                errors.AppendLine("Необходимо указать вес товара!");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(inputProdWeight.Text) < 0.005 || Convert.ToDouble(inputProdWeight.Text) > 500)
                    {
                        errors.AppendLine("Вес товара не может быть меньше пяти грамм и не может превышать 500 килограмм!");
                    }
                }
                catch (FormatException)
                {
                    errors.AppendLine("Неверный формат веса товара, обнаружены лишние символы! Формат: '000,000'");
                }
            }

            if (String.IsNullOrEmpty(inputProdPrice.Text))
            {
                errors.AppendLine("Необходимо указать цену товара!");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(inputProdPrice.Text) < 20 || Convert.ToDouble(inputProdPrice.Text) > 200000)
                    {
                        errors.AppendLine("Цена товара не может быть меньше 20 рублей и не может превышать 200000 рублей!");
                    }
                }
                catch (FormatException)
                {
                    errors.AppendLine("Неверный формат цены товара, обнаружены лишние символы! Формат: '0000,000'");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentProduct.CategoryId = categoryPos[choseProdCategory.SelectedIndex];
            CurrentProduct.Name = inputProductName.Text;
            CurrentProduct.Equipment = inputProdEquip.Text;
            CurrentProduct.Weight = Convert.ToDecimal(inputProdWeight.Text);
            CurrentProduct.Price = Convert.ToDecimal(inputProdPrice.Text);

            if (CurrentProduct.Id <= 0)
            {
                int targetId = 0;
                List<int> numList = new List<int>();
                foreach (var prod in FreightChelCompanyEntities.GetContext().Products)
                {
                    numList.Add(prod.Id);
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
                CurrentProduct.Id = targetId;
                FreightChelCompanyEntities.GetContext().Products.Add(CurrentProduct);
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
                FrameSector.AdminFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void InputProdNumPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char symbol in e.Text)
            {
                if (!Char.IsDigit(symbol) && symbol != ',')
                {
                    e.Handled = true;
                    return;
                }
            }
        }
    }
}