using Android.App;
using Android.OS;
using Android.Widget;
using HistoriCrawl.Portable;
using Android.Content;
using Newtonsoft.Json;
using Android.Runtime;
using Java.Lang;

namespace HistoriCrawl.Droid
{
	[Activity(Label = "HistoriCrawl", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private readonly MarkerService markerService;
		private ListView markerList;

		public MainActivity()
		{
			this.markerService = new MarkerService();
		}

		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			// Get a handle on the list
			markerList = FindViewById<ListView>(Resource.Id.markerListView);

			// Set the list adapter
			var markers = await markerService.GetDataAsync();
			markerList.Adapter = new MarkerAdapter(this, markers);

			// Set the list ItemClick handler
			markerList.ItemClick += OnItemClick;

		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(MarkerActivity));

			Marker selectedItem = Extensions.Cast<Marker>(markerList.GetItemAtPosition(e.Position));
			intent.PutExtra("marker_object", JsonConvert.SerializeObject(selectedItem));

			StartActivity(intent);
			return;
		}
	}
}