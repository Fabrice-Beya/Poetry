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

		public int DeleteAll()
		{
			return Connection.DeleteAll<Poem>();
		}

		public List<Poem> GetPoems()
		{
			
			var  test =  (from i in Connection.Table<Poem>()
					select i).ToList();
			return test;

		}

		public void SavePoem(Poem poem)
		{
			if (string.IsNullOrEmpty(poem.Id))
			{
				Connection.Update(poem);

			}

			 Connection.Insert(poem);
		}

	}


}

