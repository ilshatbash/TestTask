using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Windows;
using System.Collections.Generic;


namespace WebTestTask
{
    public class OfferHelper : HelperBase
    {
        public OfferHelper(ApplicationManager manager) : base(manager)
        {

        }
        
        public OfferHelper Create(OfferData offer)
        {
            manager.Navigator.GoToOffersPage();
            Thread.Sleep(1000);
            InitOffersCreation();
            Thread.Sleep(1000);
            FillOfferForm(offer);
            FillOfferAddSegment(7);
            FillOfferAddGroup();
            Thread.Sleep(1000);
            OfferSave();
            ReturnToOffersPage();
            return this;
        }
        public OfferHelper Edit(OfferData offer)
        {
            manager.Navigator.GoToOffersPage();
            Thread.Sleep(1000);
            InitOffersCreation();
            Thread.Sleep(1000);
            FillOfferForm(offer);
            FillOfferAddSegment(7);
            FillOfferAddGroup();
            Thread.Sleep(1000);
            OfferSave();
            Thread.Sleep(1000);
            manager.Navigator.GoToLastAddedOffer();
            Thread.Sleep(300);
            return this;
        }

        public string CurrentName()
        {
            Thread.Sleep(1000);
            IWebElement webelement = driver.FindElement(By.Id("mat-input-0"));
            Thread.Sleep(1000);
            return webelement.GetAttribute("value");
            
        }
        
        public string CurrentKey()
        {
            Thread.Sleep(500);
            IWebElement webelement = driver.FindElement(By.Id("mat-input-1"));
            Thread.Sleep(500);
            return webelement.GetAttribute("value");
        }
       
                public string ExpectedCategory()
        {
                  Thread.Sleep(500);
                  driver.FindElement(By.Id("mat-input-2")).Click();
                  return driver.FindElement(By.XPath("//select/option[@value=1]")).GetAttribute("value");
                 }

        public string CurrentCategory()
        {
            Thread.Sleep(500);
            IWebElement webelement = driver.FindElement(By.Id("mat-input-2"));
            Thread.Sleep(500);
            return webelement.GetAttribute("value");
        }

        public string GetSegment()
        {
             return driver.FindElement(By.Id("mat-select-2")).GetAttribute("value");
        }

           
        public int GetOfferCount()
        {
            return driver.FindElements(By.XPath("//tr/td[3]")).Count;
        }

        public List<OfferData> GetOfferList()

        {
            if (driver.Url != "https://test-task.gameteq.com/list")
            {
                manager.Navigator.GoToOffersPage();
            }
            Thread.Sleep(1000);
            List<OfferData> offers = new List<OfferData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tbody/tr"));
            foreach (IWebElement element in elements)
            {
                var tds = element.FindElements(By.TagName("td"));
                
                var Name = tds[1].Text;
                var Key = tds[2].Text;
                var Id = tds[0].Text;
                if (tds.Count > 0)
                {
                    offers.Add(new OfferData(Id, Name , Key));
                }
                               
            }

                return offers;            
        }
       
        public OfferHelper Remove(int p)
        {
            manager.Navigator.GoToOffersPage();
            RemoveOffer(p);
            ReturnToOffersPage();
            return this;

        }

        public OfferHelper InitOffersCreation()
        {
            driver.FindElement(By.XPath("//body//app-list/button/span")).Click();
            return this;
        }
        public OfferHelper FillOfferForm(OfferData offer)
        {
            Thread.Sleep(1000);
            Type(By.Id("mat-input-0"), offer.Name);
            Type(By.Id("mat-input-1"), offer.Key);
            driver.FindElement(By.Id("mat-input-2")).Click();
            driver.FindElement(By.XPath("//option[@value='1']")).Click();
            driver.FindElement(By.XPath("//mat-select[@id='mat-select-0']/div/div/span")).Click();
            driver.FindElement(By.XPath("//mat-option[@id='mat-option-0']/span")).Click();
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Escape);//иммитация Esc, т.к. расскрывающийся список не закрывается
            driver.FindElement(By.XPath("//mat-card-content/mat-form-field[3]/div/div[1]/div[1]/mat-select/div/div[1]")).Click(); //открытие списка группы
            driver.FindElement(By.XPath("//span[@class='mat-option-text'][1]")).Click(); // выбор первого элемента
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Escape);
            return this;
        }

        private OfferHelper OfferSave()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Save')]")).Click(); //сохранение
            return this;
        }

        public OfferHelper FillOfferAddGroup()
        {
            driver.FindElement(By.XPath("//button[@class='mat-raised-button mat-button-base mat-primary']")).Click();
            return this;
        }

        public OfferHelper FillOfferAddSegment(int indexSegment)
        {
            driver.FindElement(By.XPath("//mat-card/mat-card-title/div/button[2]")).Click();//Добавление сегмента
            driver.FindElement(By.XPath("//div/mat-form-field/div/div[1]/div/mat-select/div/div[2]")).Click();
            driver.FindElement(By.XPath("//div/div/mat-option[" + indexSegment + "]")).Click();// выбор сегмента
            return this;
        }

        public void Type(By locator, string text)
        {
            if (text !=null)
            {
            driver.FindElement(locator).Click();
            driver.FindElement(locator).SendKeys(text);
            }
        }

        public OfferHelper ReturnToOffersPage()
        {
            manager.Navigator.GoToOffersPage();
            return this;
        }
               
        public OfferHelper RemoveOffer(int index)
        {
            driver.FindElement(By.XPath("//mat-sidenav/div/div/button[2]/span")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//body//table/tbody/tr[" + (index+1) + "]/td[4]/button[2]")).Click();
            driver.FindElement(By.XPath("//span[text()='yes!']")).Click();
            return this;
        }
        


    }
}
