using System.Net;
using Everest;
using Everest.Content;
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

        public object Register(TestUser user)
        {
            var url = string.Format("{0}/api/Account/Authenticate", _baseUrl);
            var client = new RestClient();

        }

        public object Logout(LogoutModel logoutModel)
        {
            var url = string.Format("{0}/api/Account/Authenticate", _baseUrl);
            var client = new RestClient();
        }

        public object Login(LoginModel loginModel)
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
}