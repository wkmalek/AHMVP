using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AHWForm.ExtMethods;
using AHWForm.Models;
using AHWForm.Models.Auctions.CreateAuction;
using AHWForm.Presenter;

namespace AHWForm.Api
{
    public class WebApiController : ApiController
    {
        // GET api/<controller>
        public CreateAuctionThroughApiModel Get()
        {
            return new CreateAuctionThroughApiModel()
            {
                Id = Guid.NewGuid().ToString(),
                AuctionTitle = "sad",
                ActualPrice = "123",
                CategoryId = "2131",
                CreatorName = "asdasd",
                CreatorId = UserHelper.GetCurrentUser(),
                Currency = "USD",
                DateCreated = DateTime.Now.ToString(),
                DateEnd = DateTime.Now.AddDays(2).ToString(),
                ExpiresIn = 2,
                LongDescription = "asdasdasd"
            };
            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody] CreateAuctionThroughApiModel vmodel)
        {
            CreateAuctionModel model = new CreateAuctionModel();
            model.CreateAuction(vmodel);
            return true;
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