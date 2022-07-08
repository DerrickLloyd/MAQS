using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class HowItWorksPageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HowItWorksPageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HowItWorksPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement HowItWorksText
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWorks"), "How It Works Text"); }
        }

        /// <summary>
        /// Check if the about page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.HowItWorksText.Displayed;
        }
    }
}

