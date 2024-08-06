using Xunit;

namespace Toolkits.EntityFrameworkCore;

[CollectionDefinition(ToolkitsTestConsts.CollectionDefinitionName)]
public class ToolkitsEntityFrameworkCoreCollection : ICollectionFixture<ToolkitsEntityFrameworkCoreFixture>
{

}
