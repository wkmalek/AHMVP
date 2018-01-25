using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
     public class CommentsModel
     {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        [ScaffoldColumn(false)]
        public string AuctionId {get;set;}
        [ScaffoldColumn(false)]
        public string BuyerId { get; set; }
        [ScaffoldColumn(false)]
        public string SellerId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
     }
}