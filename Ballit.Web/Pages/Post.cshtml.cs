using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ballit.Core.Models;
using Ballit.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ballit.Web.Pages
{
    public class PostModel : PageModel
    {
        public IPostService PostService { get; }
        public PostModel(IPostService postService)
        {
            PostService = postService;
        }

        public Post Post { get; set; }

        public void OnGet(int id)
        {
            Post = PostService.GetPost(id);
        }
    }
}