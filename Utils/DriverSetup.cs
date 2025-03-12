using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestProject.Utils;

namespace SeleniumTestProject.Utils
{
    public static class DriverSetup
    {
        private static IWebDriver? driver;

        // Method to get WebDriver (creates a new instance if not already created)
        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(); // Initialize ChromeDriver
            }
            return driver;
        }

        // Method to close the WebDriver
        public static void CloseDriver()
        {
            driver?.Quit(); // Ensure driver quits and closes the browser
            driver = null;  // Set driver to null to avoid further usage
        }
    }
}