using Core.Configuration;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Selenium
{
    public class Browser
    {
        private static readonly ThreadLocal<Browser> BrowserInstances = new();
        public static Browser Instance => GetBrowser();

        public static Logger Logger = LogManager.GetCurrentClassLogger();

        private IWebDriver driver;
        public IWebDriver? Driver { get { return driver; } }

        private static Browser GetBrowser()
        {
            return BrowserInstances.Value ?? (BrowserInstances.Value = new Browser());
        }

        private Browser()
        {
            driver = AppConfiguration.Browser.Type.ToLower() switch
            {
                "chrome" => DriverFactory.GetChromeDriver(),
                "firefox" => DriverFactory.GetFirefoxDriver(),
                _ => DriverFactory.GetChromeDriver()
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfiguration.Browser.TimeOut);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            BrowserInstances.Value = null;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Logger.Info("Navigate to url: {0}", url);
        }

        public void AcceptAllert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void AcceptDismiss()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void SwitchToFrame(string id)
        {
            driver.SwitchTo().Frame(id);
        }

        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void ContextClickToElement(IWebElement element)
        {
            new Actions(driver)
                .ContextClick(element)
                .Build()
                .Perform();
        }

        public object ExecuteScript(string script, object argument = null)
        {
            try
            {
                Logger.Debug($"Execute script: {script}");
                return ((IJavaScriptExecutor)driver).ExecuteScript(script, argument);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string getElementXPath(WebElement element)
        {
            return (string)ExecuteScript(
                "gPt=function(c){if(c.id!==''){return'id(\"'+c.id+'\")'}if(c===document.body){return c.tagName}var a=0;var e=c.parentNode.childNodes;for(var b=0;b<e.length;b++){var d=e[b];if(d===c){return gPt(c.parentNode)+'/'+c.tagName+'['+(a+1)+']'}if(d.nodeType===1&&d.tagName===c.tagName){a++}}};return gPt(arguments[0]).toLowerCase();",
                element);
        }
    }
}