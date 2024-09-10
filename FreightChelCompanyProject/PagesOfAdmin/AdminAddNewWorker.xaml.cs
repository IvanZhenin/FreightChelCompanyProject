using FreightChelCompanyProject.AppData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Страница амдинистратора, предназначенная для добавления нового сотрудника(менеджера или бухгалтера) или редактирования существующей записи.
    /// </summary>
    public partial class AdminAddNewWorker : Page
    {
        private Workers CurrentWorker = new Workers();
        public AdminAddNewWorker(Workers selectedWorker)
        {
            InitializeComponent();

            List<string> listRoles = new List<string>() { "Диспетчер", "Менеджер", "Бухгалтер" };
            choseWorkerRole.ItemsSource = listRoles;
            List<string> listGender = new List<string>() { "Мужской", "Женский" };
            choseWorkerGender.ItemsSource = listGender;

            if (selectedWorker != null)
            {
                textBlockPageStatus.Text = $"Изменение данных сотрудника под номером [{selectedWorker.Id}]";
                CurrentWorker = selectedWorker;
                inputWorkerName.Text = CurrentWorker.Name;
                inputLogin.Text = CurrentWorker.Login;
                inputPassword.Text = CurrentWorker.Password;
                choseWorkerRole.SelectedIndex = CurrentWorker.RoleId - 1;
                if (CurrentWorker.Gender == "Муж")
                {
                    choseWorkerGender.SelectedIndex = 0;
                }
                else
                {
                    choseWorkerGender.SelectedIndex = 1;
                }

                if (CurrentWorker.Image != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    using (MemoryStream memoryStream = new MemoryStream(CurrentWorker.Image))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                    }
                    imageControl.Source = bitmapImage;
                }
            }
            else
            {
                textBlockPageStatus.Text = "Добавление нового сотрудника";
            }
        }

        private void ButtonSelectImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files | *.jpg; *.jpeg; *.png; *.bmp | All Files | *.*";

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    BitmapImage bitmapImage = new BitmapImage(new Uri(selectedImagePath));
                    imageControl.Source = bitmapImage;
                }
            }
            catch (System.NotSupportedException)
            {
                MessageBox.Show("Выбран неподходящий тип файла", "Ошибка");
            }
        }

        private void ButtonDeleteImageClick(object sender, RoutedEventArgs e)
        {
            imageControl.Source = null;
        }

        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(inputWorkerName.Text))
            {
                errors.AppendLine("Небходимо заполнить имя сотрудника!");
            }

            if (String.IsNullOrEmpty(inputLogin.Text))
            {
                errors.AppendLine("Небходимо заполнить логин сотрудника!");
            }
            else
            {
                bool checkLogin = false;
                foreach (var worker in FreightChelCompanyEntities.GetContext().Workers)
                {
                    if (textBlockPageStatus.Text[0] == 'И')
                    {
                        if (worker.Login == inputLogin.Text && worker.Login != CurrentWorker.Login)
                        {
                            checkLogin = true;
                            break;
                        }
                    }
                    else
                    {
                        if (worker.Login == inputLogin.Text)
                        {
                            checkLogin = true;
                            break;
                        }
                    }
                }

                if (checkLogin == true)
                {
                    errors.AppendLine("Данный логин уже занят, выберите другой!");
                }
            }

            if (String.IsNullOrEmpty(inputPassword.Text))
            {
                errors.AppendLine("Небходимо заполнить пароль сотрудника!");
            }

            if (choseWorkerGender.SelectedIndex < 0)
            {
                errors.AppendLine("Небходимо выбрать пол сотрудника!");
            }

            if (choseWorkerRole.SelectedIndex < 0)
            {
                errors.AppendLine("Небходимо выбрать роль сотрудника!");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }


            switch (choseWorkerGender.SelectedIndex)
            {
                case 0:
                    CurrentWorker.Gender = "Муж";
                    break;
                case 1:
                    CurrentWorker.Gender = "Жен";
                    break;
            }

            switch (choseWorkerRole.SelectedIndex)
            {
                case 0:
                    CurrentWorker.RoleId = 1;
                    break;
                case 1:
                    CurrentWorker.RoleId = 2;
                    break;
                case 2:
                    CurrentWorker.RoleId = 3;
                    break;
            }

            CurrentWorker.Name = inputWorkerName.Text;
            CurrentWorker.Login = inputLogin.Text;
            CurrentWorker.Password = inputPassword.Text;

            if (imageControl.Source != null)
            {
                byte[] imageData;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imageControl.Source));

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    imageData = ms.ToArray();
                }
                CurrentWorker.Image = imageData;
            }
            else
            {
                CurrentWorker.Image = null;
            }

            if (CurrentWorker.Id <= 0)
            {
                int targetId = 0;
                List<int> numList = new List<int>();
                foreach (var worker in FreightChelCompanyEntities.GetContext().Workers)
                {
                    numList.Add(worker.Id);
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
                CurrentWorker.Id = targetId;
                FreightChelCompanyEntities.GetContext().Workers.Add(CurrentWorker);
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
    }
}