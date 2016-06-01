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
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Compose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Edit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Explore { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView HomeView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Compose != null) {
                Compose.Dispose ();
                Compose = null;
            }

            if (Edit != null) {
                Edit.Dispose ();
                Edit = null;
            }

            if (Explore != null) {
                Explore.Dispose ();
                Explore = null;
            }

            if (HomeView != null) {
                HomeView.Dispose ();
                HomeView = null;
            }
        }
    }
}