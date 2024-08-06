using Volo.Abp.Settings;

namespace Toolkits.Settings;

public class ToolkitsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ToolkitsSettings.MySetting1));
    }
}
