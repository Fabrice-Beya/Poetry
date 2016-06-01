using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			Initialize();

		}

		public void Initialize()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			//BackgroundColor = (Color)App.Current.Resources["greenPrimary"];
			Title = "Home";

			CreateBtn.Clicked += (sender, e) =>
			{
				this.Navigation.PushAsync(new ComposePage());
			};
		}
	}
}

