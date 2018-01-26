using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Repositories;

namespace AHWForm.Repos
{
    public class CurrencyExchangeRepository: ICurrencyExchangeRepository
    {
        private static readonly string linkToService = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        private XmlNodeList nodes;
        private List<XmlNode> lst;
        public CurrencyExchangeRepository()
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

        private decimal GetMultiplier(string first, string second)
        {
            if((first != null) && (second != null))
            { 
                var one = GetAttribute(first, lst).Replace('.', ',');
                var two = GetAttribute(second, lst).Replace('.', ',');
                if ((one != "0") && (two != "0"))
                {
                    return Decimal.Round((Decimal.Parse(two) / Decimal.Parse(one)), 2);
                }
            }
            return 1;
        }

        private string GetAttribute(string attrib, List<XmlNode> lst)
        {
            if (attrib == "EUR")
                return "1";
            foreach (var item in lst)
            {
                if (item.Attributes["currency"]?.Value != null)
                    if (item.Attributes.Count > 0)
                        if (item.Attributes["currency"].Value == attrib)
                        {
                            return item.Attributes["rate"].Value;
                        }
            }
            return null;
        }

        public decimal GetValueInAnotherCurrency(decimal value, string currency, string currency2)
        {
            if (currency == currency2)
                return value;
            return (GetMultiplier(currency, currency2)) * value;
        }
    }
}