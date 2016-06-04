using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Poetry
{
	public partial class EditPage : ContentPage
	{
		EditViewModel viewModel;
		bool flag = false;
		public EditPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new EditViewModel(this);

			PoemsListView.ItemSelected +=  (sender, e) =>
			{
				if (flag==false)
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
		}
	}
}

