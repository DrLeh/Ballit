using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Models;
using Ballit.Core.Extensions;
using Xunit;
using FluentAssertions;

namespace Ballit.Core.Test.Extensions
{
    public class VotableExtensionsTest
    {
        private class TestVotable
        {
            public ICollection<IVote> Votes { get; set; } = new List<IVote>();
        }

        IVote CreateVote(long userId, VoteType type) => new PostVote
        {
            UserId = userId,
            Value = type
        };

        [Fact]
        public void Score_0_Test()
        {
            var votable = new TestVotable
            {
                Votes =
                {
                    CreateVote(1, VoteType.Downvote),
                    CreateVote(2, VoteType.None),
                    CreateVote(3, VoteType.Upvote),
                }
            };

            //var result = votable.PostScore();

            //result.Should().Be(0);
        }

        [Fact]
        public void Score_Positive_Test()
        {
            var votable = new TestVotable
            {
                Votes =
                {
                    CreateVote(1, VoteType.Upvote),
                    CreateVote(2, VoteType.Upvote),
                    CreateVote(3, VoteType.Upvote),
                }
            };

            //var result = votable.PostScore();

            //result.Should().Be(3);
        }

        [Fact]
        public void Score_Negative_Test()
        {
            var votable = new TestVotable
            {
                Votes =
                {
                    CreateVote(1, VoteType.Downvote),
                    CreateVote(2, VoteType.Downvote),
                    CreateVote(3, VoteType.Downvote),
                }
            };

            //var result = votable.PostScore();

            //result.Should().Be(-3);
        }
    }
}
