using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public abstract class Votable : AuditableEntity<long>, IVotable
    {
        public ICollection<Vote> Votes { get; set; }
    }
}
