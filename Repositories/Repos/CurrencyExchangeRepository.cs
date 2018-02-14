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
        private const string linkToService = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        private readonly List<XmlNode> lst;
        public CurrencyExchangeRepository()
        {
            //var finallist = new List<string>();
            var doc = new XmlDocument();
            try
            {
                doc.Load(linkToService);
            }
            catch (Exception e)
            {
                //TODO exception handle here

                return;
            }
            
            XmlElement root = doc.DocumentElement;
            if (root == null) return;
            var nodes = root.GetElementsByTagName("Cube");
            lst = new List<XmlNode>();
            for (var i = 0; i < nodes.Count; i++)
            {
                lst.Add(nodes[i]);
            }
        }

        private decimal? GetMultiplier(string first, string second)
        {
            if (lst!=null)
            {
                if ((first == null) || (second == null)) return 1;
                var one = GetAttribute(first, lst).Replace('.', ',');
                var two = GetAttribute(second, lst).Replace('.', ',');
                if ((one != "0") && (two != "0"))
                {
                    return decimal.Round((decimal.Parse(two) / decimal.Parse(one)), 2);
                }
                return 1;
            }

            return null;
        }

        private static string GetAttribute(string attrib, IEnumerable<XmlNode> lst)
        {
            return attrib == "EUR" ? "1" : (from item in lst where item.Attributes?["currency"]?.Value != null where item.Attributes.Count > 0 where item.Attributes["currency"].Value == attrib select item.Attributes["rate"].Value).FirstOrDefault();
        }

        public decimal? GetValueInAnotherCurrency(decimal value, string currency, string currency2)
        {
            if (currency == currency2)
                return value;
            var output = (GetMultiplier(currency, currency2));
            return output * value;

        }

        
    }
}