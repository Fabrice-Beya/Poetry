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
    [Register ("EditViewController")]
    partial class EditViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView EditView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EditView != null) {
                EditView.Dispose ();
                EditView = null;
            }
        }
    }
}