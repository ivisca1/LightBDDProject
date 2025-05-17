using LightBDD.Core.Configuration;
using LightBDD.XUnit2;
using LightBDDTests;

[assembly: ClassCollectionBehavior(AllowTestParallelization = true)]
[assembly: ConfiguredLightBddScope]

namespace LightBDDTests
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        protected override void OnConfigure(LightBddConfiguration configuration)
        {
            // LightBDD configuration
        }

        protected override void OnSetUp()
        {
            // code executed before any scenarios
        }

        protected override void OnTearDown()
        {
            // code executed after all scenarios
        }
    }
}
