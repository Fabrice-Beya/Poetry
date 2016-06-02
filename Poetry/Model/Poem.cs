using System;
using System.Reflection;
using SQLite;

namespace Poetry
{
	public class Poem
	{
		
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string Style { get; set; }
		public int Lines { get; set; }
		public string Content { get; set; }
		public string ImageUrl { get; set; }
		public string AudioUrl { get; set; }
		public string Font { get; set; }
		public DateTime DateCreated { get; set; }
	}
}

