using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace Poetry
{
	public class PoemViewViewModel: BaseViewModel
	{
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

		public IRecorder Recorder;

		public PoemViewViewModel()
		{
			Recorder = DependencyService.Get<IRecorder>();

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

		ICommand likedCommand;

		public ICommand LikedCommand
		{
			get { return likedCommand ?? (likedCommand = new Command(async () => ExecuteLikedCommand())); }
		}

		async Task ExecuteLikedCommand()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				this.selectedPoem.Likes = this.selectedPoem.Likes+1;
				//update selected poem likes count
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

