using System;
using System.Web.Http;
using AHWForm.ExtMethods;
using AHWForm.Models.Auctions.CreateAuction;

namespace AHWForm.Api
{
    public class WebApiController : ApiController
    {
        // GET api/<controller>
        public CreateAuctionViewModel Get()
        {
            return new CreateAuctionViewModel
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