using Microsoft.Azure.Mobile.Server;
using System;
namespace Poe_tryService.DataObjects
{
	public class Poem : EntityData
	{
		public string Author { get; set; }
		public string Title { get; set; }
		public string Style { get; set; }
		public int Lines { get; set; }
		public string Content { get; set; }
		public string ImageUrl { get; set; }
		public string AudioUrl { get; set; }
		public string Font { get; set; }
		public DateTime DateCreated { get; set; }
		public bool IsLiked { get; set; }
	}
}

