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
using System.Windows.Shapes;

namespace TuzhilovNazarov_Tortugas.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        public WindowMenu()
        {
            InitializeComponent();

            frameMenu.Source = new Uri("Pages/PageCategoryProduct.xaml", UriKind.Relative);
        }

        public void ChangePage()
        {
            frameMenu.Source = new Uri("Pages/PageProduct.xaml", UriKind.Relative);
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowOrder windowOrder = new WindowOrder();
            windowOrder.ShowDialog();
        }
    }
}
