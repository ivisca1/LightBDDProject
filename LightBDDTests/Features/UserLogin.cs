using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System.Threading.Tasks;

namespace LightBDDTests.Features;

[FeatureDescription(
    @"In order to access my account
    As a registered user
    I want to be able to log in with my email and password")]
public partial class UserLogin : FeatureFixture
{
    [Scenario]
    public async Task Successful_login()
    {
        await Runner.RunScenarioAsync(
            Given_the_user_is_already_registered,
            When_the_user_submits_valid_login_credentials,
            Then_the_system_should_return_a_successful_login_response
        );
    }

    [Scenario]
    public async Task Failed_login_due_to_invalid_credentials()
    {
        await Runner.RunScenarioAsync(
            Given_the_user_is_already_registered,
            When_the_user_submits_incorrect_login_credentials,
            Then_the_system_should_return_an_unauthorized_response
        );
    }
}
