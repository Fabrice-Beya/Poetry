using System;
using System.Collections.Generic;
namespace Poetry
{
	public interface IDataSource
	{
		List<Poem> GetItems();
		int SaveItem(Poem item);
	}
}

