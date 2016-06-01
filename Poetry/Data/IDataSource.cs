using System;
using System.Collections.Generic;
namespace Poetry
{
	public interface IDataSource
	{
		List<Poem> GetItems<Poem>();
		int SaveItem(Poem item);
	}
}

