using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;

namespace Poetry
{
	public class ComposeViewModel : BaseViewModel
	{
		readonly internal IPoetryDataSource db;

		Poem selectedPoem;
		public Poem SelectedPoem
		{
			get 
			{ 
				return selectedPoem; 
			}
			set
			{
				SetProperty(ref selectedPoem, value);
			}
		}
		string watch;
		public string Watch
		{
			get
			{
				return Recorder.stopwatch.ElapsedMilliseconds.ToString();
			}
			set 
			{ 
				SetProperty(ref watch, value);
			}

		}

		public IRecorder Recorder;

		public ComposeViewModel()
		{
			selectedPoem = new Poem()
			{
				Content = ".....",
				DateCreated = DateTime.Today,
				AudioUrl = string.Format("{0}-{1}.aac", "Title", DateTime.Now.ToString("yyyy-MMMMM-dd"))
			};
			db = DependencyService.Get<IPoetryDataSource>();
			Recorder = DependencyService.Get<IRecorder>();
			SetAudioFileName();

		}

		void SetAudioFileName()
		{
			Recorder.AudioFileName = this.SelectedPoem.AudioUrl;
		}


		ICommand savePoemCommand;

		public ICommand SavePoemCommand
		{
			get { return savePoemCommand ?? (savePoemCommand = new Command(async () => ExecuteSavePoemCommand())); }
		}

		async Task ExecuteSavePoemCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;

				this.db.SavePoem(this.SelectedPoem);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}

		ICommand removePoemCommand;

		public ICommand RemovePoemCommand
		{
			get { return removePoemCommand ?? (removePoemCommand = new Command(async () => ExecuteRemovePoemCommand())); }
		}

		async Task ExecuteRemovePoemCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				if (this.SelectedPoem.Id != 0)
					this.db.DeletePoem(this.SelectedPoem);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}

		ICommand recordCommand;

		public ICommand RecordCommand
		{
			get { return recordCommand ?? (recordCommand = new Command(async () => ExecuteRecordCommand())); }
		}

		async Task ExecuteRecordCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				Recorder.StartRecording();
				Watch = Recorder.stopwatch.ElapsedMilliseconds.ToString();
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}

		ICommand playCommand;

		public ICommand PlayCommand
		{
			get { return playCommand ?? (playCommand = new Command(async () => ExecutePlayCommand())); }
		}

		async Task ExecutePlayCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				Recorder.PlayRecord(this.SelectedPoem.AudioUrl);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}

		ICommand stopCommand;

		public ICommand StopCommand
		{
			get { return stopCommand ?? (stopCommand = new Command(async () => ExecuteStopCommand())); }
		}

		async Task ExecuteStopCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				Recorder.StopRecording();
				Watch = Recorder.stopwatch.ElapsedMilliseconds.ToString();
				Recorder.StopPlay();
			}
			catch (Exception ex)
			{

			}
			finally
			{
				IsBusy = false;
			}
		}
	}

}

