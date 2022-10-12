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

        private void lvProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var product = lvProduct.SelectedItem as Product;
            var preorder = new PreOrder { Name = product.Name, Cost = product.Cost, Count = 1, Description = product.Description};
            ClassHelper.PreOrderData.pres.Add(preorder);

            var orderInfo = new OrderInfo { TableID = OrderInfoData.orderInfos.First().TableID, TotalCost = OrderInfoData.orderInfos.First().TotalCost + product.Cost};
            OrderInfoData.orderInfos.RemoveAt(0);
            OrderInfoData.orderInfos.Add(orderInfo);
        }
    }
}
