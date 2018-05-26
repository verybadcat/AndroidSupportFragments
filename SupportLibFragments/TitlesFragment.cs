using System;

using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace com.xamarin.sample.fragments.supportlib {
	public class TitlesFragment : ListFragment {
		private int _currentPlayId;

		public override void OnActivityCreated(Bundle savedInstanceState) {
			base.OnActivityCreated(savedInstanceState);

			var adapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemChecked, Shakespeare.Titles);
			ListAdapter = adapter;

			if (savedInstanceState != null) {
				_currentPlayId = savedInstanceState.GetInt("current_play_id", 0);
			}


		}

		public override void OnSaveInstanceState(Bundle outState) {
			base.OnSaveInstanceState(outState);
			outState.PutInt("current_play_id", _currentPlayId);
		}

		public override void OnListItemClick(ListView l, View v, int position, long id) {
			ShowDetails(position);
		}

		private void ShowDetails(int playId) {
			_currentPlayId = playId;

			// Otherwise we need to launch a new activity to display
			// the dialog fragment with selected text.
			var intent = new Intent();

			intent.SetClass(Activity, typeof(DetailsActivity));
			intent.PutExtra("current_play_id", playId);
			StartActivity(intent);

		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
			var r = base.OnCreateView(inflater, container, savedInstanceState);
			r.Background = new ColorDrawable (Android.Graphics.Color.Red);
			return r;
		}
	}
}