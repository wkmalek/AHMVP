using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class NewBidViewModel : IBidViewModel
    {
        public decimal Value { get; set; }
        private BidsRepository repo;
        public NewBidViewModel(BidsRepository repo)
        {
            this.repo = repo;
        }

        public void Bid(BidsModel bidsModel)
        {
            repo.InsertAuction(bidsModel);
            repo.Save();
        }
    }
}