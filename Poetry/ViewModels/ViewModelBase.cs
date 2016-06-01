using System;
using MvvmHelpers;
using Xamarin.Forms;

namespace Poetry
{
	public class ViewModelBase : BaseViewModel
	{
		protected readonly IDataSource db;

		public ViewModelBase()
		{
			db = DependencyService.Get<IDataSource>();
		}
	}
}

