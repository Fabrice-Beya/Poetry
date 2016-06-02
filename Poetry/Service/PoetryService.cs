using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Poetry
{
	public class PoetryService
	{

		public static MobileServiceClient MobileService = new MobileServiceClient("http://127.0.0.1:8080");

		public List<Poem> Poems;

		public PoetryService()
		{
			
			Poems = new List<Poem>();

		}

		public async Task<List<Poem>> GetPoems()
		{
			var poems = Poems = await MobileService.GetTable<Poem>().ToListAsync();
			return poems;
		}

		public async Task SavePoem(Poem poem)
		{
			if (poem.Id != 0)
			{
				await MobileService.GetTable<Poem>().UpdateAsync(poem);
				return;
			}
			await MobileService.GetTable<Poem>().InsertAsync(poem);
		}

		public async Task DeletePoem(Poem poem)
		{
			await MobileService.GetTable<Poem>().DeleteAsync(poem);
		}
	}
}

