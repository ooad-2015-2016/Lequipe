using MyMovieCollectionProjekat.MyMovieCollection.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovieCollectionProjekat.MyMovieCollection.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KorisnikView : Page
    {
        public KorisnikView()
        {

            this.InitializeComponent();
           
            DataContext = new MyMovieCollection.ViewModels.KorisnikViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;

        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (KorisnikViewModel)e.Parameter;
        }

        private void textBlock_Copy7_SelectionChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
