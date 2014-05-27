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
	public class KeyValueSimpleController : UIViewController
	{
		public KeyValueSimpleController ()
		{
			this.Title = "Key Simple";
			this.View.BackgroundColor = ColorConverter.ConvertFromString ("BFDFFF");
		}

		public override void ViewDidLoad ()
		{
			//TITLE
			UILabel lblTitle = new UILabel (new RectangleF (0, 30, 1024, 35));
			lblTitle.Text = "Key Pair SimpleStorage";
			lblTitle.TextAlignment = UITextAlignment.Center;
			lblTitle.Font = UIFont.FromName ("Optima-Bold", 24);
			this.View.AddSubview (lblTitle);

			//Storage Group
			this.View.AddSubview (new UILabel (new RectangleF (20, 100, 200, 28)){ 
				Text = "Storage Group" });
			UITextField txtStorageGroup = new UITextField (new Rectangle (240, 100, 200, 28));
			txtStorageGroup.BackgroundColor = UIColor.White;
			this.View.AddSubview (txtStorageGroup);

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


			this.View.AddSubview (new UILabel (new RectangleF (20, 450, 200, 28)){ 
				Text = "DATE/COMPLEX TYPES" });
			//lblDateKeyName
			this.View.AddSubview (new UILabel (new RectangleF (20, 500, 200, 28)){ 
				Text = "Key Name" });
			UITextField txtDateKeyName = new UITextField (new Rectangle (240, 500, 200, 28));
			txtDateKeyName.BackgroundColor = UIColor.White;
			this.View.AddSubview (txtDateKeyName);
			this.View.AddSubview (new UILabel (new RectangleF (20, 550, 200, 28)){ 
				Text = "Value" });
			UITextField txtDateValue = new UITextField (new Rectangle (240, 550, 200, 28));
			txtDateValue.BackgroundColor = UIColor.White;
			this.View.AddSubview (txtDateValue);
			UIButton btnDateWrite = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(240,600,80,40)
			};
			btnDateWrite.SetTitle ("Write", UIControlState.Normal);
			this.View.AddSubview (btnDateWrite);
			UIButton btnDateRead = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(360,600,80,40)
			};
			btnDateRead.SetTitle ("Read", UIControlState.Normal);
			this.View.AddSubview (btnDateRead);
			this.View.AddSubview (new UILabel (new RectangleF (20, 650, 200, 28)){ 
				Text = "Current Value" });
			UILabel lblDateRead = new UILabel (new RectangleF (240, 650, 200, 28));
			lblDateRead.BackgroundColor = UIColor.White;
			this.View.AddSubview (lblDateRead);


			#region Button Events
			btnTextRead.TouchUpInside += (object sender, EventArgs e) => {
				//Read Text Value
				var storage = SimpleStorage.EditGroup(txtStorageGroup.Text);
				lblTextRead.Text = storage.Get(txtTextKeyName.Text);
			};

			btnTextWrite.TouchUpInside += (object sender, EventArgs e) => {
				//Write Text Value
				var storage = SimpleStorage.EditGroup(txtStorageGroup.Text);
				storage.Put(txtTextKeyName.Text, txtTextValue.Text);
			};






			btnDateRead.TouchUpInside += (object sender, EventArgs e) => {
				//Read Date Value
				var storage = SimpleStorage.EditGroup(txtStorageGroup.Text);
				DateTime storedDateTime = storage.Get<DateTime>(txtDateKeyName.Text);
				lblDateRead.Text = storedDateTime.ToLongDateString();
			};

			btnDateWrite.TouchUpInside += (object sender, EventArgs e) => {
				//Write Date Value
				var storage = SimpleStorage.EditGroup(txtStorageGroup.Text);
				DateTime dateToStore = DateTime.Parse(txtDateValue.Text);
				storage.Put<DateTime>(txtDateKeyName.Text, dateToStore);
			};
			#endregion

		}
	}
}

