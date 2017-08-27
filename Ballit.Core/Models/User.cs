using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public class User : Entity<long>
    {
        public string Username { get; set; }
        public string Password { get; set; } //todo

        public ICollection<Subballit> Subscriptions { get; set; }
    }
}
