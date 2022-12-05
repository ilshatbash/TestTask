using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebTestTask
{
    [TestFixture]
    public class OfferRemovalTest : TestBase
    {
        [Test]
        public void OfferRemovalTests()
        {
            Random rnd = new Random();
            string name, key;
            List<OfferData> testOffers = app.Offers.GetOfferList();
            if (testOffers.Count == 0)
            {
                int ff = rnd.Next(1000);
                name = "name" + ff.ToString();
                key = "key" + ff.ToString();
                OfferData offer = new OfferData(name, key);
                app.Offers.Create(offer);
            }
            List<OfferData> oldOffers = app.Offers.GetOfferList();
            app.Offers.Remove(0);
            Thread.Sleep(500);
            List<OfferData> newOffers = app.Offers.GetOfferList();
            Assert.AreEqual(oldOffers.Count-1 , newOffers.Count);
            oldOffers.RemoveAt(0);
            Assert.AreEqual(oldOffers, newOffers);
            

        }
        
    }
}
