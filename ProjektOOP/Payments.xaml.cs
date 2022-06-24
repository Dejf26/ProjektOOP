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
    /// Interaction logic for Payments.xaml
    /// </summary>
    public partial class Payments : Window
    {
        public Payments()
        {


            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            var wlasc = from d in db.Platnosci
                        select new
                        {
                            ID = d.Id_platnosci,
                            CzyOplacona = d.Czy_oplacona,
                            IdPolisy = d.Id_polisy,


                        };

            foreach (var item in wlasc)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.CzyOplacona);
                Console.WriteLine(item.IdPolisy);

                ;

            }


        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            UbezpieczalniaEntities db = new UbezpieczalniaEntities();
            Platnosci PayObj = new Platnosci()
            {
                Czy_oplacona = txtOplac.Text.ToUpper(),
                Id_polisy = int.Parse(txtIDP.Text)

            };



            db.Platnosci.Add(PayObj);
            db.SaveChanges();


            this.PaymentsGrid.ItemsSource = db.Platnosci.ToList();
            PaymentsGrid.Columns[3].Visibility = Visibility.Hidden;


            MessageBox.Show("Dodano płatność");

        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {



            UbezpieczalniaEntities db = new UbezpieczalniaEntities();

            this.PaymentsGrid.ItemsSource = db.Platnosci.ToList();

            PaymentsGrid.Columns[3].Visibility = Visibility.Hidden;


            MessageBox.Show("Odświeżono wyniki");


        }





        private int UpdatePayID = 0;

        private void PaymentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {







            if (this.PaymentsGrid.SelectedIndex >= 0)
            {
                try
                {
                    if (this.PaymentsGrid.SelectedItems.Count >= 0)
                    {



                        var d = (Platnosci)this.PaymentsGrid.SelectedItems[0];
                        this.txtOplac2.Text = d.Czy_oplacona;
                        this.txtIDP2.Text = d.Id_polisy.ToString();


                        this.UpdatePayID = d.Id_platnosci;

                    }
                }
                catch (InvalidCastException) { }
            }



        }




        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

            UbezpieczalniaEntities db = new UbezpieczalniaEntities();


            var r = from d in db.Platnosci
                    where d.Id_platnosci == this.UpdatePayID
                    select d;

            Platnosci obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.Czy_oplacona = this.txtOplac2.Text.ToUpper();
                obj.Id_polisy = int.Parse(this.txtIDP2.Text);


            }
            db.SaveChanges();
            this.PaymentsGrid.ItemsSource = db.Platnosci.ToList();
            PaymentsGrid.Columns[3].Visibility = Visibility.Hidden;
         

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


                var r = from d in db.Platnosci
                        where d.Id_platnosci == this.UpdatePayID
                        select d;

                Platnosci obj = r.SingleOrDefault();

                if (obj != null)
                {
                    db.Platnosci.Remove(obj);
                    db.SaveChanges();


                }
                this.PaymentsGrid.ItemsSource = db.Platnosci.ToList();
                PaymentsGrid.Columns[3].Visibility = Visibility.Hidden;
              

                MessageBox.Show("Usunięto");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
