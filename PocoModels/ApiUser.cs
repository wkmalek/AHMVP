using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
    public class ApiUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }
}