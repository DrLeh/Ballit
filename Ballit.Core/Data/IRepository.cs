using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Models;

namespace Ballit.Core.Data
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : class;
        T Query<T>(long id) where T : Entity<long>;

        //for internal use only
        T AddOrUpdate<T>(T entity) where T : Entity<long>;
        void Remove<T>(T entity) where T : Entity<long>;
        void Commit();
    }
}
