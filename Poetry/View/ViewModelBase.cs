using System;
using MvvmHelpers;
using Xamarin.Forms;

namespace Poetry
{
	public class ViewModelBase : BaseViewModel
	{
		readonly internal IPoetryDataSource db;

		public ViewModelBase()
		{
			db = DependencyService.Get<IPoetryDataSource>();
		}
	}
}

