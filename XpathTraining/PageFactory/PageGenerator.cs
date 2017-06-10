using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpathTraining.PageFactory
{
    class PageGenerator
    {
        private static T GetPage<T>() where T : new()
        {
            T page = new T();
            return page;
        }

        public static LoginPage loginPage
        {
            get { return GetPage<LoginPage>(); }
        }
    }
}
