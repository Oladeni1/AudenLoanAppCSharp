using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace MyBDDProjt
{
    public class Util
    {
        public static IWebDriver driver { get; set; }

        public static void Initialize()
        {
            driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            
        }
    }
}