using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FlashCardApp.Model.Deck;
using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Logic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCardApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyPage : Page
    {
        public StudyPage()
        {
            this.InitializeComponent();
        }

        private int CurrentCardIndex = 0;
        private ManageDeckInProgress deckInProgressManager = new ManageDeckInProgress();

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            hungarianText.Visibility = Visibility.Visible;
            wrongBtn.Visibility = Visibility.Visible;
            rightBtn.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButton.IsEnabled = this.Frame.CanGoBack;

            ManageWholeDeck WholeDeckManager = new ManageWholeDeck();
            WholeDeckManager.Create(e.Parameter.ToString());

            DeckInProgress.Instance().Clear();
            deckInProgressManager.PickCardsToLearn();
            title.Text = e.Parameter.ToString();

            foreignText.Text = DeckInProgress.Instance().ListAll()[CurrentCardIndex].WordToLearn;
            hungarianText.Text = DeckInProgress.Instance().ListAll()[CurrentCardIndex].Meaning + "5/" + DeckInProgress.Instance().ListAll()[CurrentCardIndex].Hits;
        }

        private void wrongBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandling(false);
        }

        private void rightBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandling(true);
        }

        private void ButtonHandling(bool isRight)
        {
            DeckInProgress.Instance().ListAll()[CurrentCardIndex].DealWithAnswer(isRight);

            hungarianText.Visibility = Visibility.Collapsed;
            wrongBtn.Visibility = Visibility.Collapsed;
            rightBtn.Visibility = Visibility.Collapsed;

            if (CurrentCardIndex == DeckInProgress.Instance().ListAll().Count - 1)
            {
                CurrentCardIndex = 0;
                DeckInProgress.Instance().Shuffle();
                deckInProgressManager.CheckDeckInProgress();
            }
            else
            {
                CurrentCardIndex++;
            }

            foreignText.Text = DeckInProgress.Instance().ListAll()[CurrentCardIndex].WordToLearn;
            hungarianText.Text = DeckInProgress.Instance().ListAll()[CurrentCardIndex].Meaning + "5/" + DeckInProgress.Instance().ListAll()[CurrentCardIndex].Hits;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        // Handles system-level BackRequested events and page-level back button Click events
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }
    }
}
