using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebTestTask
{
    [TestFixture]
    public class OfferCreationTest : TestBase
    {
        
        Random rnd = new Random();
        string name, key;
        [Test]
        public void OfferCreationTests()
        {
            
            List<OfferData> oldOffers = app.Offers.GetOfferList();
            int ff = rnd.Next(1000);
            name = "name" + ff.ToString();
            key = "key" + ff.ToString();
            OfferData offer = new OfferData(name,key);
            app.Offers.Create(offer);
            List<OfferData> newOffers = app.Offers.GetOfferList();
            Assert.AreEqual(oldOffers.Count + 1, newOffers.Count, "The total number of records is not what you expected"); //сравнение общего количества
            oldOffers.Add(offer);
            oldOffers.Sort();
            newOffers.Sort();
            Assert.AreEqual(oldOffers, newOffers, "The input data is different from the existing one"); //сравнение списков


        }

        [Test]
        public void OfferCreationTestsNegativ()
        {
            //данные с недопустимыми данными не должны добавляться в список
            //значения добавляются, однако в списках не совпадат добавленные и оожидаемые значения
            List<OfferData> oldOffers = app.Offers.GetOfferList();
            name = " ";
            key = " ";
            OfferData offer = new OfferData(name, key);
            app.Offers.Create(offer);
            List<OfferData> newOffers = app.Offers.GetOfferList();
            Assert.AreEqual(oldOffers.Count+1, newOffers.Count, "The total number of records is not what you expected"); //сравнение общего количества
            oldOffers.Add(offer);
            oldOffers.Sort();
            newOffers.Sort();
            Assert.AreNotEqual(oldOffers, newOffers, "The input data is different from the existing one"); //сравнение списков

        }

        [Test]
        public void OfferEditTests()
        {

            int ff = rnd.Next(1000);
            name = "IVAN" + ff.ToString();
            key = "ass" + ff.ToString();
           
            OfferData offer = new OfferData(name, key);
            app.Offers.Edit(offer);
            Thread.Sleep(1000);
            Assert.AreEqual(name, app.Offers.CurrentName(), "The Name does not match the entered");
            Thread.Sleep(1000);
            Assert.AreEqual(key, app.Offers.CurrentKey(), "The Key does not match the entered");
            Thread.Sleep(500);
            Assert.AreEqual(app.Offers.ExpectedCategory(), app.Offers.CurrentCategory(), "The category does not match the entered");
            Thread.Sleep(500);
           // Assert.AreEqual("Asfa" ,app. Offers.GetSegment());//проверка сегментов- не успел сделать

        }


    }
}