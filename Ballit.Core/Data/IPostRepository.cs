using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Extensions;
using Ballit.Core.Models;

namespace Ballit.Core.Data
{
    public interface IPostRepository
    {
        IQueryable<Post> GetPosts();
        IQueryable<Post> GetPostsForUser(long id);
        Post GetPost(long id);
    }

    public class TestPostRepospository : IPostRepository
    {
        public Post GetPost(long id)
        {
            return GetPosts().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Post> GetPosts()
        {
            return new[]
            {
                new Post
                {
                    Id = 1,
                    Title = "Great image hosting site",
                    Url = "http://imgur.com",
                    ThumbUrl = "https://b.thumbs.redditmedia.com/6Ay3U40qYssGkyeHoGc0i-mzpqCm3j1pRCB7jMt1uGg.jpg",
                    Sub = "self",

                },
                new Post
                {
                    Id = 2,
                    Title = "Inspirational site",
                    Url = "http://reddit.com",
                    ThumbUrl = "https://b.thumbs.redditmedia.com/OxLVkScdjD7z8XWIWtqcWzMD0ZeV-n8CmOcSiZcqQBA.jpg",
                    Sub = "self",
                },
            }.AsQueryable();
        }

        public IQueryable<Post> GetPostsForUser(long id)
        {
            var subsForUser = Users
                .Single(x => x.Id == id)
                .Subscriptions
                .OrEmptyIfNull()
                .Select(x => x.Name)
                .ToList();

            //special logic if empty
            return GetPosts().Where(x => subsForUser.Contains(x.Sub));
        }

        private List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                Username="dleh",
                Subscriptions = new List<Subballit>
                {
                    new Subballit{ Name = "self"}
                }
            }
        };
    }
}
