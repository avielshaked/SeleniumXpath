using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XpathTraining.WrapperFactory;
using System.Configuration;

namespace XpathTraining.LabConfiguration
{
    class Tests_Lab_Configuration
    {
        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser("Chrome");           
        }

        [TearDown]
        public void TearDown()
        {
            BrowserFactory.CloseDrivers();
        }
    }
}
