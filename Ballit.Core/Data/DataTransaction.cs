using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Models;

namespace Ballit.Core.Data
{
    public class DataTransaction : IDataTransaction
    {
        public List<IDataCommand> Commands { get; set; } = new List<IDataCommand>();
        public IRepository Repository { get; }

        public DataTransaction(IRepository repository)
        {
            Repository = repository;
        }

        public void AddOrUpdate<T>(T entity) where T : Entity<long>
        {
            Commands.Add(new AddOrUpdateCommand<T>(entity));
        }

        public void Remove<T>(T entity) where T : Entity<long>
        {
            Commands.Remove(new RemoveCommand<T>(entity));
        }

        public void Commit()
        {
            foreach (var command in Commands)
                command.Execute(Repository);
            Repository.Commit();
        }
    }

    public interface IDataCommand
    {
        void Execute(IRepository repository);
    }

    public class AddOrUpdateCommand<T> : IDataCommand
        where T : Entity<long>
    {
        public T Entity { get; }
        public AddOrUpdateCommand(T entity)
        {
            Entity = entity;
        }

        public void Execute(IRepository repository)
        {
            repository.AddOrUpdate(Entity);
        }
    }

    public class RemoveCommand<T> : IDataCommand
        where T : Entity<long>
    {
        public T Entity { get; }
        public RemoveCommand(T entity)
        {
            Entity = entity;
        }

        public void Execute(IRepository dataAccess)
        {
            dataAccess.Remove(Entity);
        }
    }
}
