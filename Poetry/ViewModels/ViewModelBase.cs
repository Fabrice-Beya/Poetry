using System;
using MvvmHelpers;
using Xamarin.Forms;

namespace Poetry
{
	public class ViewModelBase : BaseViewModel
	{
		internal readonly IDataSource db;

		public ViewModelBase()
		{
			db = DependencyService.Get<IDataSource>();
		}
	}
}

