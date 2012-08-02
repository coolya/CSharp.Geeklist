using System;
using Windows.Foundation;

namespace CSharp.Geeklist.Api.Impl
{
    partial class CardOperations
    {

        public IAsyncOperation<Models.CardsResponse> GetUserCardsAsync()
        {
            return GetUserCardsAsyncInternal(1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.CardsResponse> GetUserCardsAsync(int page, int count)
        {
            return GetUserCardsAsyncInternal(page, count).AsAsyncOperation();
        }

        public IAsyncOperation<Models.CardsResponse> GetUserCardsAsync(string screenName)
        {
            return GetUserCardsAsyncInternal(screenName, 1, 10).AsAsyncOperation();
        }

        public IAsyncOperation<Models.CardsResponse> GetUserCardsAsync(string screenName, int page, int count)
        {
            return GetUserCardsAsyncInternal(screenName, page, count).AsAsyncOperation();
        }

        public IAsyncOperation<Models.CardResponse> GetCardAsync(string cardId)
        {
            return GetCardAsyncInternal(cardId).AsAsyncOperation();
        }

        public IAsyncOperation<Models.CardResponse> CreateCardAsync(string headline)
        {
            return CreateCardAsyncInternal(headline).AsAsyncOperation();
        }
    }
}
