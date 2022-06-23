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

namespace ProjektOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNewCustomerWindow(object sender, RoutedEventArgs e) => new Vechicles().Show();

        private void BtnNewBookWindow(object sender, RoutedEventArgs e) => new Ubezp1().Show();


        private void BtnStatusWindow(object sender, RoutedEventArgs e)
        {

        }

    }
}