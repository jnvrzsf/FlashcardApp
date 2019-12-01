
using FlashCardApp.Model;
using FlashCardApp.View;
using FlashCardApp.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCardApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowsePage : Page
    {
        private BrowsePageViewModel ViewModel { get; set; }
        public BrowsePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = new BrowsePageViewModel((Deck)e.Parameter);
            if (e.NavigationMode == NavigationMode.Back)
            {
                ViewModel.Deck.Save();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.Frame.Navigate(typeof(EditCardPage), (CardViewModel)button.DataContext);
        }
    }
}
