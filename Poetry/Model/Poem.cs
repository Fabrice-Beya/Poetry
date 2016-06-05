using System;
using SQLite;
using Newtonsoft.Json;

namespace Poetry
{
	public class Poem
	{
		//temperary for the sqlite db
		[PrimaryKey,AutoIncrement]
		[Newtonsoft.Json.JsonProperty("PoemId")]
		public int PoemId { get; set; }
		[Newtonsoft.Json.JsonProperty("Id")]
		public string Id { get; set; }
		[Newtonsoft.Json.JsonProperty("Author")]
		public string Author { get; set; }
		[Newtonsoft.Json.JsonProperty("Title")]
		public string Title { get; set; }
		[Newtonsoft.Json.JsonProperty("Content")]
		public string Content { get; set; }
		[Newtonsoft.Json.JsonProperty("Audiourl")]
		public string AudioUrl { get; set; }
		[Newtonsoft.Json.JsonProperty("Likes")]
		public int Likes { get; set; }
		[Newtonsoft.Json.JsonProperty("DateCreated")]
		public DateTime DateCreated { get; set;}

		[Microsoft.WindowsAzure.MobileServices.Version]
		public string AzureVersion { get; set; }
	}
}

