using System;
using System.Collections.Generic;


namespace Poetry
{
	public class EditViewModel : ViewModelBase
	{
		public List<Poem> PoemList { get; set; }

		public EditViewModel()
		{
			PoemList = db.GetItems();

		}

	}
}

