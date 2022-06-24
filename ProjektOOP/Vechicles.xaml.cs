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
    /// Interaction logic for Vechicles.xaml
    /// </summary>
    public partial class Vechicles : Window
    {
        public Vechicles()
        {


            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            var wlasc = from d in db.Pojazdy
                        select new
                        {
                            ID = d.Id,
                            Marka = d.Marka,
                            Model = d.Model,
                            NrRej = d.Nr_rejestracyjny,
                            NrVIN = d.Nr_VIN,
                            IdWlasc = d.Id_wlasciciela,
                            //Wlasc = d.Wlasciciele
                        };

            foreach (var item in wlasc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Marka);
                Console.WriteLine(item.Model);
                Console.WriteLine(item.NrRej);
                Console.WriteLine(item.NrVIN);
                Console.WriteLine(item.IdWlasc);
                //Console.WriteLine(item.Wlasc);

            }


        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            Pojazdy VehObj = new Pojazdy()
            {
                Marka = txtMarka.Text,
                Model = txtModel.Text,
                Nr_rejestracyjny = txtRej.Text,
                Nr_VIN = txtVIN.Text,
                Id_wlasciciela = int.Parse(txtIDW.Text)


            };

           

            db.Pojazdy.Add(VehObj);
            db.SaveChanges();

       
            this.VechiclesGrid.ItemsSource = db.Pojazdy.ToList();
            VechiclesGrid.Columns[6].Visibility = Visibility.Hidden;
            VechiclesGrid.Columns[7].Visibility = Visibility.Hidden;
            MessageBox.Show("Dodano pojazd");

        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {



            UbezpieczalniaEntities db = new UbezpieczalniaEntities();

            this.VechiclesGrid.ItemsSource = db.Pojazdy.ToList();

            VechiclesGrid.Columns[6].Visibility = Visibility.Hidden;
            VechiclesGrid.Columns[7].Visibility = Visibility.Hidden;
            MessageBox.Show("Odświeżono wyniki");
          

        }





        private int UpdateVehID = 0;

        private void VechiclesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


          
        



            if (this.VechiclesGrid.SelectedIndex >= 0)
            {
                try
                {
                    if (this.VechiclesGrid.SelectedItems.Count >= 0)
                    {



                        var d = (Pojazdy)this.VechiclesGrid.SelectedItems[0];
                        this.txtMarka2.Text = d.Marka;
                        this.txtModel2.Text = d.Model;
                        this.txtRej2.Text = d.Nr_rejestracyjny;
                        this.txtVIN2.Text = d.Nr_VIN;
                        this.txtIDW2.Text = d.Id_wlasciciela.ToString();

                        this.UpdateVehID = d.Id;

                    }
                }
                catch (InvalidCastException) { }
            }



        }


   

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

            UbezpieczalniaEntities db = new UbezpieczalniaEntities();


            var r = from d in db.Pojazdy
                    where d.Id == this.UpdateVehID
                    select d;

            Pojazdy obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.Marka = this.txtMarka2.Text;
                obj.Model = this.txtModel2.Text;
                obj.Nr_rejestracyjny = this.txtRej2.Text;
                obj.Nr_VIN = this.txtVIN2.Text;
                obj.Id_wlasciciela = int.Parse(this.txtIDW2.Text);


            }
            db.SaveChanges();
            this.VechiclesGrid.ItemsSource = db.Pojazdy.ToList();
            VechiclesGrid.Columns[6].Visibility = Visibility.Hidden;
            VechiclesGrid.Columns[7].Visibility = Visibility.Hidden;
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


                var r = from d in db.Pojazdy
                        where d.Id == this.UpdateVehID
                        select d;

                Pojazdy obj = r.SingleOrDefault();

                if (obj != null)
                {
                    db.Pojazdy.Remove(obj);
                    db.SaveChanges();
                   

                }
                this.VechiclesGrid.ItemsSource = db.Pojazdy.ToList();
                VechiclesGrid.Columns[6].Visibility = Visibility.Hidden;
                VechiclesGrid.Columns[7].Visibility = Visibility.Hidden;
                MessageBox.Show("Usunięto");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
