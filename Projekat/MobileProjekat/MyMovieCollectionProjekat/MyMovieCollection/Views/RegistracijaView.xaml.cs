using MyMovieCollectionProjekat.MyMovieCollection.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovieCollectionProjekat.MyMovieCollection.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaView : Page
    {
        public RegistracijaView()
        {
            this.InitializeComponent();
            DataContext = new MyMovieCollection.ViewModels.RegistracijaViewModel();
      
 NavigationCacheMode = NavigationCacheMode.Required;
        }


        //implementirati validaciju
        private void button_RegistrujSe(object sender, RoutedEventArgs e)
        {
            string spol;
            if (spolMuskoReg.IsChecked == true)
                spol = "Musko";
            else
                spol = "Zensko";
            /* Korisnik registrovaniKorisnik = new Korisnik()
             {
                 Ime = imeReg.Text,
                 Prezime = prezimeReg.Text,
                 Mail = mailReg.Text,
                 Spol = spol,
                 Username = usernameReg.Text,
               //  DatumRodjenja = datumReg.DateTime, zab kako se preuzima datum
                 Sifra = passwordReg.Text,
                 DatumRegistracije = DateTime.Now,
                 DalijeAdmin = false                
             };
             */

            //podaci sa korisnicima se salju u fiju u RegistracijaViewModel kako bi se dodali u listuKorisnika?
            //RegistracijaViewModel regVM = new RegistracijaViewModel();
            //regVM.dodajKorisnika(registrovaniKorisnik);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //DataContext = (RegistracijaViewModel)e.Parameter;
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
