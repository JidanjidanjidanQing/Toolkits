using Toolkits.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Toolkits.Permissions;

public class ToolkitsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ToolkitsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ToolkitsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ToolkitsResource>(name);
    }
}
