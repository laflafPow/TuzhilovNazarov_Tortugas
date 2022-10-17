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
    public partial class WindowMain : Window
    {
        public WindowMain()
        {
            InitializeComponent();

            frameMain.Source = new Uri("Pages/PageChooseTable.xaml", UriKind.Relative);         
        }



        private void btnChooseTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Source = new Uri("Pages/PageChooseTable.xaml", UriKind.Relative);

            imgChooseTable.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\table.png", UriKind.Relative));
            imgBtnMenu.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\FoodUnselected.png", UriKind.Relative));
            imgBtnOrder.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\OrderUnselected.png", UriKind.Relative));
            imgHeader.Source = new BitmapImage(new Uri("/Images/logo.png", UriKind.Relative));
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Source = new Uri("Pages/PageCategoryProduct.xaml", UriKind.Relative);

            imgBtnMenu.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\FoodSelected.png", UriKind.Relative));
            imgChooseTable.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\TableUnselected.png", UriKind.Relative));
            imgBtnOrder.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\OrderUnselected.png", UriKind.Relative));
            imgHeader.Source = new BitmapImage(new Uri("/Images/HeaderMenu.png", UriKind.Relative));
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Source = new Uri("Pages/PageOrder.xaml", UriKind.Relative);

            imgBtnOrder.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\OrderSelected.png", UriKind.Relative));
            imgBtnMenu.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\FoodUnselected.png", UriKind.Relative));
            imgChooseTable.ImageSource = new BitmapImage(new Uri("C:\\Users\\Никита поел\\source\\repos\\TuzhilovNazarov_Tortugas\\TuzhilovNazarov_Tortugas\\Images\\TableUnselected.png", UriKind.Relative));
            imgHeader.Source = new BitmapImage(new Uri("/Images/HeaderBasket.png", UriKind.Relative));
        }
    }
}
