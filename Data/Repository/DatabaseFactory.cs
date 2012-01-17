using Core;
using Core.Infrastructure.Logging;
using Core.Configuration;
using Core.Helpers;
using System.Data.Linq;

namespace Data.Repository
{
    public class DatabaseFactory : DisposableResource, IDatabaseFactory
    {
        private readonly string _connectionString;
        private readonly ILogWriter _logWriter;
        public IDatabase _database;

        public DatabaseFactory(IConnectionString connectionString, ILogWriter logWriter)
        {
            Checks.Argument.IsNotNull(connectionString, "connectionString");

            _connectionString = connectionString.Value;
            _logWriter = logWriter;
        }


        #region IPhishDatabaseFactory Members

        public IDatabase Get()
        {
            if (_database == null)
            {
                DataLoadOptions options = new DataLoadOptions();

                //options.LoadWith<Show>(s => s.);

                _database = new Database(_connectionString) 
                    { 
                        LoadOptions = options, 
                        DeferredLoadingEnabled = true, 
                        Log = (_logWriter == null ? null : _logWriter.Get()) 
                    };
            }

            return _database;
        }

        #endregion
    }
}
