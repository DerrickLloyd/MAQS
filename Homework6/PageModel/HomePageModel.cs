using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class HomePageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HomePageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets about button
        /// </summary>
        private LazyElement AboutButton
        {
            get { return this.GetLazyElement(By.CssSelector("#About"), "About button"); }
        }

        /// <summary>
        /// Gets How It Works button
        /// </summary>
        private LazyElement HowItWorksButton
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWork"), "How It Works button"); }
        }

        /// <summary>
        /// Gets Async button
        /// </summary>
        private LazyElement AsyncButton
        {
            get { return this.GetLazyElement(By.CssSelector("#Async"), "Async button"); }
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement WelcomeMessage
        {
            get { return this.GetLazyElement(By.CssSelector("#WelcomeMessage"), "Welcome message"); }
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.WelcomeMessage.Displayed;
        }

        /// <summary>
        /// Click About Button
        /// </summary>
        public void ClickAboutButton()
        {
            this.AboutButton.Click();
        }

        /// <summary>
        /// Click How It Works Button
        /// </summary>
        public void ClickHowItWorksButton()
        {
            this.HowItWorksButton.Click();
        }

        /// <summary>
        /// Click Async Button
        /// </summary>
        public void ClickAsyncButton()
        {
            this.AsyncButton.Click();
        }
    }
}

