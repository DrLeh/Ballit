using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public interface IVotable
    {
        ICollection<Vote> Votes { get; set; }
        //todo: use c# 8 to add a default implementation of intvalue method to sum votes
    }
}
