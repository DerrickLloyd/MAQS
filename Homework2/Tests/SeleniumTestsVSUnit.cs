using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.Utilities.Helper;
using CognizantSoftvision.Maqs.Utilities.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageModel;
using System;
using System.IO;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {
        [TestMethod]
        public void Homework2()
        {
            // Grab values from configuration and store to value and object collections
            this.TestObject.SetValue("Username", Config.GetGeneralValue("Username"));
            this.TestObject.SetObject("Password", Config.GetGeneralValue("Password"));

            // Open Login Page
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            Assert.IsTrue(page.IsPageLoaded());
            this.Log.LogMessage(MessageType.SUCCESS, "Login Page is Successfully Opened");
            
            // Login
            this.PerfTimerCollection.StartTimer("Login timer");
            page.EnterCredentials(this.TestObject.Values["Username"], this.TestObject.Objects["Password"] as string);
            HomePageModel homepage = page.LoginAfterAddingValidCredentials();
            Assert.IsTrue(homepage.IsPageLoaded());
            this.PerfTimerCollection.StopTimer("Login timer");
            this.Log.LogMessage(MessageType.SUCCESS, "User Successfully Logged In");
        }
    }
}
