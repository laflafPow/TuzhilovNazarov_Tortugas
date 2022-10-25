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
using TuzhilovNazarov_Tortugas.Pages;

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
            cbPaymentMethod.ItemsSource = ClassHelper.AppData.Context.PayType.ToList();
            cbPaymentMethod.DisplayMemberPath = "PayType1";
            cbPaymentMethod.SelectedIndex = 0;

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
                var orderInfo = new OrderInfo { Name = OrderInfoData.orderInfos.First().Name, TotalCost = OrderInfoData.orderInfos.First().TotalCost - product.Cost };
                OrderInfoData.orderInfos.RemoveAt(0);
                OrderInfoData.orderInfos.Add(orderInfo);
            }
            else
            {
                PreOrderData.pres.RemoveAll(p => p.Name == preOrder.Name);
                var orderInfo = new OrderInfo { Name = OrderInfoData.orderInfos.First().Name, TotalCost = OrderInfoData.orderInfos.First().TotalCost - product.Cost };
                OrderInfoData.orderInfos.RemoveAt(0);
                OrderInfoData.orderInfos.Add(orderInfo);
            }
            Filter();
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
                var orderInfo = new OrderInfo { Name = OrderInfoData.orderInfos.First().Name, TotalCost = OrderInfoData.orderInfos.First().TotalCost + product.Cost };
                OrderInfoData.orderInfos.RemoveAt(0);
                OrderInfoData.orderInfos.Add(orderInfo);
            }
            Filter();
        }

        void Filter()
        {
            lvOrder.ItemsSource = null;
            lvOrder.ItemsSource = PreOrderData.pres;
            var orderInfo = OrderInfoData.orderInfos.Count();

            if (orderInfo != 0)
            {
                tbTotalCost.Text = $"Итоговая цена: {OrderInfoData.orderInfos.First().TotalCost}";
                tbTableNumber.Text = $"Номер столика: {OrderInfoData.orderInfos.First().Name}";
            }        
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            EF.Order order = new Order();

            var orderInfo = OrderInfoData.orderInfos.Count();
            var presInfo = PreOrderData.pres.Count();

            if (orderInfo != 0 && OrderInfoData.orderInfos.First().TotalCost != 0)
            {
                string tablename = OrderInfoData.orderInfos.First().Name;
                var table = AppData.Context.Table.FirstOrDefault(p => p.Name == tablename);
                order.TableID = table.ID;
                order.TimeOrder = DateTime.Now;
                order.TotalCost = OrderInfoData.orderInfos[0].TotalCost;
                order.PayTypeID = (cbPaymentMethod.SelectedItem as EF.PayType).ID;
                AppData.Context.Order.Add(order);
            }
            else
            {
                MessageBox.Show("Заказ не добавлен. Выберите столик и закажите еды!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (presInfo != 0)
            {
                foreach (var item in PreOrderData.pres)
                {
                    EF.ProductOrder productOrder = new ProductOrder();
                    var product = AppData.Context.Product.FirstOrDefault(p => p.Name == item.Name);
                    productOrder.ProductID = product.ID;
                    productOrder.OrderID = order.ID;
                    AppData.Context.ProductOrder.Add(productOrder);
                }
            }
            else
            {
                MessageBox.Show("Заказ не добавлен. Выберите столик и закажите еды!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          
            ClassHelper.AppData.Context.SaveChanges();

            MessageBox.Show("Заказ добавлен! Ожидайте", "Удача", MessageBoxButton.OK, MessageBoxImage.Information);

            OrderInfoData.orderInfos.Clear();
            PreOrderData.pres.Clear();

            PageChooseTable page = new PageChooseTable();
            NavigationService.Navigate(page);
        }
    }
}
