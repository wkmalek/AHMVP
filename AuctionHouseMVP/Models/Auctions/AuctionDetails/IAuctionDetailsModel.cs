using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public interface IAuctionDetailsModel
    {
        AuctionDetailsViewModel LoadAuction(string ID, string currency, ICurrencyExchangeRepository currencyRepository);
    }
}
