using System.Web.Http;
using Wardrobe.Repository.EF;

namespace Wardrobe.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        [Route("Authenticate")]
        [HttpPost]
        public IHttpActionResult Authenticate()
        {
            return Ok();
        }

        [Route("Logout")]
        [HttpPost]
        public IHttpActionResult Logout()
        {
            return Ok();
        }

        [Route("Register")]
        [HttpPost]
        public IHttpActionResult Register()
        {
            return Ok();
        }
    }
}