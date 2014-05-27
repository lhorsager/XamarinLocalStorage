using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

namespace XamarinLocalStorage
{
	public class SQLiteADOController : UIViewController
	{
		UIButton btnCreateDB, btnInsert, btnGetAll, btnGet,btnGetLINQ, btnGetHigh;
		SqliteConnection db;

		public SQLiteADOController ()
		{
			this.Title = "ADO";
			this.View.BackgroundColor = ColorConverter.ConvertFromString ("BFDFFF");
		}

		public override void ViewDidLoad ()
		{
			//TITLE
			UILabel lblTitle = new UILabel (new RectangleF (0, 30, 1024, 35));
			lblTitle.Text = "SQLite ADO";
			lblTitle.TextAlignment = UITextAlignment.Center;
			lblTitle.Font = UIFont.FromName ("Optima-Bold", 24);
			this.View.AddSubview (lblTitle);

			btnCreateDB = UIButton.FromType(UIButtonType.RoundedRect);
			btnCreateDB.Frame = new RectangleF(20,100,145,50);
			btnCreateDB.SetTitle("Create Database", UIControlState.Normal);

			btnInsert = UIButton.FromType(UIButtonType.RoundedRect);
			btnInsert.Frame = new RectangleF(20,150,145,50);
			btnInsert.SetTitle("Insert data", UIControlState.Normal);

			btnGetAll = UIButton.FromType(UIButtonType.RoundedRect);
			btnGetAll.Frame = new RectangleF(20,200,145,50);
			btnGetAll.SetTitle("Get All Records", UIControlState.Normal);

			btnGet = UIButton.FromType(UIButtonType.RoundedRect);
			btnGet.Frame = new RectangleF(20,250,145,50);
			btnGet.SetTitle("Get Record", UIControlState.Normal);

			btnGetLINQ = UIButton.FromType(UIButtonType.RoundedRect);
			btnGetLINQ.Frame = new RectangleF(20,300,145,50);
			btnGetLINQ.SetTitle("LINQ Query", UIControlState.Normal);

			btnGetHigh = UIButton.FromType(UIButtonType.RoundedRect);
			btnGetHigh.Frame = new RectangleF(20,350,145,50);
			btnGetHigh.SetTitle("Get High Day", UIControlState.Normal);

			btnCreateDB.TouchUpInside += (object sender, EventArgs e) => {
				GetOrCreateDatabase();
				CreateDatabase();
			};

			btnInsert.TouchUpInside += (object sender, EventArgs e) => {
				AddRowsToDatabase();
			};

			btnGetAll.TouchUpInside += (object sender, EventArgs e) => {
				GetAllDates();
			};

			btnGet.TouchUpInside += (object sender, EventArgs e) => {
				GetTempRecord(6);
			};

			btnGetLINQ.TouchUpInside += (object sender, EventArgs e) => {
				GetTempData(DateTime.Parse("5/24/2014"));
			};

			btnGetHigh.TouchUpInside += (object sender, EventArgs e) => {
				GetHighDay();
			};


			this.View.AddSubview (btnCreateDB);
			this.View.AddSubview (btnInsert);
			this.View.AddSubview (btnGetAll);
			this.View.AddSubview (btnGet);
			this.View.AddSubview (btnGetLINQ);
			this.View.AddSubview (btnGetHigh);
		}

		private void CreateDatabase()
		{
			var docs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			var filename = Path.Combine (docs, "DailyTempsADO.db3");

			GetOrCreateDatabase ();
			if (!File.Exists (filename)) {
				SqliteConnection.CreateFile (filename);

				db.Open ();
				using (var command = db.CreateCommand ()) {
					command.CommandText = "CREATE TABLE [DailyTemp] ([_id] int, [Date] datetime, [Location] ntext, [Low] int, [High] int);";
					command.ExecuteNonQuery ();
				}

				db.Close ();
			} 
			Console.WriteLine ("Created tables");
		}

		private void GetOrCreateDatabase()
		{
			var docs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			var filename = Path.Combine (docs, "DailyTempsADO.db3");

			if (db == null) 
			{
				if (!File.Exists (filename)) {
					SqliteConnection.CreateFile (filename);
				} 
				db = new SqliteConnection ("Data Source=" + filename);
			}
		}

		private void AddRowsToDatabase()
		{
			GetOrCreateDatabase ();
			db.Open ();
			using (var command = db.CreateCommand ()) {
				command.CommandText = "Delete from [DailyTemp];";
				command.ExecuteNonQuery ();
				command.CommandText = "INSERT INTO [DailyTemp] ([_id], [Date], [Location],[Low],[High]) values (1,'5/22/2014', 'Minneapolis, MN',52, 70);";
				command.ExecuteNonQuery ();
				command.CommandText = "INSERT INTO [DailyTemp] ([_id], [Date], [Location],[Low],[High]) values (2,'5/23/2014', 'Minneapolis, MN',54, 73);";
				command.ExecuteNonQuery ();
				command.CommandText = "INSERT INTO [DailyTemp] ([_id], [Date], [Location],[Low],[High]) values (3,'5/24/2014', 'Minneapolis, MN',57, 79);";
				command.ExecuteNonQuery ();
				command.CommandText = "INSERT INTO [DailyTemp] ([_id], [Date], [Location],[Low],[High]) values (4,'5/25/2014', 'Minneapolis, MN',59, 79);";
				command.ExecuteNonQuery ();
				command.CommandText = "INSERT INTO [DailyTemp] ([_id], [Date], [Location],[Low],[High]) values (5,'5/26/2014', 'Minneapolis, MN',68, 81);";
				command.ExecuteNonQuery ();
				command.CommandText = "INSERT INTO [DailyTemp] ([_id], [Date], [Location],[Low],[High]) values (6,'5/27/2014', 'Minneapolis, MN',66, 70);";
				command.ExecuteNonQuery ();
			}

			db.Close ();

			Console.WriteLine ("Added data to database");
		}

		private void GetAllDates()
		{
			Console.WriteLine ("Get All Data");
			GetOrCreateDatabase ();
			db.Open ();
			using (var contents = db.CreateCommand ()) {
				contents.CommandText = "SELECT * from [DailyTemp]";
				var r = contents.ExecuteReader ();
				Console.WriteLine("Reading data");
				while (r.Read ())
					Console.WriteLine (" Low: " + r["Low"].ToString() + " High: " + r["High"].ToString());
			}
			db.Close ();
		}

		private void GetTempRecord(int TempId)
		{
			Console.WriteLine ("GetTempRecord");
			GetOrCreateDatabase ();
			db.Open ();
			using (var contents = db.CreateCommand ()) {
				contents.CommandText = "SELECT * from [DailyTemp] where [_id]="+TempId.ToString();
				var r = contents.ExecuteReader ();
				Console.WriteLine("Reading data");
				while (r.Read ())
					Console.WriteLine (" Low: " + r["Low"].ToString() + " High: " + r["High"].ToString());
			}
			db.Close ();		
		}

		private void GetTempData(DateTime date)
		{
			Console.WriteLine ("GetTempData");
			GetOrCreateDatabase ();
			db.Open ();
			using (var contents = db.CreateCommand ()) {
				contents.CommandText = "SELECT * from [DailyTemp] where [Date]>'"+date.ToString()+"'";
				var r = contents.ExecuteReader ();
				Console.WriteLine("Reading data");
				while (r.Read ())
					Console.WriteLine (" Low: " + r["Low"].ToString() + " High: " + r["High"].ToString());
			}
			db.Close ();
		}

		private void GetHighDay()
		{
			Console.WriteLine ("GetHighDay");
			GetOrCreateDatabase ();
			db.Open ();
			using (var contents = db.CreateCommand ()) {
				contents.CommandText = "SELECT * FROM DailyTemp Order By High DESC LIMIT 1";
				var r = contents.ExecuteReader ();
				Console.WriteLine("Reading data");
				while (r.Read ())
					Console.WriteLine (" Low: " + r["Low"].ToString() + " High: " + r["High"].ToString());
			}
			db.Close ();	
		}
	}
}

