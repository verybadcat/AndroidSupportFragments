﻿using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;

namespace com.xamarin.sample.fragments.supportlib
{

	public class MainActivity : FragmentActivity
	{
		private TabLayout TabLayout => FindViewById<TabLayout>(Resource.Id.tab_layout);
		private ViewPager ViewPager => FindViewById<ViewPager>(Resource.Id.viewpager);

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_main);
			var manager = SupportFragmentManager;
			var adapter = new DetailsAdapter(manager);
			ViewPager.Adapter = adapter;
			TabLayout.SetupWithViewPager(ViewPager);
			adapter.RefreshPageTitles(TabLayout);
		}

        protected override void OnDestroy()
        {
            Log.Debug("AAA", "OnDestroy");
            base.OnDestroy();
        }
    }
}