using Volo.Abp.Modularity;

namespace Toolkits;

[DependsOn(
    typeof(ToolkitsApplicationModule),
    typeof(ToolkitsDomainTestModule)
)]
public class ToolkitsApplicationTestModule : AbpModule
{

}
