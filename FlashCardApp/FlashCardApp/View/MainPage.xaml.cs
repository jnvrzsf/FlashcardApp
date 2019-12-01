using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlashCardApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(500, 700);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.Frame.Navigate(typeof(DeckSelectionPage), button.Content);
        }
    }
}
