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
    /// Страница амдинистратора, предназначенная для добавления нового клиента или редактирования существующей записи.
    /// </summary>
    public partial class AdminAddNewClient : Page
    {
        private Clients CurrentClient = new Clients();
        public AdminAddNewClient(Clients selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
            {
                textBlockPageStatus.Text = $"Изменение данных клиента под номером [{selectedClient.Id}]";
                CurrentClient = selectedClient;
                inputClientName.Text = CurrentClient.Name;
                inputTelephone.Text = CurrentClient.Telephone;
                inputEmail.Text = CurrentClient.Email;
            }
            else
            {
                textBlockPageStatus.Text = "Добавление нового клиента";
            }
        }

        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(inputClientName.Text))
            {
                errors.AppendLine("Необходимо заполнить имя пользователя!");
            }

            if (String.IsNullOrEmpty(inputTelephone.Text))
            {
                errors.AppendLine("Необходимо указать номер телефона пользователя!");
            }
            else
            {
                bool checkDigits = false;
                foreach (char symbol in inputTelephone.Text)
                {
                    if (!Char.IsDigit(symbol))
                    {
                        checkDigits = true;
                        break;
                    }
                }

                if (checkDigits == true)
                {
                    errors.AppendLine("Номер телефона не может содержать какие-либо символы кроме цифр!");
                }
                else if (inputTelephone.Text.Length != 11)
                {
                    errors.AppendLine("Номер телефона должен содержать ровно 11 символов!");
                }
                else if (inputTelephone.Text[0] != '7')
                {
                    errors.AppendLine("Первой цифрой телефона должна быть 7!");
                }
                else 
                {
                    bool checkTelephone = false;
                    foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
                    {
                        if (textBlockPageStatus.Text[0] == 'И')
                        {
                            if (client.Telephone == inputTelephone.Text && client.Telephone != CurrentClient.Telephone)
                            {
                                checkTelephone = true;
                                break;
                            }
                        }
                        else
                        {
                            if (client.Telephone == inputTelephone.Text)
                            {
                                checkTelephone = true;
                                break;
                            }
                        }
                    }

                    if (checkTelephone == true)
                    {
                        errors.AppendLine("Данный номер телефона уже занят, выберите другой!");
                    }
                }
            }

            if (String.IsNullOrEmpty(inputEmail.Text))
            {
                errors.AppendLine("Необходимо заполнить электронную почту пользователя!");
            }
            else
            {
                bool checkEmail = false;
                foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
                {
                    if (textBlockPageStatus.Text[0] == 'И')
                    {
                        if (client.Email == inputEmail.Text && client.Email != CurrentClient.Email)
                        {
                            checkEmail = true;
                            break;
                        }
                    }
                    else
                    {
                        if (client.Email == inputEmail.Text)
                        {
                            checkEmail = true;
                            break;
                        }
                    }
                }

                if (checkEmail == true)
                {
                    errors.AppendLine("Данная почта уже занята, выберите другую!");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentClient.Name = inputClientName.Text;
            CurrentClient.Telephone = inputTelephone.Text;
            CurrentClient.Email = inputEmail.Text;

            if (CurrentClient.Id <= 0)
            {
                int targetId = 0;
                List<int> numList = new List<int>();
                foreach (var client in FreightChelCompanyEntities.GetContext().Clients)
                {
                    numList.Add(client.Id);
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
                CurrentClient.Id = targetId;
                FreightChelCompanyEntities.GetContext().Clients.Add(CurrentClient);
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

        private void InputNamePreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void InputTelephonePreviewTextInput(object sender, TextCompositionEventArgs e)
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