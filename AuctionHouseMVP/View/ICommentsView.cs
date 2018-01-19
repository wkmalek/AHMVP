using System.Collections.Generic;
using AHWForm.Models;

namespace AHWForm
{
    internal interface ICommentsView
    {
        List<CommentsView> vm { get; set; }
    }
}