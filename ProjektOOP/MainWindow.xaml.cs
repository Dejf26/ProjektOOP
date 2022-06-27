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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ubezp1 window = new Ubezp1();
            Application.Current.MainWindow = window;
            window.InitializeComponent();
            window.Show();
       
        
        
        
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Vechicles window = new Vechicles();
            Application.Current.MainWindow = window;
            window.InitializeComponent();
            window.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Policies window = new Policies();
            Application.Current.MainWindow = window;
            window.InitializeComponent();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Payments window = new Payments();
            Application.Current.MainWindow = window;
            window.InitializeComponent();
            window.Show();
        }
    }

}