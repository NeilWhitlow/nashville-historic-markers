using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace HistoriCrawl.Portable
{
	public class RestClient
	{
		private const string
		RestServiceBaseAddress = "https://data.nashville.gov/resource/vk65-u7my.json",
		AcceptHeaderApplicationJson = "application/json";

		public async Task<List<Marker>> GetDataAsync()
		{
			using(var client = CreateRestClient())
			{
				var getDataResponse = await client.GetAsync("", HttpCompletionOption.ResponseContentRead);

				// If we do not get a successful status code, then return an empty list
				if(!getDataResponse.IsSuccessStatusCode)
				{
					return new List<Marker>();
				}

				// Stream the response into a JSON Value object
				var responseStream = await getDataResponse.Content.ReadAsStreamAsync();
				var jsonResponse = DeserializeFromStream(responseStream);

				// Map JSON to model object
				var markers = JsonConvert.DeserializeObject<List<Marker>>(jsonResponse);
				return markers;
			}
		}

		private HttpClient CreateRestClient()
		{
			var client = new HttpClient { BaseAddress = new Uri(RestServiceBaseAddress) };

			client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(AcceptHeaderApplicationJson));

			return client;
		}

		private static string DeserializeFromStream(Stream stream)
		{
			var serializer = new JsonSerializer();

			using (var sr = new StreamReader(stream))
			using (var jsonTextReader = new JsonTextReader(sr))
			{
				return serializer.Deserialize(jsonTextReader).ToString();
			}
		}
	}
}

