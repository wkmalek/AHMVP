using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models.Images
{
    public class ImagesModel
    {
        public string Id { get; set; }
        public byte[] Img { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string CollectionId { get; set; }
        public bool IsThumbnail { get; set; }
        public string AuctionID { get; set; }
        public string UserID { get; set; }
    }
}