using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext test)
        {
            System.Console.WriteLine("Class Setup");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            System.Console.WriteLine("Function Teardown");
        }

        [TestMethod]
        public void ValidLoginTest()
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
            homepage.ClickHowItWorksButton();
            HowItWorksPageModel howItWorksPage = new HowItWorksPageModel(this.TestObject);
            Assert.IsTrue(howItWorksPage.IsPageLoaded());
            homepage.ClickAsyncButton();
            AsyncPageModel asyncPage = new AsyncPageModel(this.TestObject);
            Assert.IsTrue(asyncPage.IsPageLoaded());
        }

        [TestMethod]
        [DataRow("invalidUsername1", "invalidPassword1")]
        [DataRow("invalidUsername2", "invalidPassword2")]
        [DataRow("invalidUsername3", "invalidPassword3")]
        [DataRow("invalidUsername4", "invalidPassword4")]
        [DataRow("invalidUsername5", "invalidPassword5")]
        public void InvalidLoginTest(string username, string password)
        {

            //Chrome
            this.ManagerStore.AddOrOverride(new SeleniumDriverManager(() =>
                 WebDriverFactory.GetBrowserWithDefaultConfiguration(BrowserType.Chrome), this.TestObject));

            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            bool invalidLogin = page.LoginWithInvalidCredentials(username, password);
            Assert.IsTrue(invalidLogin);
        }
    }
}
