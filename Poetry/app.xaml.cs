﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Poetry
{
	public partial class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new HomePage());
			InitializeComponent();
		}
		protected override void OnStart()
		{
			base.OnStart();
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			base.OnSleep();
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			base.OnResume();
			// Handle when your app resumes
		}
	}
}
