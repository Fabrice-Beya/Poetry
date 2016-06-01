using Foundation;
using System;
using UIKit;

namespace Poetry.iOS
{
    public partial class MainNavigationController : UINavigationController
    {
        public MainNavigationController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationBar.Hidden = true;
		}
    }
}