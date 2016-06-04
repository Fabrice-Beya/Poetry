using System;
namespace Poetry
{
	public class ComposeViewModel : ViewModelBase
	{
		
		public Poem SelectedPoem { get; set; }

		public ComposeViewModel()
		{
			SelectedPoem = new Poem()
			{

				Content = ".....",
				DateCreated = DateTime.Today
			};


		}
	}
}

