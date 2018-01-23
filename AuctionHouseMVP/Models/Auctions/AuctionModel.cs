using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using AHWForm.Repos;

namespace AHWForm.Models
{
    public class AuctionModel 
    {
        //Somecode to calculate currency HERE
        [ScaffoldColumn(false)]        
        public string Id { get; set; }
        [ScaffoldColumn(false)]
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public decimal StartPrice { get; set; }
        public decimal EndingPrice { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }
        [ScaffoldColumn(false)]
        public int ExpiresIn { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ScaffoldColumn(false)]
        public bool IsEnded { get; set; }
        //public List<Bid> Bids { get; set; }
        [ScaffoldColumn(false)]
        public string CreatorId { get; set; } 
        [ScaffoldColumn(false)]
        public string WinnerId { get; set; }
        public string LongDescription { get; set; }
        public string Currency { get; set; }
    }

    


}