using AHWForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Classes_And_Interfaces;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class Bid : System.Web.UI.Page, IBidView
    {
        private BidPresenter p;
        public string Value
        {
            get { return priceTextBox.Text;}
            set {}
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            p = new BidPresenter(new NewBidViewModel(), this);
            
        }

        protected void BidSecond_Click(object sender, EventArgs e)
        {
            p.Bid();
        }
 

        private bool PriceRange(string text)
        {
            //returns false if price is wrong or under 0
            decimal price;
            try
            {
                price = Decimal.Parse(text);
            }
            catch
            {
                return false;
            }
            if (price < 0)
                return false;
            return true;
        }

        


    }
}