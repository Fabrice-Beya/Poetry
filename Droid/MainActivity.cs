using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Poetry.Droid
{
	[Activity(Label = "Poetry.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			PoetryDataSource.Root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			LoadApplication(new App());
		}
	}
}

