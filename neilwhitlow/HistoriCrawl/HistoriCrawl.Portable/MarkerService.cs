using System.Threading.Tasks;
using System.Collections.Generic;

namespace HistoriCrawl.Portable
{
	public class MarkerService
	{
		public async Task<List<Marker>> GetDataAsync()
		{
			var client = new RestClient();
			return await client.GetDataAsync();
		}
	}
}

