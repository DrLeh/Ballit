using System;
using System.Collections.Generic;
using System.Text;

namespace Ballit.Core.Models
{
    public interface ICommentable
    {
        ICollection<Comment> Comments { get; set; }
    }
}
