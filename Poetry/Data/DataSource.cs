using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Poetry
{
	public class DataSource
	{
		public SQLiteConnection Connection { get; }

		public static string Root { get; set; }

		const string filename = "sqlite3";

		public DataSource()
		{
			Connection = new SQLiteConnection(Path.Combine(Root, filename));

			Connection.CreateTable<Poem>();
		}

		#region Implement IDataSource
		public List<Poem> GetItems()
		{

			return (from i in Connection.Table<Poem>()
					select i).ToList();

		}

		public int SaveItem(Poem item)
		{

			if (item.Id != 0)
			{
				Connection.Update(item);
				return item.Id;
			}

			return Connection.Insert(item);

		}

		#endregion
	}

}

