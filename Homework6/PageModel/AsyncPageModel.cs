using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;


namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class AsyncPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public AsyncPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement AsyncContent
        {
            get { return this.GetLazyElement(By.CssSelector("div[id*='AsyncContent']"), "Async Page Content"); }
        }

        /// <summary>
        /// Check if the about page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            IWebElement element = this.WebDriver.Wait().ForVisibleElement(By.CssSelector("div[id*='AsyncContent']"));
            return this.AsyncContent.Displayed;
        }
    }
}

