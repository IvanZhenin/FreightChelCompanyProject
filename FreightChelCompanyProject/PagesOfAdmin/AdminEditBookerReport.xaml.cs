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
    /// Страница амдинистратора, предназначенная для корректирования(редактирования) данных существующего отчета по заказу.
    /// </summary>
    public partial class AdminEditBookerReport : Page
    {
        private Reports CurrentReport = new Reports();
        private List<int> workerPos = new List<int>();
        private List<string> workerList = new List<string>();
        public AdminEditBookerReport(Reports selectedReport)
        {
            InitializeComponent();
            textBlockPageStatus.Text = textBlockPageStatus.Text = $"Изменение отчета по заказу номер [{selectedReport.Id}]";
            CurrentReport = selectedReport;
            foreach (var worker in FreightChelCompanyEntities.GetContext().Workers.Where(p => p.RoleId == 3))
            {
                workerPos.Add(worker.Id);
                workerList.Add(worker.Id + ". " + worker.Name);
            }
            choseWorker.ItemsSource = workerList;
            choseWorker.SelectedIndex = workerPos.IndexOf(selectedReport.NumWorker);

            List<string> archList = new List<string>() { "Нет", "Да" };
            choseArchStatus.ItemsSource = archList;
            if (selectedReport.ArchStatus == 1)
            {
                choseArchStatus.SelectedIndex = 1;
            }
            else
            {
                choseArchStatus.SelectedIndex = 0;
            }

            inputText.Text = CurrentReport.Text;
            inputTotalAmount.Text = Math.Round((decimal)CurrentReport.Amount, 2).ToString();
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            var currentOrder = FreightChelCompanyEntities.GetContext().Orders.Where(p => p.Id == CurrentReport.Id).ToList();
            var currentRequest = FreightChelCompanyEntities.GetContext().Requests.Where(p => p.Id == CurrentReport.Id).ToList();
            if (choseArchStatus.SelectedIndex == 1)
            {
                CurrentReport.ArchStatus = 1;
                if (currentOrder.Count() > 0)
                    currentOrder[0].ArchStatus = 1;
                if (currentRequest.Count() > 0)
                    currentRequest[0].ArchStatus = 1;
            }
            else
            {
                CurrentReport.ArchStatus = 0;
                if (currentOrder.Count() > 0)
                    currentOrder[0].ArchStatus = 0;
                if (currentRequest.Count() > 0)
                    currentRequest[0].ArchStatus = 0;
            }

            try
            {
                FreightChelCompanyEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены!", "Внимание");
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