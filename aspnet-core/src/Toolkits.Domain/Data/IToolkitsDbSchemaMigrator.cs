using System.Threading.Tasks;

namespace Toolkits.Data;

public interface IToolkitsDbSchemaMigrator
{
    Task MigrateAsync();
}
