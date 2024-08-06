using Volo.Abp.Modularity;

namespace Toolkits;

public abstract class ToolkitsApplicationTestBase<TStartupModule> : ToolkitsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
