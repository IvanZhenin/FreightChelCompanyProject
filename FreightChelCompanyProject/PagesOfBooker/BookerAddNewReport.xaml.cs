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

namespace FreightChelCompanyProject.PagesOfBooker
{
    /// <summary>
    /// Страница бухгалтера, предназначенная для добавления нового отчета или редактирования существующей записи.
    /// </summary>
    public partial class BookerAddNewReport : Page
    {
        private Orders CurrentOrder = new Orders();
        private Reports CurrentReport = new Reports();
        private decimal startSum = 0;
        private decimal endSum = 0;
        public BookerAddNewReport(Orders selectedOrder, Reports selectedReport)
        {
            InitializeComponent();
            CurrentOrder = selectedOrder;
            inputWorker.Text = LoginSector.UserId.ToString() + ". " + LoginSector.Name;
            List<string> markupList = new List<string>()
            {
                "Не указана",
                "5%",
                "10%",
                "15%",
                "20%",
                "25%",
                "30%",
                "35%",
                "40%",
                "45%",
                "50%"
            };
            choseMarkup.ItemsSource = markupList;
            choseMarkup.SelectedIndex = 0;

            List<string> typeMarkList = new List<string>() { "Наценка", "Скидка" };
            chosePriceMark.ItemsSource = typeMarkList;

            foreach (var prod in FreightChelCompanyEntities.GetContext().Products)
            {
                foreach (var pos in FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.RequeId == selectedOrder.Id))
                {
                    if (pos.ProdId == prod.Id)
                    {
                        startSum += pos.Quantity * prod.Price;
                    }
                }
            }

            if (CurrentOrder.Status == "Выполнен")
            {
                inputAmount.Text = Math.Round((decimal)startSum, 2).ToString();
            }
            else
            {
                inputAmount.Text = "0";
                inputTotalAmount.Text = "0";   
                choseMarkup.IsEnabled = false;
                chosePriceMark.IsEnabled = false;
            }

            if (selectedReport != null)
            {
                textBlockPageStatus.Text = $"Изменение отчета по заказу номер [{selectedOrder.Id}]";
                inputText.Text = selectedReport.Text;
                if (CurrentOrder.Status != "Отменен")
                {
                    inputTotalAmount.Text = Math.Round((decimal)selectedReport.Amount).ToString();
                }
                CurrentReport = selectedReport;
                choseMarkup.SelectedIndex = selectedReport.MarkLevel;

                if (selectedReport.MarkPosition == "Скидка")
                {
                    chosePriceMark.SelectedIndex = 1;
                    textPriceStatus.Text = "Стоимость со скидкой";
                }
                else
                {
                    chosePriceMark.SelectedIndex = 0;
                    textPriceStatus.Text = "Стоимость с наценкой";
                }
            }
            else
            {
                textBlockPageStatus.Text = $"Добавление отчета по заказу номер [{selectedOrder.Id}]";
                chosePriceMark.SelectedIndex = 0;
            }
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(inputText.Text))
                errors.AppendLine("Необходимо заполнить описание!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка");
                return;
            }

            CurrentReport.NumWorker = LoginSector.UserId;
            CurrentReport.Text = inputText.Text;

            if (chosePriceMark.SelectedIndex == 1)
            {
                CurrentReport.MarkPosition = "Скидка";
            }
            else
            {
                CurrentReport.MarkPosition = "Наценка";
            }

            if (CurrentOrder.Status == "Выполнен")
            {
                CurrentReport.Amount = Convert.ToDecimal(inputTotalAmount.Text);
            }
            else
            {
                CurrentReport.Amount = 0;
                CurrentReport.MarkLevel = 0;
            }

            if (CurrentReport.Id <= 0)
            {
                CurrentReport.Id = CurrentOrder.Id;
                CurrentReport.ArchStatus = 0;
                FreightChelCompanyEntities.GetContext().Reports.Add(CurrentReport);
            }

            try
            {
                FreightChelCompanyEntities.GetContext().SaveChanges();
                if (textBlockPageStatus.Text[0] != 'И')
                {
                    MessageBox.Show("Данные успешно добавлены!", "Внимание");
                    FrameSector.BookerAssistFrame.Content = new BookerOrdersListPage();
                }
                else
                {
                    MessageBox.Show("Измения успешно сохранены!", "Внимание");
                }
                FrameSector.BookerAssistFrame.GoBack();
                FrameSector.BookerFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.BookerAssistFrame.GoBack();
            FrameSector.BookerFrame.GoBack();
        }

        private void UpdateMarkup()
        {
            if (CurrentOrder.Status == "Отменен")
            {
                inputTotalAmount.Text = "0";
            }
            else
            {
                if(chosePriceMark.SelectedIndex == 0)
                {
                    textPriceStatus.Text = "Стоимость с наценкой";
                }
                else
                {
                    textPriceStatus.Text = "Стоимость со скидкой";
                }

                if (choseMarkup.SelectedIndex == 0)
                {
                    endSum = Math.Round((decimal)startSum, 2);
                    inputTotalAmount.Text = endSum.ToString();
                }
                else if (choseMarkup.SelectedIndex > 0)
                {
                    string markupString = choseMarkup.SelectedItem.ToString();
                    markupString = markupString.TrimEnd('%');

                    if (chosePriceMark.SelectedIndex == 0)
                    {
                        endSum = startSum + (startSum * Convert.ToDecimal(markupString) / 100);
                    }
                    else if (chosePriceMark.SelectedIndex == 1)
                    {
                        endSum = startSum - (startSum * Convert.ToDecimal(markupString) / 100);
                    }

                    endSum = Math.Round((decimal)endSum, 2);
                    inputTotalAmount.Text = endSum.ToString();
                }

                CurrentReport.MarkLevel = choseMarkup.SelectedIndex;
            }
        }

        private void ChosePriceMarkSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMarkup();
        }

        private void ChoseMarkupSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMarkup();
        }
    }
}