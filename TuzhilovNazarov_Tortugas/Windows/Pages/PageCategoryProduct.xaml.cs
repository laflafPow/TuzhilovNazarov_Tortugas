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

namespace TuzhilovNazarov_Tortugas.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCategoryProduct.xaml
    /// </summary>
    public partial class PageCategoryProduct : Page
    {
        public PageCategoryProduct()
        {
            InitializeComponent();
            _ = new List<EF.CategoryProduct>();

            List<EF.CategoryProduct> listCategoryProduct = ClassHelper.AppData.Context.CategoryProduct.ToList();
            lvCategoryProduct.ItemsSource = listCategoryProduct;
        }

        private void lvCategoryProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvCategoryProduct.SelectedItem is EF.CategoryProduct)
            {
                PageProduct page = new PageProduct();

                // Navigate to the page, using the NavigationService
                NavigationService.Navigate(page);

            }
        }
    }
}
