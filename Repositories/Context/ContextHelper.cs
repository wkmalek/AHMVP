using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AHWForm.Models;
using AHWForm.Models.Images;
using AHWForm.Repos;

namespace Repositories.Context
{
    public static class ContextHelper
    {
        public static string GetConnectionString(Type t)
        {
                if (t == typeof(AuctionModel))
                    return "AuctionContext";
                if (t == typeof(BidsModel))
                    return "BidContext";
                if (t == typeof(CommentsModel))
                    return "CommentsContext";
                if (t == typeof(CategoryModel))
                    return "CategoryContext";
                if (t == typeof(ImagesModel))
                    return "ImagesContext";

                throw new Exception("Bad connection string");
        }
    }
}
