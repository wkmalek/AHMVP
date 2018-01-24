using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AHWForm.Models;

namespace AHWForm.Api
{
    public class WebApiController : ApiController
    {
        // GET api/<controller>
        public ApiUser Get()
        {
            return new ApiUser()
            {
                Id = Guid.NewGuid().ToString(),
                PrivateKey = Guid.NewGuid().ToString(),
                PublicKey = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            
            Console.WriteLine(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}