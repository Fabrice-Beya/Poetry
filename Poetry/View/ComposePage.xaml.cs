using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Poetry
{
	public partial class ComposePage : ContentPage
	{
		public ComposeViewModel viewModel;
		public IRecorder Recorder;

		public ComposePage(Poem poem)
		{
			InitializeComponent();

			viewModel = new ComposeViewModel();
			if(poem.Id!=0)
				viewModel.SelectedPoem = poem;
			
			BindingContext = viewModel.SelectedPoem;
		    Recorder = DependencyService.Get<IRecorder>();
			Recorder.AudioFileName = viewModel.SelectedPoem.AudioUrl;
		}

		protected override void OnAppearing()
		{
			


			base.OnAppearing();

			this.PTitle.Text = viewModel.SelectedPoem.Title;
			this.PContent.Text = viewModel.SelectedPoem.Content;
			this.Author.Text = viewModel.SelectedPoem.Author;
			this.PDateCreated.Text = viewModel.SelectedPoem.DateCreated.ToString();



			Save.Clicked += (sender, e) => 
			{
				viewModel.SelectedPoem.Title = PTitle.Text;
				viewModel.SelectedPoem.Content = PContent.Text;
				viewModel.SelectedPoem.DateCreated = DateTime.Now;
				viewModel.SelectedPoem.Author = Author.Text;
				viewModel.SelectedPoem.Author = string.Format("{0}-{1}.aac", PTitle.Text.Trim(), DateTime.Now.ToString("yyyy-MMMMM-dd"));
				viewModel.db.SavePoem(viewModel.SelectedPoem);
			};

			Remove.Clicked += (sender, e) =>
			{
				if(viewModel.SelectedPoem.Id!=0)
					viewModel.db.DeletePoem(viewModel.SelectedPoem);
			};

			Record.Clicked += (sender, e) => 
			{
				Recorder.StartRecording();

				Record.IsEnabled = false;
				Play.IsEnabled = false;
			};
			Play.Clicked += (sender, e) =>
			{
				Recorder.PlayRecord(viewModel.SelectedPoem.AudioUrl);
			};
			Stop.Clicked += (sender, e) =>
			{
				Recorder.StopRecording();
				RTime.Text = Recorder.LengthRecorded;
				Recorder.StopPlay();
				Record.IsEnabled = true;
				Play.IsEnabled = true;
			};


		}
	}
}

