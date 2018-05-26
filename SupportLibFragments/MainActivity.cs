using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;

namespace com.xamarin.sample.fragments.supportlib
{
	[Activity(Label = "Fragments Walkthrough", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FragmentActivity
	{
		private TabLayout TabLayout => FindViewById<TabLayout>(Resource.Id.tab_layout);

		private void AddTabs() {
      var tabLayout = TabLayout;
      var tab1 = tabLayout.NewTab();
      var tab2 = tabLayout.NewTab();
      tab1.SetText("Hello");
      tab2.SetText("World");
      tabLayout.AddTab(tab1);
      tabLayout.AddTab(tab2);
    }

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_main);
			AddTabs();

			//var fragmentManager = SupportFragmentManager;
			//var transaction = fragmentManager.BeginTransaction();
			//transaction.Add(new TitlesFragment(), "Titles");
			//transaction.Commit();
		}
	}
}