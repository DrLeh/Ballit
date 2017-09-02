using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ballit.Core.Data;
using Ballit.Core.Models;

namespace Ballit.Core.Posts
{
    public class SubmitPostOperation
    {
        public Post Post { get; }

        public SubmitPostOperation(Post post)
        {
            Post = post;
        }

        private string FixUrl(string url)
        {
            if(!url.StartsWith("http://") || !url.StartsWith("http://"))
                return $"http://{url}";
            return url;
        }

        public void ValidateUrl()
        {
            var url = Post.Url;
            url = FixUrl(url);
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
            Post.Url = uriResult.AbsolutePath;
            Post.Domain = uriResult.Host;
            //if no go on http, try https
        }

        public void PopulateMetadata()
        {
            //make web request, get info
            //var req = WebRequest.Create(Post.Url);
            //var res = await req.GetResponseAsync();


        }

        public void SaveToDb(IDataTransaction dataTransaction)
        {
            dataTransaction.AddOrUpdate(Post);
        }

    }
}
