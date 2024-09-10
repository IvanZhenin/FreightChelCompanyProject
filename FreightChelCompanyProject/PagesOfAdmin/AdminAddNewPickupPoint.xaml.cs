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
    /// Страница амдинистратора, предназначенная для добавления нового пункта выдачи или редактирования существующей записи.
    /// </summary>
    public partial class AdminAddNewPickupPoint : Page
    {
        private PickupPoints CurrentPoint = new PickupPoints();
        public AdminAddNewPickupPoint(PickupPoints selectedPoint)
        {
            InitializeComponent();
            if (selectedPoint != null)
            {
                textBlockPageStatus.Text = $"Изменение данных пункта выдачи под номером [{selectedPoint.Id}]";
                CurrentPoint = selectedPoint;
                inputAddressName.Text = CurrentPoint.Address;
            }
            else
            {
                textBlockPageStatus.Text = "Добавление нового пункта выдачи";
            }
        }
        private int CheckErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(inputAddressName.Text))
            {
                errors.AppendLine("Необходимо указать адрес пункта выдачи!");
            }
            else
            {
                bool checkAddress = false;
                foreach (var point in FreightChelCompanyEntities.GetContext().PickupPoints)
                {
                    if (textBlockPageStatus.Text[0] == 'И')
                    {
                        if (point.Address == inputAddressName.Text && point.Address != CurrentPoint.Address)
                        {
                            checkAddress = true;
                            break;
                        }
                    }
                    else
                    {
                        if (point.Address == inputAddressName.Text)
                        {
                            checkAddress = true;
                            break;
                        }
                    }
                }

                if (checkAddress == true)
                {
                    errors.AppendLine("Данный адрес уже занят, выберите другой!");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return 0;
            }

            CurrentPoint.Address = inputAddressName.Text;

            if (CurrentPoint.Id <= 0)
            {
                int targetId = 0;
                List<int> numList = new List<int>();
                foreach (var point in FreightChelCompanyEntities.GetContext().PickupPoints)
                {
                    numList.Add(point.Id);
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
                CurrentPoint.Id = targetId;
                FreightChelCompanyEntities.GetContext().PickupPoints.Add(CurrentPoint);
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
    }
}
