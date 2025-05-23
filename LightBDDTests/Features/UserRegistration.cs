using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System.Threading.Tasks;

namespace LightBDDTests.Features;

[FeatureDescription(
    @"In order to create an account
    As a new user
    I want to register with valid credentials")]
public partial class UserRegistration : FeatureFixture
{
    /*
    Feature: User Registration

      Scenario: Successful registration
        Given the user is not registered
        When the user submits a valid email and password
        Then the system should create a new user and return a success response
    */
    [Scenario]
    public async Task Successful_user_registration()
    {
        await Runner.RunScenarioAsync(
            Given_the_user_is_not_registered,
            When_the_user_submits_a_valid_email_and_password,
            Then_the_system_should_create_a_new_user_and_return_a_success_response
        );
    }

    [Scenario]
    public async Task Registration_with_existing_email_should_fail()
    {
        await Runner.RunScenarioAsync(
            Given_the_user_is_already_registered,
            When_the_user_submits_the_same_email_again,
            Then_the_system_should_return_a_bad_request_response
        );
    }
}

