using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class AboutPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public AboutPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement AboutTable
        {
            get { return this.GetLazyElement(By.CssSelector("#AboutTable"), "About Table"); }
        }

        /// <summary>
        /// Check if the about page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.AboutTable.Displayed;
        }
    }
}

