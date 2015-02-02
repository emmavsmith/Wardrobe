using System.Web.Http;
using Wardrobe.Repository.EF;

namespace Wardrobe.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        protected DatabaseContext DatabaseContext { get; private set; }
    }
}