using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpathTraining.ElementsRepository
{
    class ElementGenerator
    {
        private static T GetPage_Element<T>() where T : new()
        {
            T page = new T();
            return page;
        }

        public static App_Elements App_elements
        {
            get { return GetPage_Element<App_Elements>(); }
        }
    }
}
