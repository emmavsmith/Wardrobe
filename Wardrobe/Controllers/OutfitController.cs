using System.Web.Http;
using Wardrobe.Repository.EF;

namespace Wardrobe.Controllers
{
    [RoutePrefix("api/Outfit")]
    public class OutfitController : BaseApiController
    {
        public OutfitController(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}