using CognizantSoftvision.Maqs.BaseWebServiceTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebServiceModel;
using HttpClientFactory = CognizantSoftvision.Maqs.BaseWebServiceTest.HttpClientFactory;
using CognizantSoftvision.Maqs.Utilities.Helper;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Tests
{
    [TestClass]
    public class WebServiceApiTests : BaseWebServiceTest
    {

        /// <summary>
        /// Setup our webservice driver
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.ManagerStore.AddOrOverride(new WebServiceDriverManager(() =>
            {
                HttpClient client = HttpClientFactory.GetClient(
                    new Uri(Config.GetValueForSection(ConfigSection.WebServiceMaqs, "WebServiceUri")), WebServiceConfig.GetWebServiceTimeout());
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Auth", "AuthKey");
                return client;
            }, this.TestObject));
        }

        [TestMethod]
        public void Homework3()
        {

            ArrayOfProducts[] arrayOfProducts = this.WebServiceDriver.Get<ArrayOfProducts[]>("/api/XML_JSON/GetAllProducts", "application/json");
            Assert.AreEqual("Tomato Soup", arrayOfProducts[0].Name, "Wrong Name");
            Assert.AreEqual("Toys", arrayOfProducts[1].Category, "Wrong Category");
            Assert.AreEqual(16.99, arrayOfProducts[2].Price, "Wrong Price");
            Assert.AreEqual(3, arrayOfProducts.Length, "Wrong Count of Products");
        }

    }
}
