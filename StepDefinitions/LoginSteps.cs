using OpenQA.Selenium;
using SeleniumTestProject.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTestProject.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;

        // Constructor
        public LoginSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver); // Initialize the LoginPage object
        }

        [Given(@"I open the login page")]
        public void GivenIOpenTheLoginPage()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            loginPage.EnterUsername("student");
            loginPage.EnterPassword("Password123");
        }

        [When(@"I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            loginPage.EnterUsername("invalidUser");
            loginPage.EnterPassword("wrongPassword");
        }

        [When(@"I submit the login form")]
        public void WhenISubmitTheLoginForm()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should be redirected to the dashboard")]
        public void ThenIShouldBeRedirectedToTheDashboard()
        {
            Assert.That(loginPage.IsLoginSuccessful(), "Login was not successful, dashboard not found.");
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            string errorMessage = loginPage.GetErrorMessage();
            Assert.That(errorMessage.Contains("ERROR: The username or password you entered is incorrect."));
        }

        [Then(@"I should see a message indicating that fields are required")]
        public void ThenIShouldSeeAMessageIndicatingThatFieldsAreRequired()
        {
            string errorMessage = loginPage.GetErrorMessage();
            Assert.That(errorMessage.Contains("ERROR: Username is required."));
            Assert.That(errorMessage.Contains("ERROR: Password is required."));
        }
    }
}