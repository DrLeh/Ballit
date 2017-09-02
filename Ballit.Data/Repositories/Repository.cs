

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Models;

namespace Ballit.Data.Repositories
{
    public class Repository : IRepository, IDisposable
    {
        private BallitContext Context { get; }

        public Repository(BallitContext context)
        {
            Context = context;
        }

        public IDataTransaction CreateTransaction()
        {
            return new DataTransaction(this);
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

        public T AddOrUpdate<T>(T entity) where T : Entity<long>
        {
            if (entity.Id == 0)
                Context.Set<T>().Add(entity);
            else
                Context.Set<T>().Update(entity);

            Context.SaveChanges();
            return entity;
        }

        public void Remove<T>(T entity) where T : Entity<long>
        {
            Context.Set<T>().Remove(entity);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
