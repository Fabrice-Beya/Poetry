using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ComposePage : ContentPage
	{
		ComposeViewModel ViewModel;

		public ComposePage()
		{
			InitializeComponent();
			BindingContext = ViewModel = new ComposeViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Save.Clicked += (sender, e) => {
				ViewModel.db.SaveItem(new Poem() { 
				Title = PTitle.Text,
					Content = Poem.Text
				});
			};
		}
	}
}

