using CognizantSoftvision.Maqs.BaseWebServiceTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Text;
using WebServiceModel;

namespace Tests
{
    /// <summary>
    /// WithAuth test class
    /// </summary>
    [TestClass]
    public class WebServiceApiTests : BaseWebServiceTest
    {
        [TestMethod]
        public void Homework3()
        {
            this.WebServiceDriver.HttpClient.DefaultRequestHeaders.Add("Auth", "AuthKey");

            ArrayOfProducts[] arrayOfProducts = this.WebServiceDriver.Get<ArrayOfProducts[]>("/api/XML_JSON/GetAllProducts", "application/json");
            Assert.AreEqual("Tomato Soup", arrayOfProducts[0].Name, "Wrong Name");
            Assert.AreEqual("Toys", arrayOfProducts[1].Category, "Wrong Category");
            Assert.AreEqual(16.99, arrayOfProducts[2].Price, "Wrong Price");
        }

    }
}
