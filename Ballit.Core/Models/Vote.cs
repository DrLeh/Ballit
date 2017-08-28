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

    public class PostVote : IVote
    {
        public PostVote() { }
        public PostVote(long id, VoteType type, long userId)
        {
            PostId = id;
            Value = type;
            UserId = userId;
        }

        [Key]
        [Column(Order = 1)]
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        [ForeignKey(nameof(Post))]
        public long PostId { get; set; }
        public Post Post { get; set; }

        public VoteType Value { get; set; }
        public int IntValue => (int)Value;

        public static implicit operator int(PostVote v) => v.IntValue;
    }

    public class CommentVote : IVote
    {
        public CommentVote() { }
        public CommentVote(long id, VoteType type, long userId)
        {
            CommentIdId = id;
            Value = type;
            UserId = userId;
        }

        [Key]
        [Column(Order = 1)]
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public User User { get; set; }

        [Column(Order = 2)]
        [ForeignKey(nameof(Comment))]
        public long CommentIdId { get; set; }
        public Comment Comment { get; set; }

        public VoteType Value { get; set; }
        public int IntValue => (int)Value;

        public static implicit operator int(CommentVote v) => v.IntValue;
    }
}
