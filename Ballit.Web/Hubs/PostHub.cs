using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Ballit.Web.Hubs
{
    public interface IPostHub
    {
        void SubscribeToPost(long id);
        void UnsubscribeToPost(long id);
        void PostVoted(long id, long score);
    }

    public interface IPostClient
    {
        void UpdatePostScore(long id, long score);
    }

    public class PostHub : Hub<IPostClient>, IPostHub
    {
        private string GetPostGroup(long id) => $"Post:{id}";

        public void SubscribeToPost(long id)
        {
            Groups.Add(Context.ConnectionId, GetPostGroup(id));
        }

        public void UnsubscribeToPost(long id)
        {
            Groups.Remove(Context.ConnectionId, GetPostGroup(id));
        }

        public void PostVoted(long id, long score)
        {
            Clients.All.UpdatePostScore(id, score);
        }
    }
}
