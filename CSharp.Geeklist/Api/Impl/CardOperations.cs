using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    class CardOperations : OAuthAwareOperation, Interfaces.ICardOperations
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

        public async  Task<Models.CardsResponse> GetUserCardsAsync()
        {
            return await GetUserCardsAsync(1, 10);
        }

        public async Task<Models.CardsResponse> GetUserCardsAsync(int page, int count)
        {
            return await GetAsync<Models.CardsResponse>(OWN_CARDS, page, count);
        }

        public async Task<Models.CardsResponse> GetUserCardsAsync(string screenName)
        {
            return await GetUserCardsAsync(screenName, 1, 10);
        }

        public async Task<Models.CardsResponse> GetUserCardsAsync(string screenName, int page, int count)
        {
            return await GetAsync<Models.CardsResponse>(string.Format(FORING_CARDS, screenName), page, count);
        }

        public async Task<Models.CardResponse> GetCardAsync(string cardId)
        {
            return await GetAsync<Models.CardResponse>(string.Format(SINGLE_CARD, cardId));
        }

        public async Task<Models.CardResponse> CreateCardAsync(string headline)
        {
            return await PostAsync<Models.CardResponse>(CREATE_CARD, new { headline = headline });
        }
    }
}
