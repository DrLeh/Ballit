using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Models;
using Ballit.Core.Posts;

namespace Ballit.Core.Services
{
    public interface IPostService : IVotableService
    {
        IEnumerable<Post> GetPosts();
        Post GetPost(long id);
        Post Submit(Post post);
    }

    public class PostService : VotableService<Post>, IPostService
    {
        public IPostRepository PostRepository { get; }
        public IDataAccess DataAccess { get; }

        public PostService(IPostRepository postRepository, IDataAccess dataAccess)
        {
            PostRepository = postRepository;
            DataAccess = dataAccess;
        }


        public Post GetPost(long id)
        {
            return PostRepository.GetPost(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return PostRepository.GetPosts();
        }

        public Post Submit(Post post)
        {
            var operation = new SubmitPostOperation(post);
            operation.ValidateUrl();
            var trans = DataAccess.CreateTransaction();
            operation.SaveToDb(trans);
            trans.Commit();
            return operation.Post;
        }
    }
}
