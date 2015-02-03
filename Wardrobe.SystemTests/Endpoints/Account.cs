using System.Net;
using Everest;
using Everest.Content;
using Everest.Headers;
using Everest.Status;
using Newtonsoft.Json;
using Wardrobe.SystemTests.Tests;

namespace Wardrobe.SystemTests.Endpoints
{
    public class Account
    {
        private readonly string _baseUrl;

        public Account(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public RegisterResult Register(TestUser user)
        {
            var url = string.Format("{0}/api/Account/Register", _baseUrl);
            var client = new RestClient();

            var body = new JsonBodyContent(JsonConvert.SerializeObject(new
            {
                user.Email,
                user.Password
            }));

            try
            {
                var response = client.Post(url, body);
                var registerResult = JsonConvert.DeserializeObject<RegisterResult>(response.Body);
                registerResult.StatusCode = response.StatusCode;
                return registerResult;
            }
            catch (UnexpectedStatusException ex)
            {
                return new RegisterResult((HttpStatusCode) ex.StatusCode);
            }
        }

        public HttpStatusCode Logout(LogoutModel logoutModel)
        {
            var url = string.Format("{0}/api/Account/Logout", _baseUrl);
            var client = new RestClient(
                new RequestHeader("Email", logoutModel.Email),
                new RequestHeader("Token", logoutModel.Token));

            try
            {
                var response = client.Post(url, string.Empty);
                return response.StatusCode;
            }
            catch (UnexpectedStatusException ex)
            {
                return (HttpStatusCode) ex.StatusCode;
            }
        }

        public LoginResult Login(LoginModel loginModel)
        {
            var url = string.Format("{0}/api/Account/Authenticate", _baseUrl);
            var client = new RestClient();

            var body = new JsonBodyContent(JsonConvert.SerializeObject(new
            {
                loginModel.Email,
                loginModel.Password
            }));

            try
            {
                var response = client.Post(url, body);
                var loginResult = JsonConvert.DeserializeObject<LoginResult>(response.Body);
                loginResult.StatusCode = response.StatusCode;
                return loginResult;
            }
            catch (UnexpectedStatusException ex)
            {
                return new LoginResult((HttpStatusCode) ex.StatusCode);
            }
        }
    }

    public class RegisterResult
    {
        public RegisterResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public string Token { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class LoginResult
    {
        public LoginResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public string Token { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}