using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Poetry
{
	public partial class EditPage : ContentPage
	{
		EditViewModel viewModel;
		public EditPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new EditViewModel(this);

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			PoemsListView.ItemSelected += (sender, e) =>
			{
				var poem = PoemsListView.SelectedItem as Poem;

				viewModel.GoToCompose.Execute(poem);
				PoemsListView.SelectedItem = null;	

			};

		}
	}
}

