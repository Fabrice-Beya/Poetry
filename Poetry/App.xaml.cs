using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class App : Application
	{
		public App()
		{
			// The root page of your application
			MainPage = new NavigationPage(new HomePage()) { 
			BarBackgroundColor = Color.FromHex("64CE66"),
				BarTextColor = Color.FromHex("29592A")
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

