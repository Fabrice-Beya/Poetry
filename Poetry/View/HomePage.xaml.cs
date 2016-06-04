using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
			Title = "Main Menu";

			Compose.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new ComposePage(new Poem()));
			};
			Explore.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new ExplorePage());
			};
			Edit.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new EditPage());
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();


		}
	}
}

