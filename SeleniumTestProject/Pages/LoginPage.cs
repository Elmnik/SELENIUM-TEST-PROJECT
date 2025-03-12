using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTestProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        // Define locators for the login page elements
        private readonly By usernameField = By.Id("username");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("submit");
        private readonly By errorMessage = By.CssSelector(".woocommerce-error");

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Actions on the LoginPage
        public void EnterUsername(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        // Validate error message (if login fails)
        public string GetErrorMessage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(errorMessage).Displayed);
                return driver.FindElement(errorMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        // Validate if login was successful (i.e., we are redirected to the dashboard)
        public bool IsLoginSuccessful()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains("dashboard"));
            return driver.Url.Contains("dashboard");
        }
    }
}