using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using XpathTraining.GenericMethods;

namespace XpathTraining.WrapperFactory
{
    class BrowserFactory : DataFunctios
    {
        static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                return  _driver;
            }
            set
            {
                _driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    if (Driver == null)
                    {
                        _driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);                    
                    }
                    break;
            }
        }

        public static void LoadApp(string Url)
        {
            Driver.Url = Url;
        }

        public static void CloseDrivers()
        {
            foreach(var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
            _driver = null;
            Drivers.Remove("Chrome");
        }

    }
}
