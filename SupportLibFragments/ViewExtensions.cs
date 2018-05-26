using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Android.Util;
using Android.Views;
using System.Threading.Tasks;
using Android.App;

namespace com.xamarin.sample.fragments.supportlib {
	public static class ViewExtensions {
		public static string ToShortString(this View view) {
			if (view == null) {
				return "null";
			}
			int left = view.Left;
			int top = view.Top;
			int width = view.Width;
			int height = view.Height;
			var className = view.GetType().Name;
			var index = className.LastIndexOf(".");
			if (index == -1) {
				index = 0;
			}
			var shortName = className.Substring(index);
			string r = shortName + " " + left + " " + top + " " + width + " " + height;
			var visibility = view.Visibility;
     
			r += " " + visibility;
			return r;
		}

		public static IEnumerable<View> GetViewGroupChildren(this ViewGroup viewGroup) {
			int count = viewGroup.ChildCount;
			for (int i = 0; i < count; i++) {
				yield return viewGroup.GetChildAt(i);
			}
		}

		public static IEnumerable<View> GetChildren(this View view) {
			if (view is ViewGroup viewGroup) {
				return viewGroup.GetViewGroupChildren();
			}
			else {
				return Enumerable.Empty<View>();
			}
		}

		public static string ToStringTree(this View view, string prefix = "") {
			string r = prefix + view.ToShortString() + Environment.NewLine;
			foreach (var child in view.GetChildren()) {
				r += child.ToStringTree(prefix + "  ");
			}
			return r;
		}
    
		public static void LogStringTree(this View view) {
			var tree = view.ToStringTree();
			Log.Debug("AAA", tree);
		}

		public static void MainThreadLogStringTree(this View view) {
			var activity = view.Context as Android.App.Activity;
			activity.RunOnUiThread(() => view.LogStringTree());
		}
    
		public static void DelayedLogStringTree(this View view) {

			Task.Delay(1000).ContinueWith(t => view.MainThreadLogStringTree());
		}

	}
}
