using Toolkits.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Toolkits.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ToolkitsEntityFrameworkCoreModule),
    typeof(ToolkitsApplicationContractsModule)
    )]
public class ToolkitsDbMigratorModule : AbpModule
{
}
