using FluentAssertions;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApp.Api;

namespace LightBDDTests.Features;

public partial class UserLogin
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;
    private HttpResponseMessage _response;
    private readonly string _email = "login_test@example.com";
    private readonly string _password = "Password123";

    private async Task Given_the_user_is_already_registered()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();

        var registerRequest = new RegisterRequest
        {
            Email = _email,
            Password = _password
        };

        await _client.PostAsJsonAsync("/api/auth/register", registerRequest);
    }

    private async Task When_the_user_submits_valid_login_credentials()
    {
        var loginRequest = new LoginRequest
        {
            Email = _email,
            Password = _password
        };

        _response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);
    }

    private Task Then_the_system_should_return_a_successful_login_response()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.OK);
        return Task.CompletedTask;
    }

    private async Task When_the_user_submits_incorrect_login_credentials()
    {
        var loginRequest = new LoginRequest
        {
            Email = _email,
            Password = "WrongPassword"
        };

        _response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);
    }

    private Task Then_the_system_should_return_an_unauthorized_response()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        return Task.CompletedTask;
    }
}
