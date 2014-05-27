using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XamarinLocalStorage
{
	public class TabBarController : UITabBarController
	{
		UIViewController tabKeyPair, tabKeySimple, tabIO, tabXMLSerialization, tabADO, tabORM;


		public TabBarController () 
		{
		}

		public override void ViewDidLoad ()
		{
			tabKeyPair = new KeyValueController ();
			tabKeySimple = new KeyValueSimpleController ();
			tabIO = new FileIOController ();
			tabXMLSerialization = new FileXMLSerializationController ();
			tabADO = new SQLiteADOController ();
			tabORM = new SQLiteORMController ();

			var tabs = new UIViewController[] {
				tabKeyPair, tabKeySimple, tabIO, tabXMLSerialization, tabADO, tabORM
			};

			ViewControllers = tabs;
		}
	}
}

