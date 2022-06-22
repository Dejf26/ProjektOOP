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

namespace ProjektOOP
{
    /// <summary>
    /// Interaction logic for Ubezp1.xaml
    /// </summary>
    public partial class Ubezp1 : Window
    {
        public Ubezp1()
        {
            InitializeComponent();

            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            var wlasc = from d in db.Wlasciciele
                        select new
                        {
                            ID = d.Id,
                            Imie = d.Imie,
                            Nazwisko = d.Nazwisko,
                            PESEL = d.PESEL,
                        };

            foreach (var item in wlasc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Imie);
                Console.WriteLine(item.Nazwisko);
                Console.WriteLine(item.PESEL);


            }

            this.GridOfWlasciciele.ItemsSource = wlasc.ToList();


        }
    }
}
