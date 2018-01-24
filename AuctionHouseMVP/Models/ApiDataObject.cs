using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
    public class ApiDataObject
    {
        public object data { get; set; }
        public string PublicKey { get; set; }
        public string HashedUserName { get; set; }
        public string HashedPassword { get; set; }
    }
}