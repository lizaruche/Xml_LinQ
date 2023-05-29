using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tusk_66
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument d = XDocument.Load("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_66\\XMLFile1.xml");
            XDocument res = new XDocument(new XElement("root"));

            foreach (var client in d.Descendants().Where(el => el.Name.LocalName == "client"))
            {
                foreach (var info in client.Descendants().Where(el => el.Name.LocalName == "info"))
                {
                    var date = DateTime.Parse(info.Attribute("date").Value);
                    var time = DateTime.ParseExact(info.Attribute("time").Value, "PTH'H'm'M'", null);
                    int numMin = time.Minute + time.Hour * 60;
                    string elName = $"d{date.Year}-{date.Month}";
                    if (res.Root.Element(elName) == null)
                    {
                        var dateEl = new XElement(elName);
                        dateEl.SetAttributeValue("total-time", 0);
                        dateEl.SetAttributeValue("client-count", 0);
                        res.Root.Add(dateEl);
                    }
                    var dateRes = res.Root.Element(elName);
                    dateRes.Attribute("client-count").Value = (int.Parse(dateRes.Attribute("client-count").Value) + 1).ToString();
                    dateRes.Attribute("total-time").Value = (int.Parse(dateRes.Attribute("total-time").Value) + numMin).ToString();
                    var clientRes = new XElement("id" + client.Attribute("id").Value);
                    clientRes.SetAttributeValue("time", numMin);
                    dateRes.Add(clientRes);
                }
            }
            res.Root.ReplaceAll(res.Root.Descendants().Where(el => el.Parent == res.Root).OrderByDescending(el => el.Name.LocalName));
            foreach (var item in res.Root.Descendants().Where(el => el.Parent == res.Root))
            {
                item.ReplaceAll(item.Descendants().Where(el => el.Parent == item).OrderBy(el => el.Name.LocalName));
            }
            res.Save("C:\\Users\\arsen\\source\\repos\\Xml_LinQ\\tusk_66\\XMLFileResult.xml");
        }
    }
}
