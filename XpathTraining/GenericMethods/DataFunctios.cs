using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using XpathTraining.GenericMethods;
using System.Xml;

namespace XpathTraining.GenericMethods
{
    class DataFunctios : GenMethods
    {
        protected string absolutePath = ConfigurationManager.AppSettings["Tdd"];
        protected string RelativePath; 

        public string GetXmlSingleValue(string tagname)
        {
            RelativePath = Get_Relative_Project_Path();

            using (XmlReader reader = XmlReader.Create(RelativePath + absolutePath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString().Equals(tagname))
                            return reader.ReadString();
                    }
                }
            }
            return "NULL";
        }




    }
}
