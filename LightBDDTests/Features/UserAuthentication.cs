using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System.Threading.Tasks;

namespace LightBDDTests.Features;

[FeatureDescription("User Registration and Login")]
public partial class UserAuthentication : FeatureFixture
{
    [Scenario]
    public async Task Successful_user_registration_and_login()
    {
        await Runner.RunScenarioAsync(
            Given_a_clean_user_store,
            When_the_user_registers_with_valid_credentials,
            Then_the_response_should_be_successful,
            When_the_user_logs_in_with_correct_credentials,
            Then_the_login_should_be_successful
        );
    }
}

