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



        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            Wlasciciele WlascObj = new Wlasciciele()
            {
                Imie = txtName.Text,
                Nazwisko = txtNazwisko.Text,
                PESEL = txtPESEL.Text,

            };

            MessageBox.Show("Dodano właściciela");

            db.Wlasciciele.Add(WlascObj);
            db.SaveChanges();
            this.GridOfWlasciciele.ItemsSource = db.Wlasciciele.ToList();

        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {


            UbezpieczalniaEntities db = new UbezpieczalniaEntities();

            this.GridOfWlasciciele.ItemsSource = db.Wlasciciele.ToList();
            GridOfWlasciciele.Columns[4].Visibility = Visibility.Hidden;
            GridOfWlasciciele.Columns[5].Visibility = Visibility.Hidden;
            MessageBox.Show("Odświeżono wyniki");

        }


        private int UpdateWlascID = 0;

        private void GridOfWlasciciele_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            if (this.GridOfWlasciciele.SelectedIndex >= 0)
            {
                try
                {
                    if (this.GridOfWlasciciele.SelectedItems.Count >= 0)
                    {



                        var d = (Wlasciciele)this.GridOfWlasciciele.SelectedItems[0];
                        this.txtName2.Text = d.Imie;
                        this.txtNazwisko2.Text = d.Nazwisko;
                        this.txtPESEL2.Text = d.PESEL;

                        this.UpdateWlascID = d.Id;

                    }
                }
                catch (InvalidCastException) { }
            }


        }



        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

            UbezpieczalniaEntities db = new UbezpieczalniaEntities();


            var r = from d in db.Wlasciciele
                    where d.Id == this.UpdateWlascID
                    select d;

            Wlasciciele obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.Imie = this.txtName2.Text;
                obj.Nazwisko = this.txtNazwisko2.Text;
                obj.PESEL = this.txtPESEL2.Text;
                MessageBox.Show("Zmieniono dane");

            }
            db.SaveChanges();
            this.GridOfWlasciciele.ItemsSource = db.Wlasciciele.ToList();

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult msgdel = MessageBox.Show("Czy na pewno chcesz usunąć pozycję?",
                "Usuń pozycję",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
            );
            if (msgdel == MessageBoxResult.Yes)
            {
                UbezpieczalniaEntities db = new UbezpieczalniaEntities();


                var r = from d in db.Wlasciciele
                        where d.Id == this.UpdateWlascID
                        select d;

                Wlasciciele obj = r.SingleOrDefault();

                if (obj != null)
                {
                    db.Wlasciciele.Remove(obj);
                    db.SaveChanges();
                    MessageBox.Show("Usunięto");

                }
                this.GridOfWlasciciele.ItemsSource = db.Wlasciciele.ToList();

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

