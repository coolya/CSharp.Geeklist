using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chq.OAuth;
using CSharp.Geeklist.Api.Interfaces;

namespace CSharp.Geeklist.Api.Impl
{
    class GeeklistApi : Interfaces.IGeeklist
    {
        readonly Client client;

        IUserOperations userOps;
        ICardOperations cardOps;
        IMicroOperations microOps;
        IFollowerOperations followerOps;
        IFollowingOperations followingOps;
        IActivityOperations actOps;
        IHighfiveOperations highOps;

        public GeeklistApi(Client client)
        {
            this.client = client;
        }
        public Interfaces.IUserOperations UserOperations
        {
            get { return userOps ?? (userOps = new UserOperations(client)); }
        }

        public Interfaces.ICardOperations CardOperations
        {
            get { return cardOps ?? (cardOps = new CardOperations(client)); }
        }

        public Interfaces.IMicroOperations MicroOperations
        {
            get { return microOps ?? (microOps = new MicroOperations(client)); }
        }

        public Interfaces.IFollowerOperations FollowerOperations
        {
            get { return followerOps ?? (followerOps = new FollowerOperations(client)); }
        }

        public Interfaces.IFollowingOperations FollowingOperations
        {
            get { return followingOps ?? (followingOps = new FollowingOperations(client)); }
        }

        public Interfaces.IActivityOperations ActivityOperations
        {
            get { return actOps ?? (actOps = new ActivityOperation(client)); }
        }

        public Interfaces.IHighfiveOperations HighfiveOperations
        {
            get { return highOps ?? (highOps = new HighFiveOperations(client)); }
        }
    }
}
