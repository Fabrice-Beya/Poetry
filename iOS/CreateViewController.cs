using Foundation;
using System;
using UIKit;

namespace Poetry.iOS
{
    public partial class CreateViewController : UIViewController
    {
		DataSource db;
		Recorder recorder;
		public Poem SelectedPoem { get; set; }
        public CreateViewController (IntPtr handle) : base (handle)
        {
			recorder = new Recorder();
			db = new DataSource();
        }
		public override void ViewDidLoad()
		{

			
			base.ViewDidLoad();

			Status.Text = recorder.Status;

			Record.TouchUpInside += (sender, e) => {
				recorder.StartRecording();
				Status.Text = recorder.Status;
				LengthRecording.Text = recorder.LengthRecorded;
			};
			LengthRecording.Text = recorder.LengthRecorded;
			StopRecording.TouchUpInside += (sender, e) => {
				recorder.StopRecording();
				Status.Text = recorder.Status;
				LengthRecording.Text = recorder.LengthRecorded;
			};

			Play.TouchUpInside += (sender, e) => {
				recorder.PlayRecord();
			};

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