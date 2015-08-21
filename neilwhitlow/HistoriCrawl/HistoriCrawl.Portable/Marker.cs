using Newtonsoft.Json;

namespace HistoriCrawl.Portable
{
	public class Marker
	{
		public long Number { get; set; }
		public string Title { get; set; }
		public string Location { get; set; }
		[JsonProperty("marker_text")]
		public string MarkerText { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
