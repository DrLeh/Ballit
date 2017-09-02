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

        public void ValidateUrl()
        {
            bool result = Uri.TryCreate(Post.Url, UriKind.Absolute, out Uri uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
            Post.Url = uriResult.AbsolutePath;
            Post.Domain = uriResult.Host;
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
