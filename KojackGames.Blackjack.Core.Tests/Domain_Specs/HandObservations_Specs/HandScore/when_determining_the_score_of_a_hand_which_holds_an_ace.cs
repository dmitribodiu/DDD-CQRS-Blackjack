﻿using System.Collections.Generic;
using KojackGames.Blackjack.Domain.GamePlay.Model.CardDeck;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands;
using Machine.Specifications;
using NUnit.Framework;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.HandScore_specs
{
    [Subject(typeof(HandScorer), "Hand Scorer")]
    public class when_determining_the_score_of_a_hand_which_holds_an_ace
    {
        private Establish context = () =>
        {
            SUT = new HandScorer();
            hand = MockRepository.GenerateStub<IHand>();
            var cards = new List<Card>();
            cards.Add(new Card(Suit.Hearts, CardValue.Ace));
            cards.Add(new Card(Suit.Hearts, CardValue.Seven));
            hand.Stub(x => x.cards).Return(cards);
            hand.Stub(x => x.number_of_visible_aces).Return(1);
        };

        private Because of = () => result = SUT.calculate_score_for(hand);

        private It should_score_the_hand_correctly = () => Assert.That(result, Is.EqualTo(18));

        private static IHand hand;
        private static int result;
        private static HandScorer SUT;
    }
}