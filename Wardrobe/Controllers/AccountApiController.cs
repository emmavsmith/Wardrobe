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
    }
}