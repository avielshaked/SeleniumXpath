using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using XpathTraining.WrapperFactory;
using XpathTraining.ElementsRepository;


namespace XpathTraining.PageFactory
{
    class LoginPage : App_Elements
    {
        string user;
        string password;

       public void LoginExcecute(string site)
        {
            switch (site)
            {
                case "Apple":
                    user = GetXmlSingleValue("AppleUser");
                    password = GetXmlSingleValue("ApplePassword");
                    break;
                case "Samsung":
                    user = GetXmlSingleValue("SamsungUser");
                    password = GetXmlSingleValue("SamsungPassword");
                    break;
            }

            Identify_Input.SendKeys(user);
            Password.SendKeys(password);
        }
    }
}
