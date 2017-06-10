using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XpathTraining.WrapperFactory;
using System.Configuration;
using XpathTraining.PageFactory;
using XpathTraining.LabConfiguration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XpathTraining.TestCases
{
    class TestCase1:Tests_Lab_Configuration
    {
        [TestCase("Apple")]  
        [TestCase("Samsung")]     
        public void LoginTest(string siteName)
        {
            switch (siteName)
            {
                case "Apple":
                    BrowserFactory.Driver.Url = ConfigurationManager.AppSettings["AppleUrl"];
                    PageGenerator.loginPage.LoginExcecute(siteName);
                    break;

                case "Samsung":
                    BrowserFactory.Driver.Url = ConfigurationManager.AppSettings["SamsungURL"];
                    break;


            }
        }

        [Test]
        public void working_with_dynamic_table()
        {
            int count;

            BrowserFactory.Driver.Url = "http://money.rediff.com/gainers/bsc/daily/groupa";
            
            //number of columns
            IList<IWebElement> col = BrowserFactory.Driver.FindElements(By.XPath("//*[@class='dataTable']//ancestor::th"));
            count = col.Count;

            //number of rows
            IList<IWebElement> rows = BrowserFactory.Driver.FindElements(By
                .XPath("//*[@class='dataTable']/tbody//ancestor::tr"));

            //find 3rd row
            IWebElement baseTable = BrowserFactory.Driver.FindElement(By.TagName("table"));
            IWebElement tblRow= baseTable.FindElement(By.XPath("//*[@class='dataTable']/tbody/tr[3]"));

            //find 3rd columns in 3rd row
            IWebElement tblCol = baseTable.FindElement(By.XPath("//*[@class='dataTable']/tbody/tr[3]/child::td[3]"));

            //get max currency price: 2 ways
            //1.
            double max = 0;
            double temp=0;
            
            for(int i = 1; i <= rows.Count; i++)
            {
                temp = double.Parse(baseTable.FindElement(By.XPath("//*[@class='dataTable']/tbody/tr[" + i + "]/child::td[4]")).Text);
                if (temp > max)
                    max = temp;
            }

            //2.
            IList<IWebElement> currencyPriceList = baseTable.FindElements(By.XPath("//*[@class='dataTable']/tbody/tr/child::td[4]"));
            double[] currencyPrice = new double[currencyPriceList.Count];
            for(int i=0; i < currencyPriceList.Count; i++)
            {
                currencyPrice[i] = double.Parse(currencyPriceList[i].Text);
            }

            max = currencyPrice.Max();
            bool a=  currencyPrice.Any(item => item > 50);
        }

        [Test]
        public void Working_With_DatePicker()
        {
            BrowserFactory.Driver.Url = "https://www.booking.com/index.html?aid=376388;label=bdot-uUisyoAM3zNPS_SJNp9beQS193318462781:pl:ta:p1:p21,093,000:ac:ap1t1:neg:fi:tikwd-334108349:lp1008006:li:dec:dm;ws=&gclid=CNqOsYyzs9QCFYcW0wodVPQI2w";
            IWebElement checkin= BrowserFactory.Driver.FindElement(By.XPath("//div[@class='sb-date-field__display']"));
            checkin.Click();
             IWebElement day= BrowserFactory.Driver.FindElement(By.XPath
                ("//th[contains(text(),'June')]"));

            //find 13 day in june 2017
            IWebElement day2 = BrowserFactory.Driver.FindElement(By.XPath
                ("//div[@data-id='M1496275200000']//ancestor::span[text()='13']"));
            day2.Click();
        }
    }
}
