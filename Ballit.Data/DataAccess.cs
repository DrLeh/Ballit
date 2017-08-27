using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Models;

namespace Ballit.Data
{
    public class DataAccess : IDataAccess, IDisposable
    {
        private BallitContext Context { get; }

        public DataAccess()
        {
            //Context = new BallitContext();
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return Context.Set<T>().AsQueryable();
        }

        public T Query<T>(long id)
            where T : Entity<long>
        {
            return Context.Set<T>().Single(x => x.Id == id);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
