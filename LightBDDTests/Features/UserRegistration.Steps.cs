using FluentAssertions;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApp.Api;

namespace LightBDDTests.Features;

public partial class UserRegistration
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;
    private HttpResponseMessage _response;
    private readonly string _email = "test@example.com";
    private readonly string _password = "123456";

    private Task Given_the_user_is_not_registered()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
        return Task.CompletedTask;
    }

    private async Task When_the_user_submits_a_valid_email_and_password()
    {
        var request = new RegisterRequest
        {
            Email = _email,
            Password = _password
        };

        _response = await _client.PostAsJsonAsync("/api/auth/register", request);
    }

    private Task Then_the_system_should_create_a_new_user_and_return_a_success_response()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.OK);
        return Task.CompletedTask;
    }

    private async Task Given_the_user_is_already_registered()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();

        var request = new RegisterRequest
        {
            Email = _email,
            Password = _password
        };

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    private async Task When_the_user_submits_the_same_email_again()
    {
        var request = new RegisterRequest
        {
            Email = _email,
            Password = _password
        };

        _response = await _client.PostAsJsonAsync("/api/auth/register", request);
    }

    private Task Then_the_system_should_return_a_bad_request_response()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        return Task.CompletedTask;
    }

}
