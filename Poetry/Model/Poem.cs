using System;
using System.Collections.Generic;

namespace Poetry
{
	public class Poem
	{
		public string Id { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string Style { get; set; }
		public int Lines { get; set; }
		public List<string> LineContent { get; set; }
		public string ImageUrl { get; set; }
		public string Font { get; set; }
	}
}

