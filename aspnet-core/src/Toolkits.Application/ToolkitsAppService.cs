using System;
using System.Collections.Generic;
using System.Text;
using Toolkits.Localization;
using Volo.Abp.Application.Services;

namespace Toolkits;

/* Inherit your application services from this class.
 */
public abstract class ToolkitsAppService : ApplicationService
{
    protected ToolkitsAppService()
    {
        LocalizationResource = typeof(ToolkitsResource);
    }
}
