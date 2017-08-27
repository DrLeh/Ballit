using System;
using System.Collections.Generic;
using System.Text;

namespace Ballit.Core.Models
{
    public interface IAuditable
    {
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }

        long CreatedByUserId { get; set; }
        long? UpdatedByUserId { get; set; }
    }
}
