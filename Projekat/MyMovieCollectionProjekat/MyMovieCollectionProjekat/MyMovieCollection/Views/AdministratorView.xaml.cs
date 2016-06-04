using MyMovieCollectionProjekat.MyMovieCollection.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovieCollectionProjekat.MyMovieCollection.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdministratorView : Page
    {
        public AdministratorView()
        {
            this.InitializeComponent();
            DataContext = new MyMovieCollection.ViewModels.AdministratorViewModel();
        }


        private void listaKorisnika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Korisnik kor = new Korisnik();
            kor = (Korisnik)listaKorisnika.SelectedItem;
            imeKorisnika.Text = kor.Ime + " " + kor.Prezime;
            registracijaKorisnik.Text = kor.DatumRegistracije.ToString();
            usernameKorisnik.Text = kor.Username;

            int brojac = 0;

            using (var db = new KolekcijaDbContext())
            {
                foreach(Kolekcija k in db.Kolekcije)
                {
                    if (k.KorisnikId == kor.KorisnikId)
                        brojac++;
                }
            }

            brojKolekcija.Text = "Broj kolekcija: " + brojac.ToString();

        }

       

        private void button_Click(object sender, RoutedEventArgs e)
        {
            imeKorisnika.Text = "";
            usernameKorisnik.Text = "";
            registracijaKorisnik.Text = "";
            brojKolekcija.Text = "";
        }
    }
}
