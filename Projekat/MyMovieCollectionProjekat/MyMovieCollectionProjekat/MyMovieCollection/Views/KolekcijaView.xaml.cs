using MyMovieCollectionProjekat.MyMovieCollection.Models;
using System.Linq;
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
    public sealed partial class KolekcijaView : Page
    {
       
        private Film OdabraniFilm {get; set;}
        private Kolekcija OdabranaKolekcija { get; set; }


        public KolekcijaView()
        {
            this.InitializeComponent();
            OdabraniFilm = new Film();

            DataContext = new MyMovieCollection.ViewModels.KolekcijaViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;


            textBlock2.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void textBlock3_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBlock2.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock2.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
        }

        private void KolekcijeIS_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void listBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
          
            OdabraniFilm = (Film) listBox1.SelectedItem;

            if (OdabraniFilm != null)
            {
                Film novi = new Film();
                using (var db = new FilmDbContext())
                {
                    novi = db.Filmovi.Where(x => x.FilmId == OdabraniFilm.FilmId).FirstOrDefault();
                }
                nazivLabela.Text = novi.Naziv;

                opisLabela.Text = novi.Opis;

                ocjenaLabela.Text = OdabraniFilm.ProsjecnaOcjena.ToString();
                //godinaLabela.Text = OdabraniFilm.god;

            }
        }

        private  void izbrisi_Click(object sender, RoutedEventArgs e)
        {
            opisLabela.Text = "";
            nazivLabela.Text = "";
        }
    }
}
