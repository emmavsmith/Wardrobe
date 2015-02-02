using System.Web.Http;
using Wardrobe.Repository.EF;

namespace Wardrobe.Controllers
{
    [RoutePrefix("api/Item")]
    public class ItemController : BaseApiController
    {
        public ItemController(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}