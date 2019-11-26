﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Cards
{
    public class Card
    {
        public int ID { get; private set; }
        public string WordToLearn { get; private set; }
        public string Meaning { get; private set; }
        public int Hit { get; private set; }
        public bool HitRateIsGoodEnough { get; private set; }

        public Card(int id, string wordToLearn, string meaning)
        {
            ID = id;
            WordToLearn = wordToLearn;
            Meaning = meaning;
        }

        public void DealWithAnswer(bool validity)
        {
            if (validity)
            {
                Hit++;
                CalculateHitRate();
            }
            else
            {
                Hit = 0;
            }
        }

        public void CalculateHitRate()
        {
            if (Hit >= 5)
            {
                HitRateIsGoodEnough = true;
            }
        }
    }
}