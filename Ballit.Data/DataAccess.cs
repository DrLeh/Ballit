using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Models;

namespace Ballit.Data
{
    public class DataAccess : IDataAccess
    {
        public IRepository Repository { get; }

        public DataAccess(IRepository repository)
        {
            Repository = repository;
        }

        public IDataTransaction CreateTransaction()
        {
            return new DataTransaction(Repository);
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return Repository.Query<T>();
        }

        public T Query<T>(long id)
            where T : Entity<long>
        {
            return Repository.Query<T>().Single(x => x.Id == id);
        }
    }
}
