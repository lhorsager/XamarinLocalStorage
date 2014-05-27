/*
 * Example from Xamarin
 * http://docs.xamarin.com/samples/FileSystemSampleCode/
 * 
 * 
 */

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
	public class FileIOController : UIViewController
	{
		UIButton btnFiles, btnDirectories, btnAll, btnWrite, btnDirectory, btnAllDocs;
		UITextView txtView;

		public FileIOController ()
		{
			this.Title = "IO";
			this.View.BackgroundColor = ColorConverter.ConvertFromString ("BFDFFF");
		}

		public override void ViewDidLoad ()
		{
			//TITLE
			UILabel lblTitle = new UILabel (new RectangleF (0, 30, 1024, 35));
			lblTitle.Text = "File IO";
			lblTitle.TextAlignment = UITextAlignment.Center;
			lblTitle.Font = UIFont.FromName ("Optima-Bold", 24);
			this.View.AddSubview (lblTitle);

			// Create the buttons and TextView to run the sample code
			btnFiles = UIButton.FromType(UIButtonType.RoundedRect);
			btnFiles.Frame = new RectangleF(20,50,145,50);
			btnFiles.SetTitle("Open 'ReadMe.txt'", UIControlState.Normal);

			btnDirectories = UIButton.FromType(UIButtonType.RoundedRect);
			btnDirectories.Frame = new RectangleF(20,110,145,50);
			btnDirectories.SetTitle("List Directories", UIControlState.Normal);


			btnAllDocs = UIButton.FromType(UIButtonType.RoundedRect);
			btnAllDocs.Frame = new RectangleF(175,50,145,50);
			btnAllDocs.SetTitle("All Docs", UIControlState.Normal);

			btnAll = UIButton.FromType(UIButtonType.RoundedRect);
			btnAll.Frame = new RectangleF(175,110,145,50);
			btnAll.SetTitle("List All", UIControlState.Normal);

			btnWrite = UIButton.FromType(UIButtonType.RoundedRect);
			btnWrite.Frame = new RectangleF(20,170,145,50);
			btnWrite.SetTitle("Write File", UIControlState.Normal);

			btnDirectory = UIButton.FromType(UIButtonType.RoundedRect);
			btnDirectory.Frame = new RectangleF(175,170,145,50);
			btnDirectory.SetTitle("Create Directory", UIControlState.Normal);

			txtView = new UITextView(new RectangleF(20, 230, 900, 450));
			txtView.Editable = false;
			txtView.ScrollEnabled = true;

			// Wire up the buttons to the SamplCode class methods
			btnFiles.TouchUpInside += (sender, e) => {
				txtView.Text = "";

				// Sample code from the article
				var text = System.IO.File.ReadAllText("FileIO/ReadMe.txt");

				// Output to app UITextView
				txtView.Text = text;
			};

			btnDirectories.TouchUpInside += (sender, e) => {
				txtView.Text = "";

				// Sample code from the article
				var directories = Directory.EnumerateDirectories("./");

				// Output to app UITextView
				foreach (var directory in directories) {
					txtView.Text += directory + Environment.NewLine;
				}
			};

			btnAllDocs.TouchUpInside += (sender, e) => {
				txtView.Text = "";

				// Sample code from the article
				var docs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				var fileOrDirectory = Directory.EnumerateFileSystemEntries(docs);
				foreach (var entry in fileOrDirectory) {
					Console.WriteLine(entry);
				}

				// Output to app UITextView
				foreach (var entry in fileOrDirectory) {
					txtView.Text += entry + Environment.NewLine;
				}
			};

			btnAll.TouchUpInside += (sender, e) => {
				txtView.Text = "";

				// Sample code from the article
				var fileOrDirectory = Directory.EnumerateFileSystemEntries("./");
				foreach (var entry in fileOrDirectory) {
					Console.WriteLine(entry);
				}

				// Output to app UITextView
				foreach (var entry in fileOrDirectory) {
					txtView.Text += entry + Environment.NewLine;
				}
			};

			btnWrite.TouchUpInside += (sender, e) => {
				// Sample code from the article
				var documents =
					Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				var filename = Path.Combine (documents, "Write.txt");
				File.WriteAllText(filename, "Write this text into a file!");

				// Output to app UITextView
				txtView.Text = "Text was written to a file." + Environment.NewLine
					+ "-----------------" + Environment.NewLine
					+ System.IO.File.ReadAllText(filename);
			};

			btnDirectory.TouchUpInside += (sender, e) => {
				// Sample code from the article
				var documents =
					Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				var directoryname = Path.Combine (documents, "NewDirectory");
				Directory.CreateDirectory(directoryname);

				// Output to app UITextView
				txtView.Text = "A directory was created." + Environment.NewLine
					+ "-----------------" + Environment.NewLine
					+ directoryname;
			};

			// Add the controls to the view
			this.Add(btnFiles);
			this.Add(btnDirectories);
			this.Add (btnAllDocs);
			this.Add(btnAll);
			this.Add(btnWrite);
			this.Add(btnDirectory);			
			this.Add(txtView);

			// Write out this special folder, just for curiousity's sake
			Console.WriteLine("MyDocuments:"+Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
		}
	}
}

