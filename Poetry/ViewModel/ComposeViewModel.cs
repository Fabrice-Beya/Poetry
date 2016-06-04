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
				DateCreated = DateTime.Today,
				AudioUrl = string.Format("{0}-{1}.aac", "Title", DateTime.Now.ToString("yyyy-MMMMM-dd"))                     
			};


		}
	}
}

