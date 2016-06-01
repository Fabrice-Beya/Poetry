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
    [Register ("CreateViewController")]
    partial class CreateViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Author { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CreateView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView PContent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Save { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Author != null) {
                Author.Dispose ();
                Author = null;
            }

            if (CreateView != null) {
                CreateView.Dispose ();
                CreateView = null;
            }

            if (PContent != null) {
                PContent.Dispose ();
                PContent = null;
            }

            if (PDate != null) {
                PDate.Dispose ();
                PDate = null;
            }

            if (PTitle != null) {
                PTitle.Dispose ();
                PTitle = null;
            }

            if (Save != null) {
                Save.Dispose ();
                Save = null;
            }
        }
    }
}