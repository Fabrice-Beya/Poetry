using Foundation;
using System;
using UIKit;

namespace Poetry.iOS
{
    public partial class EditViewController : UIViewController
    {
        public EditViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			PoemsTableView.Source = new PoemsTableViewSource();
			base.ViewDidLoad();
		}
    }
}