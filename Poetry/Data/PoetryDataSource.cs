using System;
using System.ComponentModel;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Poetry;

[assembly:Dependency(typeof(PoetryDataSource))]
namespace Poetry
{
	public class PoetryDataSource
	{
		public SQLiteConnection Connection { get; }

		public static string Root { get; set;}

		const string filename = "poem.db3";

		public PoetryDataSource()
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

