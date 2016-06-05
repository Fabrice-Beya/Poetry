using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using MvvmHelpers;
using System.Threading.Tasks;

namespace Poetry
{
	public class ExploreViewModel:BaseViewModel
	{
		ObservableRangeCollection<Poem> Poems { get; } = new ObservableRangeCollection<Poem>();

		public ExploreViewModel()
		{
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

