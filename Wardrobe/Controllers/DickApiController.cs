using System;
using System.Text;
using System.Web.Http;

namespace Wardrobe.Controllers
{
    [RoutePrefix("api/Dick")]
    public class DickApiController : ApiController
    {
        // GET api/Dick
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var random = new Random();
            return Ok(DickGenerator(random.Next(50)));
        }

        // GET api/Dick/7
        [Route("{id:long}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(DickGenerator(id));
        }

        private static string DickGenerator(int dickSize)
        {
            var dickBuilder = new StringBuilder();
            dickBuilder.Append("3");
            for (var i = 0; i < dickSize; i++)
            {
                dickBuilder.Append("=");
            }
            dickBuilder.Append("D");
            return dickBuilder.ToString();
        }
    }
}