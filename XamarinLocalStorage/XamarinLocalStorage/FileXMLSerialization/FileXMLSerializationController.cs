using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XamarinLocalStorage
{
	public class FileXMLSerializationController : UIViewController
	{
		UIButton btnCreateProfile, btnSave, btnShowXml;
		UITextView txtView;
		Profile profile;

		public FileXMLSerializationController ()
		{
			this.Title = "XML";
			this.View.BackgroundColor = ColorConverter.ConvertFromString ("BFDFFF");
		}

		public override void ViewDidLoad ()
		{
			//TITLE
			UILabel lblTitle = new UILabel (new RectangleF (0, 30, 1024, 35));
			lblTitle.Text = "XML Serialization";
			lblTitle.TextAlignment = UITextAlignment.Center;
			lblTitle.Font = UIFont.FromName ("Optima-Bold", 24);
			this.View.AddSubview (lblTitle);

			btnCreateProfile = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(20,150,200,40)
			};
			btnCreateProfile.SetTitle ("Create Profile", UIControlState.Normal);

			btnSave = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(20,200,200,40)
			};
			btnSave.SetTitle ("Save", UIControlState.Normal);

			btnShowXml = new UIButton (UIButtonType.RoundedRect) {
				Frame = new RectangleF(20,250,200,40)
			};
			btnShowXml.SetTitle ("Read XML File", UIControlState.Normal);

			txtView = new UITextView(new RectangleF(20, 320, 900, 350));
			txtView.Editable = false;
			txtView.ScrollEnabled = true;


			//Events
			btnCreateProfile.TouchUpInside += (object sender, EventArgs e) => {
				profile = new Profile () {
					DisplayName = "Mickey Mouse",
					LastUpdated = DateTime.Now,
					ProfileId = 1,
					SocialNetworks = {
						new SocialNetwork {
							AccountPath = "uk.linkedin.com/pub/mickey-mouse/97/b02/784",
							DisplayName = "Mr Mouse",
							ProfileId=1,
							SocialNetworkId = 1
						},
						new SocialNetwork {
							AccountPath = "https://twitter.com/Mickey_News",
							DisplayName = "Mickey Mouse",
							ProfileId=1,
							SocialNetworkId = 2
						} 
					}
				};
			};

			btnSave.TouchUpInside += (object sender, EventArgs e) => {
				if(profile!=null)
				{
					var docs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
					var filename = Path.Combine (docs, "Profile.xml");
					XmlHelper.Serialize<Profile>(profile, filename);
				}
			};			

			btnShowXml.TouchUpInside += (object sender, EventArgs e) => {
				var docs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				var filename = Path.Combine (docs, "Profile.xml");

				//Use to pull the actual object
				//profile = XmlHelper.Deserialize<Profile>(filename);

				//Reading as text to see what file looks like
				txtView.Text = File.ReadAllText(filename);
			};

			this.View.AddSubview (btnCreateProfile);
			this.View.AddSubview (btnSave);
			this.View.AddSubview (btnShowXml);
			this.View.AddSubview (txtView);
		}
	}
}

