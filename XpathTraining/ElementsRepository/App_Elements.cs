using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using XpathTraining.WrapperFactory;
using XpathTraining.GenericMethods;


namespace XpathTraining.ElementsRepository
{
    class App_Elements : BrowserFactory
    {
        private static IWebElement _Identify_Input;
        internal static IWebElement Identify_Input
        {
            get { return _Identify_Input = Driver.FindElement(By.XPath("//*[@name='svcIptLgnID' or @name='appleId']")); }
            set { _Identify_Input = null; }
        }

        private static IWebElement _Password;
        internal static IWebElement Password
        {
            get { return _Password = Driver.FindElement(By.XPath("//*[@name='accountPassword' or @name='svcIptLgnPD']"));  }
            set { _Password = null; }
        }

        
    }
}
