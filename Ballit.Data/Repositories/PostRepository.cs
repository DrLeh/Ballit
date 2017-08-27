using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Models;

namespace Ballit.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        public IDataAccess DataAccess { get; }

        public PostRepository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public Post GetPost(long id)
        {
            return DataAccess.Query<Post>().Single(x => x.Id == id);
        }

        public IQueryable<Post> GetPosts()
        {
            return DataAccess.Query<Post>();
        }

        public IQueryable<Post> GetPostsForUser(long id)
        {
            return DataAccess.Query<Post>()
                .Join(DataAccess.Query<User>().SelectMany(x => x.Subscriptions.Select(y => y.Name))
                    , x => x.Sub, x => x, (post, sub) => post);
        }
    }
}
