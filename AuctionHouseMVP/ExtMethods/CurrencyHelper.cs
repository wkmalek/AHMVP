using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AHWForm.ExtMethods
{
    public class CurrencyHelper
    {
        public static decimal GetValueInAnotherCurrency(decimal value, string currency, string currency2)
        {
            if (currency == HttpContext.Current.Request.Cookies["currency"].Value)
                return value;
            CurrencyCalc cc = new CurrencyCalc();
            return (cc.GetMultiplier(currency,currency2))*value;
        }
    }
}