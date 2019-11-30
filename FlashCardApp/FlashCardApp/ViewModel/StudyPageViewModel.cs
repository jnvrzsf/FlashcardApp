﻿using FlashCardApp.Model.Deck;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MoreLinq;
using FlashCardApp.Model.Cards;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace FlashCardApp.ViewModel
{
    class StudyPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Megváltozott egy tulajdonságunk
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A kiválasztott pakli
        /// </summary>
        Deck Deck { get; }

        /// <summary>
        /// Az aktuális kártyák, amiket tanít
        /// </summary>
        private List<CardViewModel> SubDeck { get; }

        /// <summary>
        /// Az épp kijelzett kártya, mindig a SubDeck-ről levett első elem
        /// </summary>
        public CardViewModel CurrentCard => SubDeck.First();

        /// <summary>
        /// Fel van-e fedve a jelenlegi kártya - háttérváltozó
        /// </summary>
        private bool _isRevealed;

        /// <summary>
        /// Fel van-e fedve a jelenlegi kártya
        /// </summary>
        public bool IsRevealed
        {
            get => _isRevealed;
            set
            {
                if (_isRevealed != value)
                {
                    _isRevealed = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRevealed)));
                }
            }
        }

        /// <summary>
        /// Helyes volt a megoldás - parancs
        /// </summary>
        public ICommand CorrectCommand { get; }

        /// <summary>
        /// Nem volt helyes a megoldás - parancs
        /// </summary>
        public ICommand IncorrectCommand { get; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="deck">A kiválasztott pakli</param>
        public StudyPageViewModel(Deck deck)
        {
            Deck = deck;

            // SubDeck feltöltése
            SubDeck = deck.Cards
                .Shuffle()
                .Take(5)
                .Select(e => new CardViewModel(e))
                .ToList();

            // Parancsok létrehozása
            CorrectCommand = new RelayCommand(SelectCorrect);
            IncorrectCommand = new RelayCommand(SelectIncorrect);
        }

        /// <summary>
        /// Helyes válasz kiválasztása
        /// </summary>
        private void SelectCorrect()
        {
            CurrentCard.Card.HitCount++;
            if (CurrentCard.Card.HitCount < 3)
            {
                NextCard();
            }
            else
            {
                var replacement = Deck.Cards
                    .Except(SubDeck.Select(e => e.Card))
                    .Shuffle()
                    .FirstOrDefault();
                NextCard(replacement);
            }
            IsRevealed = false;
        }

        /// <summary>
        /// Helytelen válasz kiválasztása
        /// </summary>
        private void SelectIncorrect()
        {
            CurrentCard.Card.HitCount = 0;
            NextCard();
            IsRevealed = false;
        }

        /// <summary>
        /// Kiválasztja a következő kártyát, és vagy
        /// a lista végére helyezi, vagy ha van csere kártya,
        /// akkor a cseréhez tartozó modelt rakja a végére.
        /// </summary>
        /// <param name="replacement">Csere</param>
        public void NextCard(Card replacement = null)
        {
            // Ha van csere, akkor ahhoz tartozó modelt fogjuk majd berakni,
            // amúgy a jelenlegi kártya megy a tömb végére
            var toBeAdded = replacement == null ? CurrentCard : new CardViewModel(replacement);

            // Eltávolítjuk az első kártyát
            SubDeck.RemoveAt(0);

            // Berakjuk a cserét a végére
            SubDeck.Add(toBeAdded);

            // Tájékoztatunk
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentCard)));
        }
    }
}