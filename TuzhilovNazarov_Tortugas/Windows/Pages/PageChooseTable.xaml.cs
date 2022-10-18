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
    /// Логика взаимодействия для PageChooseTable.xaml
    /// </summary>
    public partial class PageChooseTable : Page
    {
        public PageChooseTable()
        {
            InitializeComponent();

            List<EF.Table> listClient = new List<EF.Table>();

            listClient = ClassHelper.AppData.Context.Table.ToList();
            lvTables.ItemsSource = listClient;
        }

        private void lvTables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvTables.SelectedItem is EF.Table)
            {
                var table = lvTables.SelectedItem as EF.Table;

                var orderInfo = new OrderInfo { Name = table.Name, TotalCost = 0 };
                OrderInfoData.orderInfos.Add(orderInfo);
                              
                PageCategoryProduct page = new PageCategoryProduct();
                NavigationService.Navigate(page);
            }
        }
    }
}
