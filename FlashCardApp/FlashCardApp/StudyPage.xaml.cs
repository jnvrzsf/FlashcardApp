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
using FlashCardApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCardApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            //Deck deck = Deck.Load((string)e.Parameter);
            //ViewModel = new StudyPageViewModel(deck);
        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //ViewModel.IsRevealed = true;
        }
    }
}
