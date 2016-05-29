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
        public FilmView()
        {
            this.InitializeComponent();
            DataContext = new ViewModels.FilmViewModel();
        }
    }
}
