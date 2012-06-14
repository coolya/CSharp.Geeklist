using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharp.Geeklist.Api.Impl
{
    class CardOperations : OAuthAwareOperation, Interfaces.ICardOperations
    {

        const string OWN_CARDS = API_ROOT + "user/cards";
        const string FORING_CARDS = API_ROOT + "users/:{0}/cards";
        const string SINGLE_CARD = API_ROOT + "cards/:{0}";

        public Models.CardsResponse GetUserCards()
        {
            return GetUserCards(1, 10);
        }

        public Models.CardsResponse GetUserCards(int page, int count)
        {
            var req = GetRequest(new Uri(OWN_CARDS), page, count).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.CardsResponse>(req);
        }

        public Models.CardsResponse GetUserCards(string screenName)
        {
            return GetUserCards(screenName, 1, 10);
        }

        public Models.CardsResponse GetUserCards(string screenName, int page, int count)
        {
            var req = GetRequest(new Uri(string.Format(FORING_CARDS, screenName)), page, count).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.CardsResponse>(req);
        }

        public Models.CardResponse GetCard(string cardId)
        {
            var req = GetRequest(new Uri(string.Format(SINGLE_CARD, cardId))).ExecuteRequest().Result;
            return JsonConvert.DeserializeObject<Models.CardResponse>(req);
        }

        public Models.CardResponse CreateCard(string headline)
        {
            throw new NotImplementedException();
        }

        public async  Task<Models.CardsResponse> GetUserCardsAsync()
        {
            return await GetUserCardsAsync(1, 10);
        }

        public async Task<Models.CardsResponse> GetUserCardsAsync(int page, int count)
        {
            var req = await GetRequest(new Uri(OWN_CARDS), page, count).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.CardsResponse>(req);
        }

        public async Task<Models.CardsResponse> GetUserCardsAsync(string screenName)
        {
            return await GetUserCardsAsync(screenName, 1, 10);
        }

        public async Task<Models.CardsResponse> GetUserCardsAsync(string screenName, int page, int count)
        {
            var req = await GetRequest(new Uri(string.Format(FORING_CARDS, screenName)), page, count).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.CardsResponse>(req);
        }

        public async Task<Models.CardResponse> GetCardAsync(string cardId)
        {
            var req = await GetRequest(new Uri(string.Format(SINGLE_CARD, cardId))).ExecuteRequest();
            return await JsonConvert.DeserializeObjectAsync<Models.CardResponse>(req);
        }

        public async Task<Models.CardResponse> CreateCardAsync(string headline)
        {
            throw new NotImplementedException();
        }
    }
}
