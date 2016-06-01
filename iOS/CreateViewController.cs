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

			if (SelectedPoem != null)
			{
				PTitle.Text = SelectedPoem.Title;
				PContent.Text = SelectedPoem.Content;
				PDate.Text = SelectedPoem.DateCreated.ToShortDateString();
				Author.Text = SelectedPoem.Author;
			}

			this.PDate.Text = DateTime.UtcNow.ToShortDateString();

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