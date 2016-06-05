using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers;

namespace Poetry
{
	public class EditViewModel : BaseViewModel
	{
		ContentPage page;
		readonly internal IPoetryDataSource db;

		List<Poem> poems_local;
		public List<Poem> Poems_local
		{
			get
			{
				return poems_local;
			}
			set
			{
				SetProperty(ref poems_local, value);
			}
		}

		ObservableRangeCollection<Poem> Poems { get; } = new ObservableRangeCollection<Poem>();

		public EditViewModel(ContentPage page)
		{
			this.page = page;
			db = DependencyService.Get<IPoetryDataSource>();
		}

		Command<Poem> goToCompose;

		public ICommand GoToCompose
		{
			get
			{
				return goToCompose ??
					(goToCompose = new Command<Poem>(async g => await ExecuteGoToCompose(g)));
			}
		}

		async Task ExecuteGoToCompose(Poem @poem)
		{
			if (IsBusy)
				return;

			await page.Navigation.PushAsync(new ComposePage(poem));
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
				Poems_local = db.GetPoems();
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

