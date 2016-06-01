// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Poetry.iOS
{
    [Register ("MainNavigationController")]
    partial class MainNavigationController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar MainNavigationBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MainNavigationBar != null) {
                MainNavigationBar.Dispose ();
                MainNavigationBar = null;
            }
        }
    }
}