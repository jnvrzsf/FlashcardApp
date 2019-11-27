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
            // abc sorrend
            for (int i = 0; i < 30; i++) // foreach lesz
            {
                Button btn = new Button
                {
                    Content = "Deck" + i,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top
                };
                btn.Click += Button_Click;
                stackPanel.Children.Add(btn);
            } 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // databinding majd ide, átadja a button contentjét
            this.Frame.Navigate(typeof(StudyPage)); 
        }
    }
}
