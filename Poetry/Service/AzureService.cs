using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Poetry
{
	public class AzureService
	{
		public MobileServiceClient MobileService { get; set; }
		IMobileServiceSyncTable<Poem> poemsTable;
		public bool IsInitialized { get; set; }

		public async Task Initialize()
		{

			if (IsInitialized)
				return;
			
			//create our client
			MobileService = new MobileServiceClient("http://spoken-poetry.azurewebsites.net");

			//set up local sqlite db that will sync with cloud db initialize the table
			const string path = "syncpoems.db";
			var store = new MobileServiceSQLiteStore(path);
			store.DefineTable<Poem>();
			await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

			//get our actual tables
			poemsTable = MobileService.GetSyncTable<Poem>();

			IsInitialized = true;

		}

		public async Task<IEnumerable<Poem>> GetPoems()
		{
			await Initialize();

			//sync the database local/cloud
			await SyncPoems();

			//get all poems ordered by the most likes
			return await poemsTable.OrderBy(i => i.Likes).ToEnumerableAsync();
		}

		public async Task DeletePoem(Poem poem)
		{
			await Initialize();

			await poemsTable.DeleteAsync(poem);

			//sync the database local/cloud
			await SyncPoems();

		}

		public async Task<Poem> SavePoem(Poem poem)
		{
			await Initialize();

			//check that peom is new else update it
			if (string.IsNullOrEmpty(poem.Id))
			{
				await poemsTable.UpdateAsync(poem);

				//sync the database update
				await SyncPoems();
				return poem;
			}

			await poemsTable.InsertAsync(poem);

			//sync the database insert
			await SyncPoems();

			return poem;

		}

		public async Task SyncPoems()
		{
			await Initialize();

			//pull the latest changes from the cloud
			await poemsTable.PullAsync("allPoems", poemsTable.CreateQuery());
			//push any local changes to the cloud
			await MobileService.SyncContext.PushAsync();
		}


	}
}

