using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ballit.Core.Mappers;
using Ballit.Core.Models;
using Ballit.Core.Services;
using Ballit.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ballit.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IPostService PostService { get; }
        public IndexModel(IPostService postService)
        {
            PostService = postService;
        }

        public List<PostView> Posts { get; private set; }

        public void OnGet()
        {
            var mapper = new PostMapper();
            Posts = PostService.GetPosts()
                .ToList()
                .Select(mapper.ToViewModel)
                .ToList();
        }
    }
}
