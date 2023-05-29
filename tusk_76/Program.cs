using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_76
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_76\\XMLFile1.xml");
            XDocument res = new XDocument(new XElement("root"));
            foreach (var item in d.Root.Descendants().Where(el => el.Name.LocalName == "record" && el.Parent == d.Root))
            {
                var debt = new XElement("debt");
                var val = new XElement("value");
                val.Value = item.Element("debt").Value;
                debt.Add(val);
                debt.Add(item.Element("name"));
                debt.SetAttributeValue("house", item.Element("house").Value);
                debt.SetAttributeValue("flat", item.Element("flat").Value);

                res.Root.Add(debt);
            }
            res.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_76\\XMLFileResult.xml");
        }
    }
}
