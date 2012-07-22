﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    partial class CardOperations : OAuthAwareOperation, Interfaces.ICardOperations
    {

        const string OWN_CARDS = API_ROOT + "user/cards";
        const string FORING_CARDS = API_ROOT + "users/{0}/cards";
        const string SINGLE_CARD = API_ROOT + "cards/{0}";
        const string CREATE_CARD = API_ROOT + "cards";

        public CardOperations(Client client) : base(client) {}

        public Models.CardsResponse GetUserCards()
        {
            return GetUserCards(1, 10);
        }

        public Models.CardsResponse GetUserCards(int page, int count)
        {
            return Get<Models.CardsResponse>(OWN_CARDS, page, count);
        }

        public Models.CardsResponse GetUserCards(string screenName)
        {
            return GetUserCards(screenName, 1, 10);
        }

        public Models.CardsResponse GetUserCards(string screenName, int page, int count)
        {
            return Get<Models.CardsResponse>(string.Format(FORING_CARDS, screenName), page, count);
        }

        public Models.CardResponse GetCard(string cardId)
        {
            return Get<Models.CardResponse>(string.Format(SINGLE_CARD, cardId));
        }

        public Models.CardResponse CreateCard(string headline)
        {
            return Post<Models.CardResponse>(CREATE_CARD, new { headline = headline });
        }

        private Task<Models.CardsResponse> GetUserCardsAsyncInternal(int page, int count)
        {
            return GetAsync<Models.CardsResponse>(OWN_CARDS, page, count);
        }

        private Task<Models.CardsResponse> GetUserCardsAsyncInternal(string screenName, int page, int count)
        {
            return GetAsync<Models.CardsResponse>(string.Format(FORING_CARDS, screenName), page, count);
        }

        private Task<Models.CardResponse> GetCardAsyncInternal(string cardId)
        {
            return GetAsync<Models.CardResponse>(string.Format(SINGLE_CARD, cardId));
        }

        private Task<Models.CardResponse> CreateCardAsyncInternal(string headline)
        {
            return PostAsync<Models.CardResponse>(CREATE_CARD, new { headline = headline });
        }
    }
}