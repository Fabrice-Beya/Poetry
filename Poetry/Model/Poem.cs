using System;
using SQLite;
using Newtonsoft.Json;

namespace Poetry
{
	public class Poem
	{
		
		[Newtonsoft.Json.JsonProperty("id")]
		public string Id { get; set; }
		[Newtonsoft.Json.JsonProperty("author")]
		public string Author { get; set; }
		[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }
		[Newtonsoft.Json.JsonProperty("content")]
		public string Content { get; set; }
		[Newtonsoft.Json.JsonProperty("audiourl")]
		public string AudioUrl { get; set; }
		[Newtonsoft.Json.JsonProperty("likes")]
		public int Likes { get; set; }

		public DateTime DateCreated { get; set;}
		[Microsoft.WindowsAzure.MobileServices.Version]
		public string AzureVersion { get; set; }
	}
}

