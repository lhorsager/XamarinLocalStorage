using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace XamarinLocalStorage
{
	static public class ColorConverter
	{

		public static UIColor ConvertFromString(string HexColor)
		{
			//Remove the hex modifier
			HexColor = HexColor.Replace ("#", "");

			//break hex into parts
			int r = Convert.ToInt32 (HexColor.Substring(0,2), 16);
			int g = Convert.ToInt32 (HexColor.Substring(2,2), 16);
			int b = Convert.ToInt32 (HexColor.Substring(4,2), 16);

			return UIColor.FromRGB (r, g, b);
		}
	}
}

