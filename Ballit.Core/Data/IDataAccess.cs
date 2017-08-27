using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Models;

namespace Ballit.Core.Data
{
    public interface IDataAccess
    {
        IQueryable<T> Query<T>() where T : class;
        T Query<T>(long id) where T : Entity<long>;
    }
}
