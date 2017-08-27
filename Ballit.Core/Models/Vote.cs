using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ballit.Core.Models
{
    public enum VoteType
    {
        None = 0,
        Upvote = 1,
        Downvote = -1
    }

    public class Vote
    {
        public Vote() { }
        public Vote(long id, VoteType type, long userId)
        {
            VotableId = id;
            Value = type;
            UserId = userId;
        }

        [Key]
        [Column(Order = 1)]
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        [ForeignKey(nameof(Votable))]
        public long VotableId { get; set; }
        public Votable Votable { get; set; }

        public VoteType Value { get; set; }
        public int IntValue => (int)Value;

        public static implicit operator int(Vote v) => v.IntValue;
    }
}
