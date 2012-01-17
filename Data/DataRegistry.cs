using StructureMap.Configuration.DSL;
using Data.Repository;
using Core.Configuration;

namespace Data
{
    public class DataRegistry : Registry
    {

        public DataRegistry() {

            For<Core.Infrastructure.IUnitOfWork>()
                        .HybridHttpOrThreadLocalScoped()
                        .Use<Data.Repository.UnitOfWork>();
            SelectConstructor<Data.Repository.UnitOfWork>( () => new Data.Repository.UnitOfWork( (IDatabaseFactory)null ) );

            For<IDatabase>()
                .HybridHttpOrThreadLocalScoped()
                .Use<Database>()
                .Ctor<IConnectionString>("connectionString").IsTheDefault();
            SelectConstructor<Database>(() => new Database((IConnectionString)null));

            For<IDatabaseFactory>()
                .HybridHttpOrThreadLocalScoped()
                .Use<DatabaseFactory>();
        }
    }
}
