using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{

    public class Comment : Entity<long>, IAuditable, ICommentable
    {
        public string Text { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentVote> Votes { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long CreatedByUserId { get; set; }
        public long? UpdatedByUserId { get; set; }
    }
}
