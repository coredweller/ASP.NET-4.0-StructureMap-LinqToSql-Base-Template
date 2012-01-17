using System.IO;

namespace Core.Infrastructure.Logging
{
    public interface ILogWriter
    {
        TextWriter Get();
    }
}
