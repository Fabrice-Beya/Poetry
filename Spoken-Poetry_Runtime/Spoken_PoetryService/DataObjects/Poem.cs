using Microsoft.Azure.Mobile.Server;

using System;

namespace Spoken_PoetryService.DataObjects
{
	public class Poem : EntityData
    {

        public new string Id { get; set; }

        public string Author { get; set; }
		
		public string Title { get; set; }
		
		public string Content { get; set; }
		
		public string AudioUrl { get; set; }
		
		public int Likes { get; set; }
		
		public DateTime DateCreated { get; set;}

		
		public string AzureVersion { get; set; }
	}
}

