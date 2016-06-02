using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;

using Foundation;
using UIKit;

namespace Poetry.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}
