using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AHWForm.Models;
using AHWForm.Presenter;
using AHWForm.View;

namespace AHWForm
{
    public partial class Bid : Page, IBidView
    {
        private BidPresenter p;

        public decimal ActualValue
        {
            get { return 0;}
            set { priceLabel.Text = Value.ToString(); }
        }

        public string Value
        {
            get { return priceTextBox.Text; }
            set { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            p = new BidPresenter(new NewBidViewModel(), this);
            p.Load();
            CompareValidatorPrice.Type = ValidationDataType.Currency;
            CompareValidatorPrice.ValueToCompare = ActualValue.ToString();
            CompareValidatorPrice.Operator = ValidationCompareOperator.GreaterThan;


        }

        protected void BidSecond_Click(object sender, EventArgs e)
        {
            
            p.Bid();
        }

        protected void CompareValidatorPrice_OnInit(object sender, EventArgs e)
        {
            
        }
    }
}