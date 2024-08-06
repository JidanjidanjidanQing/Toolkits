using Volo.Abp.Modularity;

namespace Toolkits;

/* Inherit from this class for your domain layer tests. */
public abstract class ToolkitsDomainTestBase<TStartupModule> : ToolkitsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
