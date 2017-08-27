using System.ComponentModel.DataAnnotations;

namespace Ballit.Core.Models
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
