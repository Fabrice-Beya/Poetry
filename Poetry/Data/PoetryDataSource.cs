using System;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Poetry;
using Xamarin.Forms;

[assembly: Dependency(typeof(PoetryDataSource))]
namespace Poetry
{
	public class PoetryDataSource : IPoetryDataSource
	{
		
		public SQLiteConnection Connection { get; }

		public static string Root { get; set; }

		const string filename = "poem.db3";

		public PoetryDataSource()
		{
			Connection = new SQLiteConnection(Path.Combine(Root, filename));

			Connection.CreateTable<Poem>();
		}

		public int DeletePoem(Poem poem)
		{
			return Connection.Delete(poem);
		}

		public List<Poem> GetPoems()
		{
			return (from i in Connection.Table<Poem>()
					select i).ToList();

		}

		public int SavePoem(Poem poem)
		{
			if (poem.Id != 0)
			{
				Connection.Update(poem);
				return poem.Id;
			}

			return Connection.Insert(poem);
		}

	}


}

