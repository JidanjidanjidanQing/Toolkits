using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Toolkits;

[Dependency(ReplaceServices = true)]
public class ToolkitsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Toolkits";
}
