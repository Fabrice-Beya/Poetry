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

			if (SelectedPoem != null)
			{
				PTitle.Text = SelectedPoem.Title;
				PContent.Text = SelectedPoem.Content;
				PDate.Text = "Created: " + SelectedPoem.DateCreated.ToShortDateString();
				Author.Text = SelectedPoem.Author;
				recorder.AudioFileName = SelectedPoem.AudioUrl;
			}
			
			base.ViewDidLoad();

			var tap = new UITapGestureRecognizer();
			tap.AddTarget(() => View.EndEditing(true));
			View.AddGestureRecognizer(tap);
			tap.CancelsTouchesInView = false;


			this.PDate.Text = "Created: " + DateTime.UtcNow.ToShortDateString();

			recorder.AudioFileName = string.Format("{0}-{1}.aac", PTitle.Text.Trim(), DateTime.Now.ToString("yyyy-MMMMM-dd"));
			Status.Text = recorder.Status;
			LengthRecording.Text = string.Format("{0:hh\\:mm\\:ss}", recorder.stopwatch.Elapsed);

			//Begin recording
			Record.TouchUpInside += (sender, e) => {
				Record.Enabled = false;
				recorder.StartRecording();
				Status.Text = recorder.Status;
				LengthRecording.Text = recorder.LengthRecorded;
			};


			StopRecording.TouchUpInside += (sender, e) => {
				recorder.StopRecording();
				recorder.StopPlay();
				Status.Text = recorder.Status;
				LengthRecording.Text = recorder.LengthRecorded;
				Record.Enabled = true;
				Play.Enabled = true;
			};

			//Begin playback 
			Play.TouchUpInside += (sender, e) => {
				Play.Enabled = false;
				if (SelectedPoem != null)
				{
					recorder.PlayRecord(SelectedPoem.AudioUrl);
				}
				else
				{
					recorder.PlayRecord(recorder.AudioFileName);
				}
			};

			//Remove current poem
			Remove.TouchUpInside += (sender, e) => {
				if (SelectedPoem != null)
				{
					db.DeleteItem(SelectedPoem);
				}
			};


			//Save current poem
			Save.TouchUpInside += (sender, e) =>
			{
				if (SelectedPoem != null)
				{
					SelectedPoem.Title = PTitle.Text;
					SelectedPoem.Content = PContent.Text;
					SelectedPoem.Author = Author.Text;
					SelectedPoem.DateCreated = DateTime.UtcNow;
					SelectedPoem.AudioUrl = recorder.AudioFileName;
					db.SaveItem(SelectedPoem);
				}
				else
				{
					db.SaveItem(new Poem()
					{
						Title = PTitle.Text,
						Content = PContent.Text,
						Author = Author.Text,
						DateCreated = DateTime.UtcNow,
						AudioUrl = recorder.AudioFileName


					});
				}
			};
		}
    }
}