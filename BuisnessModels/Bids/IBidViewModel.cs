using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHWForm.Models
{
    public interface IBidViewModel
    {
        bool Bid(BidsModel bidsModel, string ID);
    }
}
