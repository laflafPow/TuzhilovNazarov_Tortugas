using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
using TuzhilovNazarov_Tortugas.ClassHelper;
using TuzhilovNazarov_Tortugas.EF;
using TuzhilovNazarov_Tortugas.Windows.Pages;

namespace TuzhilovNazarov_Tortugas.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        public PageProduct(int CategoryProduct)
        {
            InitializeComponent();

            _ = new List<EF.Product>();
            List<EF.Product> listProduct = ClassHelper.AppData.Context.Product.ToList();
            listProduct = listProduct.Where(i => i.CategoryProductID == CategoryProduct).ToList();

            lvProduct.ItemsSource = listProduct;
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            lvProduct.SelectedItem = (sender as Button).DataContext;

            var product = lvProduct.SelectedItem as Product;
            var searchProduct = PreOrderData.pres.FirstOrDefault(p => p.Name == product.Name);

            if (searchProduct != null)
            {
                searchProduct.Count += 1;
                searchProduct.Cost += product.Cost;
                searchProduct.Weight += product.Weight;
                PreOrderData.pres.RemoveAll(p => p.Name == product.Name);
                PreOrderData.pres.Add(searchProduct);
            }
            else
            {
                var preorder = new PreOrder { Name = product.Name, Cost = product.Cost, Count = 1, Description = product.Description, PhotoPath = product.PhotoPath, Weight = product.Weight };
                ClassHelper.PreOrderData.pres.Add(preorder);

                var orderInfo = new OrderInfo { Name = OrderInfoData.orderInfos.First().Name, TotalCost = OrderInfoData.orderInfos.First().TotalCost + product.Cost };
                OrderInfoData.orderInfos.RemoveAt(0);
                OrderInfoData.orderInfos.Add(orderInfo);
            }            
        }
    }
}
