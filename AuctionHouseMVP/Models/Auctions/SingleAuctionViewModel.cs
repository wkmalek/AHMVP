﻿namespace AHWForm.Models
{
    public abstract class SingleAuctionViewModel
    {
        public string AuctionTitle { get; set; }
        public string ActualPrice { get; set; }
        public string Currency { get; set; }
        public string CreatorName { get; set; }
        public string CreatorId { get; set; }
        public string ShortDescription { get; set; }
        public string DateCreated { get; set; }
        public string DateEnd { get; set; }
        public string Id { get; set; }
        public bool IsEnded { get; set; }
    }
}