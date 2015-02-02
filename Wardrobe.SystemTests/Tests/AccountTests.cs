using System;
using System.Net;
using NUnit.Framework;
using Wardrobe.SystemTests.Endpoints;

namespace Wardrobe.SystemTests.Tests
{
    [TestFixture(Category = "SystemTests")]
    public class AccountTests
    {
        [Test]
        public void WhenValidUserRegistersAndLogsInThenTokenIsReturned()
        {
            var user = TestUser.CreateRandom();
            var account = new Account(BaseUrl.Get());

            var registerResult = account.Register(user);
            Assert.That(registerResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var logoutResult = account.Logout(new LogoutModel(user.Email, user.Token));
            Assert.That(logoutResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var loginResult = account.Login(new LoginModel(user.Email, user.Password));
            Assert.That(loginResult.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(loginResult.Token, !Is.EqualTo(null));
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class LogoutModel
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public LogoutModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }

    public class TestUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public static TestUser CreateRandom()
        {
            return new TestUser
            {
                Email = string.Format("{0}@test.com", Guid.NewGuid()),
                Password = "Password1"
            };
        }
    }

    public static class BaseUrl
    {
        public static string Get()
        {
            return "http://http://localhost:59641/";
        }
    }
}