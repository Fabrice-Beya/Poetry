using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ExplorePage : ContentPage
	{
		ExploreViewModel viewModel;
		public ExplorePage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ExploreViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.LoadPoemsCommand.Execute(null);
		}
	}
}

