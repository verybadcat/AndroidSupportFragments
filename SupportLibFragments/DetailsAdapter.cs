using System;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Java.Lang;

namespace com.xamarin.sample.fragments.supportlib {
	public class DetailsAdapter: FragmentPagerAdapter {
		public DetailsAdapter(FragmentManager manager): base(manager) {
    }

		public override int Count => Shakespeare.Titles.Count();

		public override Fragment GetItem(int position) {
			return DetailsFragment.NewInstance(position);
		}

		public override ICharSequence GetPageTitleFormatted(int position) {
			var str = position.ToString();
			return new Java.Lang.String(str);
		}

		internal void RefreshPageTitles(TabLayout tabLayout) {
			for (int i = 0; i < Count; i++) {
				var tab = tabLayout.GetTabAt(i);
				if (tab!=null) {
					tab.SetText( GetPageTitleFormatted(i));
				}
			}
		}
	}
}
