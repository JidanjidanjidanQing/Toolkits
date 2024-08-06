using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Toolkits.Data;
using Volo.Abp.DependencyInjection;

namespace Toolkits.EntityFrameworkCore;

public class EntityFrameworkCoreToolkitsDbSchemaMigrator
    : IToolkitsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreToolkitsDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ToolkitsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ToolkitsDbContext>()
            .Database
            .MigrateAsync();
    }
}
