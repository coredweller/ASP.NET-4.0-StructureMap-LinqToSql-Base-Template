using Core.Helpers;
using System.Diagnostics;

namespace Core.Configuration
{
    public class ConnectionString: IConnectionString
    {
        private readonly string _value;

        public ConnectionString(IAppConfigManager configManager, string connectionStringKey)
        {
            Checks.Argument.IsNotEmpty(connectionStringKey, "connectionStringKey");
            Checks.Argument.IsNotNull(configManager, "configManager");
            try
            {
                _value = configManager.ConnectionStrings(connectionStringKey);
            }
            catch
            {
                throw;
            }
        }

        public string Value
        {
            [DebuggerStepThrough]
            get
            {
                return _value;
            }
        }
    }
}
