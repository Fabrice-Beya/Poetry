using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using MvvmHelpers;
using System.Threading.Tasks;
using System.Linq;

namespace Poetry
{
	public class ExploreViewModel:BaseViewModel
	{
		public ObservableRangeCollection<Poem> Poems { get; set; } = new ObservableRangeCollection<Poem>();
		AzureService AzureService;
		public ExploreViewModel()
		{
			AzureService = new AzureService();
		}

		ICommand loadPoemsCommand;

		public ICommand LoadPoemsCommand
		{
			get { return loadPoemsCommand ?? (loadPoemsCommand = new Command(async () => ExecuteLoadPoemsCommand())); }
		}

		async Task ExecuteLoadPoemsCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				var poems = await AzureService.GetPoems();
				Poems.ReplaceRange(poems);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}

