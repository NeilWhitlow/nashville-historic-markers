using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using HistoriCrawl.Portable;

namespace HistoriCrawl.Droid
{
	public class MarkerAdapter : BaseAdapter<Marker>
	{
		Activity context;
		List<Marker> markers;

		public MarkerAdapter(Activity context, List<Marker> markers)
		{
			this.context = context;
			this.markers = markers;
		}

		public override Marker this[int position]
		{
			get
			{
				return markers[position];
			}
		}

		public override int Count
		{
			get
			{
				return markers.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		/// <summary>
		/// Rememberd a James Montemagno article on using the convertView and a holder object on the view.tag
		/// instead of always inflating a new view and looking up the TextView elements.
		/// https://blog.xamarin.com/creating-highly-performant-smooth-scrolling-android-listviews/
		/// </summary>
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			MarkerViewHolder holder = null;

			if (view != null)
			{
				holder = view.Tag as MarkerViewHolder;				
			}

			if (holder == null)
			{
				holder = new MarkerViewHolder();
				view = context.LayoutInflater.Inflate(Resource.Layout.MarkerRow, parent, false);
				holder.Title = view.FindViewById<TextView>(Resource.Id.titleTextView);
				holder.Location = view.FindViewById<TextView>(Resource.Id.locationTextView);
				view.Tag = holder;
			}

			holder.Title.Text = markers[position].Title;
			holder.Location.Text = markers[position].Location;

			return view;
		}

		private class MarkerViewHolder : Java.Lang.Object
		{
			public TextView Title { get; set; }
			public TextView Location { get; set; }

		}
	}
}