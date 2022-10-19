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
using TuzhilovNazarov_Tortugas.ClassHelper;
using TuzhilovNazarov_Tortugas.EF;

namespace TuzhilovNazarov_Tortugas.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    public partial class PageOrder : Page
    {
        public PageOrder()
        {
            InitializeComponent();

            Filter();
        }

        private void btnRemoveToOrder_Click(object sender, RoutedEventArgs e)
        {
            lvOrder.SelectedItem = (sender as Button).DataContext;

            var preOrder = lvOrder.SelectedItem as PreOrder;
            var searchPreOrder = PreOrderData.pres.FirstOrDefault(p => p.Name == preOrder.Name);
            var product = AppData.Context.Product.FirstOrDefault(p => p.Name == preOrder.Name);

            if (searchPreOrder != null && searchPreOrder.Count > 1)
            {
                searchPreOrder.Count -= 1;
                searchPreOrder.Cost -= product.Cost;
                searchPreOrder.Weight -= product.Weight;
                PreOrderData.pres.RemoveAll(p => p.Name == preOrder.Name);
                PreOrderData.pres.Add(searchPreOrder);
                Filter();
            }
            else
            {
                PreOrderData.pres.RemoveAll(p => p.Name == preOrder.Name);
                Filter();
            }
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            lvOrder.SelectedItem = (sender as Button).DataContext;

            var preOrder = lvOrder.SelectedItem as PreOrder;
            var searchPreOrder = PreOrderData.pres.FirstOrDefault(p => p.Name == preOrder.Name);
            var product = AppData.Context.Product.FirstOrDefault(p => p.Name == preOrder.Name);

            if (searchPreOrder != null)
            {
                searchPreOrder.Count += 1;
                searchPreOrder.Cost += product.Cost;
                searchPreOrder.Weight += product.Weight;
                PreOrderData.pres.RemoveAll(p => p.Name == preOrder.Name);
                PreOrderData.pres.Add(searchPreOrder);
                Filter();
            }
        }

        void Filter()
        {
            lvOrder.ItemsSource = PreOrderData.pres;
            tbTotalCost.Text = $"Итоговая цена: {OrderInfoData.orderInfos.First().TotalCost}";
            tbTableNumber.Text = $"Номер столика: {OrderInfoData.orderInfos.First().Name}";
        }
    }
}
