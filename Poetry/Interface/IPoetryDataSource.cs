using System;
using System.Collections.Generic;

namespace Poetry
{
	public interface IPoetryDataSource
	{
		List<Poem> GetPoems();
		void SavePoem(Poem poem);
		int DeletePoem(Poem poem);
		int DeleteAll();
	}
}

