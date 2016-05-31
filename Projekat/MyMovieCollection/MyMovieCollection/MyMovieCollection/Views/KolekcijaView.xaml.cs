using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovieCollection.MyMovieCollection.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KolekcijaView : Page
    {
        public KolekcijaView()
        {
            this.InitializeComponent();
            DataContext = new MyMovieCollection.ViewModels.KolekcijaViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;


            textBlock2.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Collapsed;
            button3.Visibility = Visibility.Collapsed;
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
    }
}
