using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public class AuditableEntity<T> : Entity<long>, IAuditable
    {
        public DateTime CreateDate  { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public long CreatedByUserId { get; set; }
        public User CreatedBy { get; set; }

        //[ForeignKey(nameof(UpdatedBy))]
        public long? UpdatedByUserId { get; set; }
        //public User UpdatedBy { get; set; }
    }
}
