using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebTestTask
{
    public class NavigationHelper : HelperBase
    {

        private string baseURL;
        public string lastOffer;
        private string pageLastOffer;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if ((driver.Url == baseURL)|| (driver.Url == baseURL+ "/dashboard"))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
            
        }
       

        public void GoToOffersPage()
        {
            if (driver.Url == baseURL + "/list")
            {
                return;
            }
             driver.Navigate().GoToUrl(baseURL + "/list");
             driver.FindElement(By.XPath("//mat-slide-toggle[@id='mat-slide-toggle-1']")).Click();// включить checkbox
             driver.FindElement(By.XPath("//mat-sidenav/div/div/button[2]/span")).Click();
            
        }
        public void GoToDashboardsPage()
        {
            if (driver.Url == baseURL + "/dashboard")
            {
                return;
            }
           
        }
        public void GoToLastAddedOffer()
        {
            if (driver.Url != baseURL + "/list")
            {
                driver.Navigate().GoToUrl(baseURL + "/list");
            }
            Thread.Sleep(1000);
            
            lastOffer =  driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;
            pageLastOffer = baseURL + "/edit" + "/" + lastOffer;
            if (driver.Url == pageLastOffer)
            {
                return;
            }
            driver.Navigate().GoToUrl(pageLastOffer);
            

        }




    }
}
