using AHWForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.Repos
{
    interface IAuctionDetailsRepository : IGenericRepository<AuctionModel>
    {
        AuctionModel GetSingle(int id);
    }
    
}
