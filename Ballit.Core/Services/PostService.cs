using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Models;

namespace Ballit.Core.Services
{
    public interface IPostService : IVotableService
    {
        IEnumerable<Post> GetPosts();
        Post GetPost(long id);
    }

    public class PostService : VotableService<Post>, IPostService
    {
        public IPostRepository PostRepository { get; }

        public PostService(IPostRepository postRepository)
        {
            PostRepository = postRepository;
        }


        public Post GetPost(long id)
        {
            return PostRepository.GetPost(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return PostRepository.GetPosts();
        }
    }
}
