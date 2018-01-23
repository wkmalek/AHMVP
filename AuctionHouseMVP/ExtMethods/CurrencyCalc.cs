using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http.ExceptionHandling;
using System.Xml;
using System.Xml.Serialization;
using Antlr.Runtime.Tree;


namespace AHWForm.ExtMethods
{
    public class CurrencyCalc
    {
        private static readonly string linkToService = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        private XmlNodeList nodes;
        private List<XmlNode> lst;
        public CurrencyCalc()
        {
            List<string> finallist = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(linkToService);

            XmlElement root = doc.DocumentElement;
            nodes = root.GetElementsByTagName("Cube");
            lst = new List<XmlNode>();
            for (int i = 0; i < nodes.Count; i++)
            {
                lst.Add(nodes[i]);
            }
           
        }

        public decimal GetMultiplier(string first, string second)
        {
            var one = GetAttribute(first, lst);
            var two = GetAttribute(second, lst);
            if ((one != null) && (two != null) && (one != "0") && (two != "0"))
            {
                return Decimal.Parse(two) / Decimal.Parse(one);
            }
            return 0;
        }

        public string GetAttribute(string attrib, List<XmlNode> lst)
        {
            if (attrib == "EUR")
                return "1";
            foreach (var item in lst)
            {
                if(item.Attributes["currency"]?.Value != null)
                    if(item.Attributes.Count > 0)
                        if (item.Attributes["currency"].Value == attrib)
                        {
                            return item.Attributes["rate"].Value;
                        }
            }
            return null;
        }
    }
}