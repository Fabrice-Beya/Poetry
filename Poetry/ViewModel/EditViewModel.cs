using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poetry
{
	public class EditViewModel : ViewModelBase
	{
		ContentPage page;
		public List<Poem> Poems
		{
			get
			{
				return db.GetPoems();
			}
			set
			{
				Poems = value;
			}
		}

		public EditViewModel(ContentPage page)
		{
			this.page = page;
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
	}
}

