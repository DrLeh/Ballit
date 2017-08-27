using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ballit.Core.Models
{
    public class Subballit
    {
        [Key]
        public string Name { get; set; }

        //add things like moderators, sidebar, settings
    }
}
