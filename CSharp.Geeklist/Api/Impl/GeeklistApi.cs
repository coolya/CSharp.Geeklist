using System;
using System.Threading.Tasks;
using CSharp.Geeklist.Api.Interfaces;

namespace CSharp.Geeklist.Api.Impl
{
    class GeeklistApi : Interfaces.IGeeklist
    {
        private readonly Func<Uri, Task<string>> _getHandler;
        private readonly Func<Uri, object, Task<string>> _getHandlerWithParameters;
        private readonly Func<Uri, Task<string>> _postHandler;
        private readonly Func<Uri, object, Task<string>> _postHandlerWithUrlEncodedBody;
        IUserOperations userOps;
        ICardOperations cardOps;
        IMicroOperations microOps;
        IFollowerOperations followerOps;
        IFollowingOperations followingOps;
        IActivityOperations actOps;
        IHighfiveOperations highOps;

        public GeeklistApi(Func<Uri, Task<string>> getHandler, Func<Uri, object, Task<string>> getHandlerWithParameters,
            Func<Uri, Task<string>> postHandler, Func<Uri, object, Task<string>> postHandlerWithUrlEncodedBody)
        {
            _getHandler = getHandler;
            _getHandlerWithParameters = getHandlerWithParameters;
            _postHandler = postHandler;
            _postHandlerWithUrlEncodedBody = postHandlerWithUrlEncodedBody;
        }

        public Interfaces.IUserOperations UserOperations
        {
            get { return userOps ?? (userOps = new UserOperations(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }

        public Interfaces.ICardOperations CardOperations
        {
            get { return cardOps ?? (cardOps = new CardOperations(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }

        public Interfaces.IMicroOperations MicroOperations
        {
            get { return microOps ?? (microOps = new MicroOperations(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }

        public Interfaces.IFollowerOperations FollowerOperations
        {
            get { return followerOps ?? (followerOps = new FollowerOperations(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }

        public Interfaces.IFollowingOperations FollowingOperations
        {
            get { return followingOps ?? (followingOps = new FollowingOperations(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }

        public Interfaces.IActivityOperations ActivityOperations
        {
            get { return actOps ?? (actOps = new ActivityOperation(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }

        public Interfaces.IHighfiveOperations HighfiveOperations
        {
            get { return highOps ?? (highOps = new HighFiveOperations(_getHandler, _getHandlerWithParameters, _postHandler, _postHandlerWithUrlEncodedBody)); }
        }
    }
}
