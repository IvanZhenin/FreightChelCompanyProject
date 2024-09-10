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
    /// Страница амдинистратора, предназначенная для управления товарами и категориями товаров.
    /// </summary>
    public partial class AdminProductsCategoriesPage : Page
    {
        public AdminProductsCategoriesPage()
        {
            InitializeComponent();
            List<string> categoriesList = new List<string>() { "Любая" };
            foreach (var category in FreightChelCompanyEntities.GetContext().Categories)
            {
                categoriesList.Add(category.Name);
            }
            choseSearchProductCategory.ItemsSource = categoriesList;
            choseSearchProductCategory.SelectedIndex = 0;
        }

        private void SearchNullProducts()
        {
            choseSearchProductCategory.SelectedIndex = 0;
            inputSearchNumProduct.Text = "";
            inputSearchProductName.Text = "";
            dateGridProducts.ItemsSource = FreightChelCompanyEntities.GetContext().Products.ToList();
        }

        private void SearchNullCategories()
        {
            inputSearchNumCategory.Text = "";
            inputSearchCategoryName.Text = "";
            dateGridCategories.ItemsSource = FreightChelCompanyEntities.GetContext().Categories.ToList();
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FreightChelCompanyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            SearchNullProducts();
            SearchNullCategories();
        }

        private void InputSearchNumPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char symbol in e.Text)
            {
                if (!char.IsDigit(symbol))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void ButtonAddProductClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewProduct(null));
        }

        private void ButtonEditProductClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewProduct((sender as Button).DataContext as Products));
        }

        private void ButtonDeleteProductClick(object sender, RoutedEventArgs e)
        {
            var prodForRemove = (sender as Button).DataContext as Products;
            var prodsInOrderForRemove = FreightChelCompanyEntities.GetContext().ProdsInRequests.Where(p => p.ProdId == prodForRemove.Id).ToList();
            
            if (MessageBox.Show($"Вы точно хотите удалить товар под номером [{prodForRemove.Id}]?",
                    "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (prodsInOrderForRemove.Count() > 0)
                {
                    MessageBox.Show("Данный товар не может быть удален, так как он находится в составе заявок!", "Ошибка");
                }
                else
                {
                    try
                    {
                        FreightChelCompanyEntities.GetContext().Products.Remove(prodForRemove);
                        FreightChelCompanyEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные были успешно удалены!", "Внимание");
                        UpdateProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                }
            }
        }

        private void ButtonAddCategoryClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewCategory(null));
        }

        private void ButtonEditCategoryClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.Navigate(new AdminAddNewCategory((sender as Button).DataContext as Categories));
        }

        private void ButtonDeleteCategoryClick(object sender, RoutedEventArgs e)
        {
            var categoryForRemove = (sender as Button).DataContext as Categories;
            var prodsForRemove = FreightChelCompanyEntities.GetContext().Products.Where(p => p.CategoryId == categoryForRemove.Id).ToList();
            
            if (MessageBox.Show($"Вы точно хотите удалить категорию товаров под номером [{categoryForRemove.Id}]?",
                    "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (prodsForRemove.Count() > 0)
                {
                    MessageBox.Show("Данная категория не может быть удалена, так как имеются товары, связанные с ней!", "Ошибка");
                }
                else
                {
                    try
                    {
                        FreightChelCompanyEntities.GetContext().Categories.Remove(categoryForRemove);
                        FreightChelCompanyEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные были успешно удалены!", "Внимание");
                        UpdateCategories();
                        UpdateProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                }
            }
        }

        private int UpdateProducts()
        {
            var prodList = FreightChelCompanyEntities.GetContext().Products.ToList();

            if (choseSearchProductCategory.SelectedIndex > 0)
                prodList = prodList.Where(p => p.CategoryId == choseSearchProductCategory.SelectedIndex).ToList();

            prodList = prodList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumProduct.Text.ToLower())).ToList();
            prodList = prodList.Where(p => p.Name.ToLower().Contains(inputSearchProductName.Text.ToLower())).ToList();

            if (prodList.Count() <= 0)
            {
                SearchNullProducts();
                return 0;
            }
            else
            {
                dateGridProducts.ItemsSource = prodList;
                return 1;
            }
        }

        private int UpdateCategories()
        {
            var categoriesList = FreightChelCompanyEntities.GetContext().Categories.ToList();

            categoriesList = categoriesList.Where(p => p.Id.ToString().ToLower().Contains(inputSearchNumCategory.Text.ToLower())).ToList();
            categoriesList = categoriesList.Where(p => p.Name.ToLower().Contains(inputSearchCategoryName.Text.ToLower())).ToList();

            if (categoriesList.Count() <= 0)
            {
                SearchNullCategories();
                return 0;
            }
            else
            {
                dateGridCategories.ItemsSource = categoriesList;
                return 1;
            }
        }

        private void ButtonSearchProducts(object sender, RoutedEventArgs e)
        {
            if (UpdateProducts() == 0)
                MessageBox.Show("По вашему запросу товаров не найдено!");
        }

        private void ButtonSearchCategories(object sender, RoutedEventArgs e)
        {
            if (UpdateCategories() == 0)
                MessageBox.Show("По вашему запросу категорий товаров не найдено!");
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            FrameSector.AdminFrame.GoBack();
        }
    }
}