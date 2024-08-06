using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Toolkits.Data;

/* This is used if database provider does't define
 * IToolkitsDbSchemaMigrator implementation.
 */
public class NullToolkitsDbSchemaMigrator : IToolkitsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
