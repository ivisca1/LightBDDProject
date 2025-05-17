using FluentAssertions;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApp.Api;

namespace LightBDDTests.Features;

public partial class UserAuthentication
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;
    private HttpResponseMessage _response;
    private readonly string _testEmail = "test@example.com";
    private readonly string _testPassword = "123456";

    private Task Given_a_clean_user_store()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
        return Task.CompletedTask;
    }

    private async Task When_the_user_registers_with_valid_credentials()
    {
        var registerRequest = new RegisterRequest
        {
            Email = _testEmail,
            Password = _testPassword
        };

        _response = await _client.PostAsJsonAsync("/api/auth/register", registerRequest);
    }

    private Task Then_the_response_should_be_successful()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.OK);
        return Task.CompletedTask;
    }

    private async Task When_the_user_logs_in_with_correct_credentials()
    {
        var loginRequest = new LoginRequest
        {
            Email = _testEmail,
            Password = _testPassword
        };

        _response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);
    }

    private Task Then_the_login_should_be_successful()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.OK);
        return Task.CompletedTask;
    }
}
