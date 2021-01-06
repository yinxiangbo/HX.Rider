using HX.Rider.API;
using HX.Rider.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HX.Rider.APITests
{
    [TestClass]
    public class AccountControllerTests
    {
        private readonly TestHostFixture _testHostFixture = new TestHostFixture();
        private HttpClient _httpClient;
        private IServiceProvider _serviceProvider;

        [TestInitialize]
        public void SetUp()
        {
            _httpClient = _testHostFixture.Client;
            _serviceProvider = _testHostFixture.ServiceProvider;
        }
        [TestMethod]
        public async Task ShouldReturnCorrectResponseForSuccessAuth()
        {
            var credentials = new LoginRequest
            {
                UserName = "hxrc2",
                Password = "hx_2020"
            };
            var loginResponse = await _httpClient.PostAsync("api/user/login",
                new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, MediaTypeNames.Application.Json));

            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

            var loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
            var loginResult = JsonConvert.DeserializeObject<ApiResult<LoginResult>>(loginResponseContent);
            Assert.IsNotNull(loginResult.Data);
            Assert.AreEqual(credentials.UserName, loginResult.Data.UserName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.Data.AccessToken));
            Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.Data.RefreshToken));
        }

        [TestMethod]
        public async Task ShouldReturnCorrectResponseForRegister()
        {
            var registerModel = new RegisterRequest() {
                UserName="hxrc2",
                Password="hx_2020",
                MobilePhone="13165018829",
                IDNumber="320721198610151617"
            };

            var registerResponse = await _httpClient.PostAsync("api/user/register",
                new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, MediaTypeNames.Application.Json));
            Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

            var responseContent = await registerResponse.Content.ReadAsStringAsync();
            var registerResult = JsonConvert.DeserializeObject<ApiResult<LoginResult>>(responseContent);
            Assert.IsNotNull(registerResult.Data);
        }
    }
}
