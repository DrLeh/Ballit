using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public class Post : Entity<long>, ICommentable
    {
        public string Title { get; set; }
        public string UrlTitle { get; set; }

        //allow both? unlike reddit?
        public string Url { get; set; }
        public string Text { get; set; }

        public string ThumbUrl { get; set; }

        public string Domain { get; set; }

        [ForeignKey(nameof(Subballit))]
        public string Sub { get; set; }
        public Subballit Subballit { get; set; }

        public ICollection<PostVote> Votes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
