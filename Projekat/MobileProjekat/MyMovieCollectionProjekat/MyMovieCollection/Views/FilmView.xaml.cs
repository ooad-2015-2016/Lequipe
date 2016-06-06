using MyMovieCollectionProjekat.MyMovieCollection.Models;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovieCollection.MyMovieCollection.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilmView : Page
    {
        private Film OdabraniFilm1 { get; set; }
        public FilmView()
        {
            this.InitializeComponent();
            

           DataContext = new ViewModels.FilmViewModel(this);
            OdabraniFilm1 = new Film();
            opisLabela.Text = "";
            nazivLabela.Text = "";


        }

      /*  protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (FilmViewModel)e.Parameter;
        }*/

       

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OdabraniFilm1 = (Film)listView.SelectedItem;

            if (OdabraniFilm1 != null)
            {
                nazivLabela.Text = OdabraniFilm1.Naziv;
                opisLabela.Text = OdabraniFilm1.Opis;
            }
            else
            {
                nazivLabela.Text = "";
                opisLabela.Text = "";
            }
        }

        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            OdabraniFilm1 = (Film)listView.SelectedItem;
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
