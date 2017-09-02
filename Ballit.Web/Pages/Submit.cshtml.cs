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
    public class SubmitModel : PageModel
    {
        public IPostService PostService { get; }
        public SubmitModel(IPostService postService)
        {
            PostService = postService;
        }

        [BindProperty]
        public Post Post { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var post = PostService.Submit(Post);
            return RedirectToPage($"/Post", new { id = post.Id });
        }
    }
}