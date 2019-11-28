using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using FlashCardApp.Model.Logic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCardApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowsePage : Page
    {
        public BrowsePage()
        {
            this.InitializeComponent();

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackButton.IsEnabled = this.Frame.CanGoBack;

            ManageWholeDeck WholeDeckManager = new ManageWholeDeck();
            WholeDeckManager.Create(e.Parameter.ToString());

            Title.Text = e.Parameter.ToString();

            List<Card> CardList = WholeDeck.Instance().ListAll();

            for (int i = 0; i < CardList.Count; i++)
            {
                CardListGrid.RowDefinitions.Add(new RowDefinition());
            }

            foreach (var card in CardList)
            {
                CardListGrid.RowDefinitions.Add(new RowDefinition());

                TextBlock foreignWord = new TextBlock { Text = card.WordToLearn };
                TextBlock hungarianWord = new TextBlock { Text = card.Meaning };
                CardListGrid.Children.Add(foreignWord);
                CardListGrid.Children.Add(hungarianWord);
                Grid.SetColumn(foreignWord, 0);
                Grid.SetColumn(hungarianWord, 1);
                Grid.SetRow(foreignWord, CardList.IndexOf(card));
                Grid.SetRow(hungarianWord, CardList.IndexOf(card));
            }
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
