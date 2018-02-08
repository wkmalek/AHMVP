using System;
using System.Web.Http;
using AHWForm.ExtMethods;
using AHWForm.Models.Auctions.CreateAuction;

namespace AHWForm.Api
{
    public class WebApiController : ApiController
    {
        // GET api/<controller>
        public void Get()
        {
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody] CreateAuctionViewModel vmodel)
        {
            CreateAuctionModel model = new CreateAuctionModel();
            model.CreateAuction(vmodel);
            return true;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}