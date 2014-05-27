using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PerpetualEngine.Storage;

namespace XamarinLocalStorage
{
	public class KeyValueController : UIViewController
	{
		public KeyValueController ()
		{
			this.Title = "Key Pair";
			this.View.BackgroundColor = ColorConverter.ConvertFromString ("BFDFFF");
		}

		public override void ViewDidLoad ()
		{
			//TITLE
			UILabel lblTitle = new UILabel (new RectangleF (0, 30, 1024, 35));
			lblTitle.Text = "Key Pair Values";
			lblTitle.TextAlignment = UITextAlignment.Center;
			lblTitle.Font = UIFont.FromName ("Optima-Bold", 24);
			this.View.AddSubview (lblTitle);

			//TEXT Controls
			this.View.AddSubview (new UILabel (new RectangleF (20, 150, 200, 28)){ 
				Text = "TEXT" });
			this.View.AddSubview (new UILabel (new RectangleF (20, 200, 200, 28)){ 
				Text = "Key Name" });
			UITextField txtTextKeyName = new UITextField (new Rectangle (240, 200, 200, 28));
			txtTextKeyName.BackgroundColor = UIColor.White;
			this.View.AddSubview (txtTextKeyName);
			this.View.AddSubview (new UILabel (new RectangleF (20, 250, 200, 28)){ 
				Text = "Value" });
			UITextField txtTextValue = new UITextField (new Rectangle (240, 250, 200, 28));
			txtTextValue.BackgroundColor = UIColor.White;
			this.View.AddSubview (txtTextValue);
			UIButton btnTextWrite = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(240,300,80,40)
			};
			btnTextWrite.SetTitle ("Write", UIControlState.Normal);
			this.View.AddSubview (btnTextWrite);
			UIButton btnTextRead = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(360,300,80,40)
			};
			btnTextRead.SetTitle ("Read", UIControlState.Normal);
			this.View.AddSubview (btnTextRead);
			this.View.AddSubview (new UILabel (new RectangleF (20, 350, 200, 28)){ 
				Text = "Current Value" });
			UILabel lblTextRead = new UILabel (new RectangleF (240, 350, 200, 28));
			lblTextRead.BackgroundColor = UIColor.White;
			this.View.AddSubview (lblTextRead);


			#region Button Events
			btnTextRead.TouchUpInside += (object sender, EventArgs e) => {
				//Read Text Value
				lblTextRead.Text = NSUserDefaults.StandardUserDefaults.StringForKey (txtTextKeyName.Text);
			};

			btnTextWrite.TouchUpInside += (object sender, EventArgs e) => {
				//Write Text Value
				//NSUserDefaults.StandardUserDefaults.SetValueForKey(txtTextValue.Text, txtTextKeyName.Text);
				NSUserDefaults.StandardUserDefaults.SetString(txtTextValue.Text, txtTextKeyName.Text);
				NSUserDefaults.StandardUserDefaults.Synchronize();
			};

			#endregion
		}
	}
}

