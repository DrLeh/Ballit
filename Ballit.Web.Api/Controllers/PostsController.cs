using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ballit.Core.Models;
using Ballit.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ballit.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        public IPostService PostService { get; }

        public PostsController(IPostService postService)
        {
            PostService = postService;
        }



        // GET api/values
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return PostService.GetPosts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return PostService.GetPost(id);
        }

        // POST api/values
        [HttpPost]
        public void Vote(long id, VoteType type)
        {
            var currentUserId = 1;//todo
            PostService.Vote(new PostVote(id, type, currentUserId));
            //make request to signalr
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
