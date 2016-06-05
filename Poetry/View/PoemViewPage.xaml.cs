using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class PoemViewPage : ContentPage
	{
		PoemViewViewModel viewModel;
		public PoemViewPage(Poem poem)
		{
			InitializeComponent();

			viewModel = new PoemViewViewModel();

			viewModel.SelectedPoem = poem;
			BindingContext = viewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

		}
	}
}

