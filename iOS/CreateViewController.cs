using Foundation;
using System;
using UIKit;

namespace Poetry.iOS
{
    public partial class CreateViewController : UIViewController
    {
		DataSource db;
        public CreateViewController (IntPtr handle) : base (handle)
        {
			db = new DataSource();
        }
		public override void ViewDidLoad()
		{

			
			base.ViewDidLoad();

			this.PDate.Text += DateTime.UtcNow.ToString();

			Save.TouchUpInside += (sender, e) =>
			{
				db.SaveItem(new Poem()
				{
					Title = PTitle.Text,
					Content = PContent.Text,
					Author = Author.Text,

				});
			};
		}
    }
}