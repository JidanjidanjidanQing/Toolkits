using Toolkits.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Toolkits.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ToolkitsController : AbpControllerBase
{
    protected ToolkitsController()
    {
        LocalizationResource = typeof(ToolkitsResource);
    }
}
