using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;

using Foundation;
using UIKit;

namespace Poetry.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

			PoetryDataSource.Root = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			global::Xamarin.Forms.Forms.Init();

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			SQLitePCL.CurrentPlatform.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

