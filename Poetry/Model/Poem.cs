using System;
using SQLite;

namespace Poetry
{
	public class Poem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string AudioUrl { get; set; }
		public int Likes { get; set; }
		public DateTime DateCreated { get; set;}
	}
}

