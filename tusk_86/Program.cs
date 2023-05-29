using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_86
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_86\\XMLFile1.xml");
            XDocument res = new XDocument(new XElement("root"));
            foreach (var item in d.Root.Descendants().Where(el => el.Name.LocalName == "pupil" && el.Parent == d.Root))
            {
                XElement resPers;
                if (res.Root.Element(item.Attribute("name").Value.Replace(' ', '_')) == null) 
                {
                    resPers = new XElement(item.Attribute("name").Value.Replace(' ', '_'));
                    res.Root.Add(resPers);
                }
                resPers = res.Root.Element(item.Attribute("name").Value.Replace(' ', '_'));
                resPers.ReplaceAttributes(item.Attribute("class"));
                var resMark = new XElement("mark" + item.Element("info").Attribute("mark").Value);
                resMark.ReplaceAttributes(item.Element("info").Attribute("subject"));
                resPers.Add(resMark);
            }
            res.Root.ReplaceAll(res.Root.Descendants().Where(el => el.Parent == res.Root).OrderBy(el => el.Name.LocalName));
            foreach (var item in res.Root.Descendants().Where(el => el.Parent == res.Root))
            {
                item.ReplaceAll(item.Descendants().OrderBy(el => el.Name.LocalName).ThenBy(el => el.Attribute("subject").Value));
            }
            res.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_86\\XMLFileResult.xml");
        }
    }
}
