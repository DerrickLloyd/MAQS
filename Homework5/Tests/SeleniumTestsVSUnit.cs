using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;
using OpenQA.Selenium;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {
        [TestMethod]
        public void Homework5()
        {
            string username = "Ted";
            string password = "123";

            //Chrome
            this.ManagerStore.AddOrOverride(new SeleniumDriverManager(() =>
                 WebDriverFactory.GetBrowserWithDefaultConfiguration(BrowserType.Chrome), this.TestObject));

            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());
            homepage.ClickAboutButton();
            AboutPageModel aboutPage = new AboutPageModel(this.TestObject);
            Assert.IsTrue(aboutPage.IsPageLoaded());

            //Firefox Override
            this.ManagerStore.AddOrOverride(new SeleniumDriverManager(() =>
                 WebDriverFactory.GetBrowserWithDefaultConfiguration(BrowserType.Firefox), this.TestObject));

            LoginPageModel pageOverride = new LoginPageModel(this.TestObject);
            pageOverride.OpenLoginPage();
            HomePageModel homepageOverride = pageOverride.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepageOverride.IsPageLoaded());
            homepageOverride.ClickAboutButton();
            AboutPageModel aboutPageOverride = new AboutPageModel(this.TestObject);
            Assert.IsTrue(aboutPageOverride.IsPageLoaded());
        }
    }
}
