using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Spoken_PoetryService.DataObjects;
using Spoken_PoetryService.Models;

namespace Spoken_PoetryService.Controllers
{
    public class PoemController : TableController<Poem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            Spoken_PoetryContext context = new Spoken_PoetryContext();
            DomainManager = new EntityDomainManager<Poem>(context, Request);
        }

        // GET tables/Poem
        public IQueryable<Poem> GetAllPoem()
        {
            return Query(); 
        }

        // GET tables/Poem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Poem> GetPoem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Poem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Poem> PatchPoem(string id, Delta<Poem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Poem
        public async Task<IHttpActionResult> PostPoem(Poem item)
        {
            Poem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Poem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePoem(string id)
        {
             return DeleteAsync(id);
        }
    }
}
