using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Models;

namespace Ballit.Core.Extensions
{
    public static class VotableExtensions
    {
        ///// <summary>
        ///// The total sum of votes on a votable
        ///// </summary>
        //public static int PostScore(this IVotable voteable)
        //{
        //    //put in more interesting calculation
        //    return voteable.Votes.OrEmptyIfNull().Sum(x => x.IntValue);
        //}

        ///// <summary>
        ///// Score to use while ordering on the page based on timing
        ///// </summary>
        //public static int OrderScore(this IVotable votable)
        //{
        //    return votable.PostScore(); //todo, will need to factor in createdate
        //}
    }
}
