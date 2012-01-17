using log4net;
using Core.Helpers;
using Core.Repository;
using Core.Infrastructure.Logging;

namespace Data.Repository
{
    

    public abstract class BaseRepository<TInterface, TClass> : IRepository<TInterface> where TClass : class
    {
        private readonly ILog log = LogManager.GetLogger(typeof(TClass));
        private readonly IDatabase _database;

        protected BaseRepository(IDatabase database)
        {
            Checks.Argument.IsNotNull(database, "database");

            _database = database;
        }

        protected BaseRepository(IDatabaseFactory factory)
            : this(factory.Get())
        {
        }


        protected internal IDatabase Database
        {
            get
            {
                return _database;
            }
        }


        public virtual void Remove(TInterface entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");
            LoggedActionFactory.BeforeEntityRemove(log, entity as TClass);
            Database.Delete(entity as TClass);
            LoggedActionFactory.AfterEntityRemove(log, entity as TClass);
        }

        
        public virtual void Add(TInterface entity)
        {
            Checks.Argument.IsNotNull(entity, "entity");
            LoggedActionFactory.BeforeEntityAdd(log, entity as TClass);
            Database.Insert(entity as TClass);
            LoggedActionFactory.AfterEntityAdd(log, entity as TClass);
        }
    }
}
