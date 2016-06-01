using Foundation;
using System;
using UIKit;

namespace Poetry.iOS
{
    public partial class CreateViewController : UIViewController
    {
		DataSource db;
		public Poem SelectedPoem { get; set; }
        public CreateViewController (IntPtr handle) : base (handle)
        {
			db = new DataSource();
        }
		public override void ViewDidLoad()
		{

			
			base.ViewDidLoad();
			var tap = new UITapGestureRecognizer();
			tap.AddTarget(() => View.EndEditing(true));
			View.AddGestureRecognizer(tap);
			tap.CancelsTouchesInView = false;

			if (SelectedPoem != null)
			{
				PTitle.Text = SelectedPoem.Title;
				PContent.Text = SelectedPoem.Content;
				PDate.Text = "Created: " +SelectedPoem.DateCreated.ToShortDateString();
				Author.Text = SelectedPoem.Author;
			}

			this.PDate.Text = "Created: " + DateTime.UtcNow.ToShortDateString();

			Save.TouchUpInside += (sender, e) =>
			{
				db.SaveItem(new Poem()
				{
					Title = PTitle.Text,
					Content = PContent.Text,
					Author = Author.Text,
					DateCreated = DateTime.UtcNow
				});
			};
		}
    }
}