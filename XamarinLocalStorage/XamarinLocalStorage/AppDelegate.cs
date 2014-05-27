using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XamarinLocalStorage
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			TabBarController tabs = new TabBarController ();
			window.RootViewController = tabs;
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

