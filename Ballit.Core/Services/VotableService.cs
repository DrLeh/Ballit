using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Models;

namespace Ballit.Core.Services
{
    public interface IVotableService
    {
        void Vote(Vote vote);
        //getscore, etc
    }

    public abstract class VotableService<T> : IVotableService
    {
        public virtual void Vote(Vote vote)
        {
            //verity that id exists for type T
            //add or update vote

        }
    }
}
