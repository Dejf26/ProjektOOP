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
    /// Interaction logic for Policies.xaml
    /// </summary>
    public partial class Policies : Window
    {
        public Policies()
        {


            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            var wlasc = from d in db.Polisy
                        select new
                        {
                            ID = d.Id_polisy,
                            KodPakietu = d.Kod_pakietu,
                            DataZawarcia = d.Data_zawarcia,
                            IdWlasc = d.Id_wlasciciela,
                            IdPoj = d.Id_pojazdu,
                     
                        };

            foreach (var item in wlasc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.KodPakietu);
                Console.WriteLine(item.DataZawarcia);
                Console.WriteLine(item.IdWlasc);
                Console.WriteLine(item.IdPoj);
       ;

            }


        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try { 
            
            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            Polisy PolObj = new Polisy()
            {
                Kod_pakietu = txtKod.Text,
                Data_zawarcia = DateTime.Parse(txtDataZaw.Text),
                Id_wlasciciela = int.Parse(txtIDW.Text),
                Id_pojazdu = int.Parse(txtIDP.Text)

            };



            db.Polisy.Add(PolObj);
            db.SaveChanges();


            this.PoliciesGrid.ItemsSource = db.Polisy.ToList();
            PoliciesGrid.Columns[5].Visibility = Visibility.Hidden;
            PoliciesGrid.Columns[6].Visibility = Visibility.Hidden;
            PoliciesGrid.Columns[7].Visibility = Visibility.Hidden;

            MessageBox.Show("Dodano polisę");

            }
            catch (Exception)
            {

                MessageBox.Show("Błędne ID pojazdu / własciciela");
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {



            UbezpieczalniaEntities db = new UbezpieczalniaEntities();

            this.PoliciesGrid.ItemsSource = db.Polisy.ToList();

            PoliciesGrid.Columns[5].Visibility = Visibility.Hidden;
            PoliciesGrid.Columns[6].Visibility = Visibility.Hidden;
            PoliciesGrid.Columns[7].Visibility = Visibility.Hidden;

            MessageBox.Show("Odświeżono wyniki");


        }





        private int UpdatePolID = 0;

        private void PoliciesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {







            if (this.PoliciesGrid.SelectedIndex >= 0)
            {
                try
                {
                    if (this.PoliciesGrid.SelectedItems.Count >= 0)
                    {



                        var d = (Polisy)this.PoliciesGrid.SelectedItems[0];
                        this.txtKod2.Text = d.Kod_pakietu;
                        this.txtDataZaw2.Text = d.Data_zawarcia.ToString();
                        this.txtIDW2.Text = d.Id_wlasciciela.ToString();
                        this.txtIDP2.Text = d.Id_pojazdu.ToString();

                        this.UpdatePolID = d.Id_polisy;

                    }
                }
                catch (InvalidCastException) { }
            }


        }




        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

            UbezpieczalniaEntities db = new UbezpieczalniaEntities();


            var r = from d in db.Polisy
                    where d.Id_polisy == this.UpdatePolID
                    select d;

            Polisy obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.Kod_pakietu = this.txtKod2.Text;
                obj.Data_zawarcia = DateTime.Parse(this.txtDataZaw2.Text);
                obj.Id_wlasciciela = int.Parse(this.txtIDW2.Text);
                obj.Id_pojazdu = int.Parse(this.txtIDP2.Text);

            }
            db.SaveChanges();
            this.PoliciesGrid.ItemsSource = db.Polisy.ToList();
            PoliciesGrid.Columns[5].Visibility = Visibility.Hidden;
            PoliciesGrid.Columns[6].Visibility = Visibility.Hidden;
            PoliciesGrid.Columns[7].Visibility = Visibility.Hidden;

            MessageBox.Show("Zmieniono dane");

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


                var r = from d in db.Polisy
                        where d.Id_polisy == this.UpdatePolID
                        select d;

                Polisy obj = r.SingleOrDefault();

                if (obj != null)
                {
                    db.Polisy.Remove(obj);
                    db.SaveChanges();


                }
                this.PoliciesGrid.ItemsSource = db.Polisy.ToList();
                PoliciesGrid.Columns[5].Visibility = Visibility.Hidden;
                PoliciesGrid.Columns[6].Visibility = Visibility.Hidden;
                PoliciesGrid.Columns[7].Visibility = Visibility.Hidden;

                MessageBox.Show("Usunięto");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
