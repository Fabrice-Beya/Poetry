using System;
using MvvmHelpers;
using Xamarin.Forms;

namespace Poetry
{
	public class ViewModelBase : BaseViewModel
	{
		internal readonly PoetryDataSource db;

		public ViewModelBase()
		{
			db = new PoetryDataSource();//DependencyService.Get<IDataSource>();
		}
	}
}

