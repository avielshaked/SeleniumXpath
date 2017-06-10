using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XpathTraining.GenericMethods
{
    class GenMethods
    {
        public string Get_Relative_Project_Path()
        {
            string Rpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            int count = 1;
            while (!File.Exists(Rpath + "SeleniumXpath.sln"))
            {
                switch (count)
                {
                    case 1:
                        Rpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\"));
                        count++;
                        break;
                    case 2:
                        Rpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
                        count++;
                        break;
                    case 3:
                        Rpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
                        count++;
                        break;
                    case 4:
                        Rpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));
                        count++;
                        break;
                }
            }
            return Rpath;
        }
    }
}
