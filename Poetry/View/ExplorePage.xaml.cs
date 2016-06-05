using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ExplorePage : ContentPage
	{
		ExploreViewModel viewModel;
		bool flag = false;
		public ExplorePage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ExploreViewModel(this);

			PoemsListView.ItemSelected += (sender, e) =>
		   {
			   if (flag == false)
			   {
				   flag = true;
				   var poem = PoemsListView.SelectedItem as Poem;
				   viewModel.GoToCompose.Execute(poem);
				   PoemsListView.SelectedItem = null;

			   }
		   };
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.LoadPoemsCommand.Execute(null);
		}
	}
}

