using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using FlashCardApp.ViewModel;
using FlashCardApp.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCardApp
{
    public sealed partial class StudyPage : Page
    {
        private StudyPageViewModel ViewModel { get; set; }
        public StudyPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Deck deck = Deck.Load((string)e.Parameter);
            ViewModel = new StudyPageViewModel(deck);
        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel.IsRevealed = true;
        }
    }
}
