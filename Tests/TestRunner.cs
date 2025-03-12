using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestProject.Utils;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTestProject.Tests
{
    [TestFixture]
    public class TestRunner
    {
        private static IWebDriver? driver; // Nullable type

        // Initializes WebDriver before each test
        [SetUp]
        public static void Initialize()
        {
            driver = DriverSetup.GetDriver(); // Initializes WebDriver
        }

        // Cleans up WebDriver after each test
        [TearDown]
        public static void CleanUp()
        {
            if (driver != null)
            {
                driver.Dispose();  // Dispose of WebDriver
                driver = null;     // Set driver to null to avoid further usage
            }
        }

        // Test method
        [Test]
        public void RunTests()
        {
            // Ensure driver is not null before using it
            Assert.IsNotNull(driver, "Driver is null. Test cannot proceed.");

            // Navigate to the URL
            string url = "https://practicetestautomation.com/practice-test-login/";
            driver?.Navigate().GoToUrl(url);

            // Add explicit wait to ensure the page is loaded before checking the title
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.Contains("Login - Practice Test Automation"));

            // Print the page title to debug
            Console.WriteLine("Page Title: " + driver?.Title);

            // Assert to verify the page title
            Assert.AreEqual("Login - Practice Test Automation", driver?.Title);
        }
    }
}