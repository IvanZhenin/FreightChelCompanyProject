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
    /// Страница амдинистратора, предназначенная для добавления новой категории товаров или редактирования существующей записи.
    /// </summary>
    public partial class AdminAddNewCategory : Page
    {
        private Categories CurrentCategory = new Categories();
        public AdminAddNewCategory(Categories selectedCategory)
        {
            InitializeComponent();
            if (selectedCategory != null)
            {
                textBlockPageStatus.Text = $"Изменение данных категории товаров под номером [{selectedCategory.Id}]";
                CurrentCategory = selectedCategory;
                inputCategoryName.Text = CurrentCategory.Name;
            }
            else
            {
                textBlockPageStatus.Text = "Добавление новой категории товаров";
            }
        }

        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(inputCategoryName.Text))
            {
                errors.AppendLine("Необходимо указать название товара!");
            }
            else
            {
                bool checkNameLetter = false;
                foreach (char symbol in inputCategoryName.Text)
                {
                    if (symbol != '-' && symbol != ' ' && !Char.IsLetter(symbol))
                    {
                        checkNameLetter = true;
                        break;
                    }
                }

                if (checkNameLetter == true)
                {
                    errors.AppendLine("Название категории товаров не может содержать какие-либо символы кроме букв, тире и пробела!");
                }
                else
                {
                    bool checkName = false;
                    foreach (var category in FreightChelCompanyEntities.GetContext().Categories)
                    {
                        if (textBlockPageStatus.Text[0] == 'И')
                        {
                            if (category.Name == inputCategoryName.Text && category.Name != CurrentCategory.Name)
                            {
                                checkName = true;
                                break;
                            }
                        }
                        else
                        {
                            if (category.Name == inputCategoryName.Text)
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
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentCategory.Name = inputCategoryName.Text;

            if (CurrentCategory.Id <= 0)
            {
                int targetId = 0;
                List<int> numList = new List<int>();
                foreach (var category in FreightChelCompanyEntities.GetContext().Categories)
                {
                    numList.Add(category.Id);
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
                CurrentCategory.Id = targetId;
                FreightChelCompanyEntities.GetContext().Categories.Add(CurrentCategory);
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

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }

        private void InputCategoryNamePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char symbol in e.Text)
            {
                if (symbol != '-' && symbol != ' ' && !Char.IsLetter(symbol))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}