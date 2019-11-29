using FlashCardApp.Model.Deck;
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
    public sealed partial class DeckSelectionPage : Page
    {
        public DeckSelectionPage()
        {
            this.InitializeComponent();
            DeckTitles = ViewModel.ViewModel.GetExistingDecks();
            // feltölt lista
            // abc sorrendbe rendezés majd!
            foreach (string title in DeckTitles)
            {
                Button btn = new Button
                {
                    Content = title,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top
                };
                btn.Click += Button_Click;
                stackPanel.Children.Add(btn);
            }
        }

        private List<string> DeckTitles;
        private string NextPageName;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (NextPageName)
            {
                case "Study": this.Frame.Navigate(typeof(StudyPage), button.Content);
                    break;
                case "Browse": this.Frame.Navigate(typeof(BrowsePage), button.Content);
                    break;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //BackButton.IsEnabled = this.Frame.CanGoBack;
            NextPageName = e.Parameter.ToString();
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
