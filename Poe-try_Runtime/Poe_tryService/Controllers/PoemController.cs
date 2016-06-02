using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Poe_tryService.DataObjects;
using Poe_tryService.Models;

namespace Poe_tryService.Controllers
{
	public class PoemController : TableController<Poem>
	{
		protected override void Initialize(HttpControllerContext controllerContext)
		{
			base.Initialize(controllerContext);
			Poe_tryContext context = new Poe_tryContext();
			DomainManager = new EntityDomainManager<Poem>(context, Request);
		}

		// GET tables/TodoItem
		public IQueryable<Poem> GetAllPoems()
		{
			return Query();
		}

		// GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<Poem> GetPoem(string id)
		{
			return Lookup(id);
		}

		// PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<Poem> PatchPoem(string id, Delta<Poem> patch)
		{
			return UpdateAsync(id, patch);
		}

		// POST tables/TodoItem
		public async Task<IHttpActionResult> PostPoem(Poem item)
		{
			Poem current = await InsertAsync(item);
			return CreatedAtRoute("Tables", new { id = current.Id }, current);
		}

		// DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeletePoem(string id)
		{
			return DeleteAsync(id);
		}
	}
}