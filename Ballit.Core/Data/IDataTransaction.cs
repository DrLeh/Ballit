using Ballit.Core.Models;

namespace Ballit.Core.Data
{
    public interface IDataTransaction
    {
        void AddOrUpdate<T>(T entity) where T : Entity<long>;
        void Commit();
        void Remove<T>(T entity) where T : Entity<long>;
    }
}