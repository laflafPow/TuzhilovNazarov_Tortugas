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
using TuzhilovNazarov_Tortugas.ClassHelper;

namespace TuzhilovNazarov_Tortugas.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowChooseTable.xaml
    /// </summary>
    public partial class WindowChooseTable : Window
    {
        public WindowChooseTable()
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

                var orderInfo = new OrderInfo { TableID = table.ID, TotalCost = 0 };
                ClassHelper.OrderInfoData.orderInfos.Add(orderInfo);

                WindowMenu windowMenu = new WindowMenu();
                windowMenu.ShowDialog();
            }
        }
    }
}
