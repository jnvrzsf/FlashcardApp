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
    public sealed partial class DeckSelectionPage : Page
    {
        private DeckSelectionPageViewModel ViewModel { get; } = new DeckSelectionPageViewModel();
        public DeckSelectionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.NextPage = (string)e.Parameter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string deckName = (string)button.DataContext;
            switch (ViewModel.NextPage)
            {
                case "Study": this.Frame.Navigate(typeof(StudyPage), deckName);
                    break;
                case "Browse": this.Frame.Navigate(typeof(BrowsePage), deckName);
                    break;
            }
        }
    }
}
