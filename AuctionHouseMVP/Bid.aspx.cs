using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class Bid : ViewBasePage<BidPresenter, IBidView>, IBidView
    {
        
        public decimal ActualValue
        {
            get { return decimal.Parse(priceLabel.Text);}
            set { priceLabel.Text = value.ToString(); }
        }

        public string Value
        {
            get { return priceTextBox.Text; }
            set { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Load();
        }

        protected void BidSecond_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            _presenter.Bid();
        }

        protected void CustomValidatorPrice_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (decimal.Parse(args.Value) > ActualValue);       
        }
    }
}