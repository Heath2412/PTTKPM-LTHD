using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.DAL;
using System.Xml.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestXML test = new TestXML();
            XElement xelement = new XElement("testname");
            xelement.SetAttributeValue("abc", "def");
            test.XmlWrapper = xelement;

            RepositoryImpl<TestXML> rep = new RepositoryImpl<TestXML>();
            rep.Insert(test);
            rep.Save();

            xelement.SetAttributeValue("abc", "aha");
            test.XmlWrapper = xelement;
            System.Console.WriteLine(xelement.Attribute("abc").ToString());
            rep.Update(test);
            rep.Save();
        }
    }
}
