using Volo.Abp.Modularity;

namespace Toolkits;

[DependsOn(
    typeof(ToolkitsDomainModule),
    typeof(ToolkitsTestBaseModule)
)]
public class ToolkitsDomainTestModule : AbpModule
{

}
