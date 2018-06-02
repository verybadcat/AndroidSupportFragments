using System;

using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace com.xamarin.sample.fragments.supportlib
{
    internal class DetailsFragment : Fragment
    {
        public static DetailsFragment NewInstance(int playId)
        {
            var detailsFrag = new DetailsFragment {Arguments = new Bundle()};
            detailsFrag.Arguments.PutInt("current_play_id", playId);
            return detailsFrag;
        }

        public int ShownPlayId
        {
            get { return Arguments.GetInt("current_play_id", 0); }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                // Currently in a layout without a container, so no reason to create our view.
                return null;
            }
            var inflatedView = new FrameLayout(this.Activity);
            inflatedView.SetBackgroundColor(Android.Graphics.Color.Orange);
            var text = new TextView(this.Context);
            text.Text = "Hello ";
            inflatedView.AddView(text);
            var padding = 10;
            text.SetPadding(padding, padding, padding, padding);
            text.TextSize = 24;
            text.Text = Shakespeare.Dialogue[ShownPlayId];


            return inflatedView;
        }
    }
}