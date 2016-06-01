using Foundation;
using System;
using UIKit;

namespace Poetry.iOS
{
    public partial class EditViewController : UIViewController
    {
		PoemsTableViewSource source;
        public EditViewController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewDidLoad()
		{
			PoemsTableView.Source = source = new PoemsTableViewSource();
			base.ViewDidLoad();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			var vc = segue.DestinationViewController as CreateViewController;
			vc.SelectedPoem = source.GetPoem(PoemsTableView.IndexPathForSelectedRow.Row);
		}
    }
}