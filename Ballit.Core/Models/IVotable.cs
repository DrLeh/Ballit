using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public interface IVote
    {
        VoteType Value { get; set; }
    }
}
