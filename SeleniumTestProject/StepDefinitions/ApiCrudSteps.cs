using NUnit.Framework;
using RestSharp;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SeleniumTestProject.StepDefinitions
{
    [Binding]
    public class ApiCrudSteps
    {
        private RestClient client;
        private RestResponse response;
        private JsonDocument? jsonResponse;

        public ApiCrudSteps()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com");
            response = new RestResponse(); // Initialize the response
        }

        [Given(@"se solicita el usuario con ID (.*)")]
        public void GivenSolicitaUsuario(int userId)
{
            var request = new RestRequest($"/users/{userId}", Method.Get);
            response = client.Execute(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                jsonResponse = JsonDocument.Parse(response.Content);
            }
            else
            {
                jsonResponse = null;
            }
        }

[Then(@"el API debería devolver código (.*)")]
        public void ThenApiDevuelveCodigo(int statusCode)
        {
            Assert.Equals(statusCode, (int)response.StatusCode);
        }

        [Then(@"el usuario debería llamarse ""(.*)""")]
        public void ThenUsuarioDebeLlamarse(string expectedName)
        {
            Assert.That(jsonResponse != null, Is.True, "La respuesta del API es nula");
            string actualName = jsonResponse?.RootElement.GetProperty("name").GetString() ?? "";
            Assert.Equals(expectedName, actualName);
        }
    }
}