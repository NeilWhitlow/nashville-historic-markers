using System;
using Android.App;
using Android.OS;
using Android.Widget;
using HistoriCrawl.Portable;
using Newtonsoft.Json;

namespace HistoriCrawl.Droid
{
	[Activity(Label = "Marker", Icon = "@drawable/icon")]
	public class MarkerActivity : Activity
	{    
		private readonly MarkerService markerService;

		public MarkerActivity()
		{
			this.markerService = new MarkerService();
		}

		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.MarkerPage);

			// Pull object json from Intent, and inflate into Marker object
			Marker marker = JsonConvert.DeserializeObject<Marker>(this.Intent.GetStringExtra("marker_object"));

			var title = FindViewById<TextView>(Resource.Id.marker_title);
			var description = FindViewById<TextView>(Resource.Id.marker_description);
			var location = FindViewById<TextView>(Resource.Id.marker_location);
			var latitude = FindViewById<TextView>(Resource.Id.marker_latitude);
			var longitude = FindViewById<TextView>(Resource.Id.marker_longitude);

			title.Text = marker.Title;
			description.Text = marker.MarkerText;
			location.Text = marker.Location;
			latitude.Text = marker.Latitude;
			longitude.Text = marker.Longitude;
		}
	}
}