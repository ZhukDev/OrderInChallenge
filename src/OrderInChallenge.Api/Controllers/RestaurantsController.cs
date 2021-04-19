using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderInChallenge.Queries.Restaurants.GetAll;
using OrderInChallenge.Queries.Restaurants.Search;

namespace OrderInChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly ISender sender;

        public RestaurantsController(ISender sender)
        {
            this.sender = sender;
        }

        /// <summary>
        /// Get all Resturants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllResturants()
        {
            var result = await this.sender.Send(new GetAllRestaurantsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Get Resturants by search key
        /// </summary>
        /// <returns></returns>
        [HttpGet("{searchKey}")]
        public async Task<IActionResult> GetAllResturants([FromRoute] string searchKey)
        {
            var query = new SearchRestaurantsQuery
            {
                Keyword = searchKey
            };
            var result = await this.sender.Send(query);
            return Ok(result);
        }
    }
}
