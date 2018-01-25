using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHWForm.Models;

namespace AHWForm.Repos
{
    public interface ICommentsRepository<T>:IRepository<T> where T:class
    {
        IEnumerable<T> GetBuyCommentsByUserID(string ID);
        IEnumerable<T> GetSellCommentsByUserID(string ID);
    }
}

