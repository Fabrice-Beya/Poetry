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
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Compose.Clicked += (sender, e) => 
			{
				Navigation.PushAsync(new ComposePage());
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
	}
}

