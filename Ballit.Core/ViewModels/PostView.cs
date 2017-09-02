using System;
using System.Collections.Generic;
using System.Text;

namespace Ballit.Core.ViewModels
{
    public class PostView : EntityView<long>
    {
        public string Title { get; set; }
        public string UrlTitle { get; set; }

        public string Url { get; set; }
        public string Text { get; set; }

        public string ThumbUrl { get; set; }

        public string Subballit { get; set; }

        public int Score { get; set; }
        public int Order { get; set; }

        public int NumberOfComments { get; set; }

        public string Domain { get; set; }
    }
}
