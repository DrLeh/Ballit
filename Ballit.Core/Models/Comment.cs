using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{

    public class Comment : Votable, ICommentable
    {
        public string Text { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
