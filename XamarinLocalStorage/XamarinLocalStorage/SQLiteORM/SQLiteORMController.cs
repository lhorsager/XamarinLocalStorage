using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections;
using System.Drawing;
using System.IO;

namespace XamarinLocalStorage
{
	public class SQLiteORMController : UIViewController
	{
		UIButton btnCreateDB, btnInsert, btnGetAll, btnGet,btnGetLINQ, btnGetHigh;

		public SQLiteORMController ()
		{
			this.Title = "ORM";
			this.View.BackgroundColor = ColorConverter.ConvertFromString ("BFDFFF");
		}

		public override void ViewDidLoad ()
		{
			//TITLE
			UILabel lblTitle = new UILabel (new RectangleF (0, 30, 1024, 35));
			lblTitle.Text = "SQLite.NET ORM";
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
			var db = GetOrCreateDatabase ();
			db.CreateTable<DailyTemp> ();
			Console.WriteLine ("Created tables");
		}

		private SQLiteConnection GetOrCreateDatabase()
		{
			var docs = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			var filename = Path.Combine (docs, "DailyTempsORM.db3");
			return new SQLiteConnection (filename);
		}

		private void AddRowsToDatabase()
		{
			var db = GetOrCreateDatabase ();

			db.DeleteAll<DailyTemp> ();

			db.Insert (new DailyTemp {
				DailyTempId=1,
				Date=DateTime.Parse("5/22/2014"),
				Low=52,
				High=70,
				Location="Minneapolis, MN"
			});
			db.Insert (new DailyTemp {
				DailyTempId=2,
				Date=DateTime.Parse("5/23/2014"),
				Low=54,
				High=73,
				Location="Minneapolis, MN"
			});
			db.Insert (new DailyTemp {
				DailyTempId=3,
				Date=DateTime.Parse("5/24/2014"),
				Low=57,
				High=79,
				Location="Minneapolis, MN"
			});
			db.Insert (new DailyTemp {
				DailyTempId=4,
				Date=DateTime.Parse("5/25/2014"),
				Low=59,
				High=79,
				Location="Minneapolis, MN"
			});
			db.Insert (new DailyTemp {
				DailyTempId=5,
				Date=DateTime.Parse("5/26/2014"),
				Low=68,
				High=81,
				Location="Minneapolis, MN"
			});
			db.Insert (new DailyTemp {
				DailyTempId=6,
				Date=DateTime.Parse("5/27/2014"),
				Low=66,
				High=70,
				Location="Minneapolis, MN"
			});


			Console.WriteLine ("Added data to database");
		}

		private void GetAllDates()
		{
			Console.WriteLine ("Get All Data");
			var db = GetOrCreateDatabase ();
			var dates = db.Table<DailyTemp> ();

			foreach (var p in dates) {
				Console.WriteLine (p.Date.ToShortDateString() + " Low: " + p.Low.ToString() + " High: " + p.High.ToString());
			}
		}

		private void GetTempRecord(int TempId)
		{
			Console.WriteLine ("GetTempRecord");
			var db = GetOrCreateDatabase ();
			var p = db.Get<DailyTemp> (TempId);
			Console.WriteLine (p.Date.ToShortDateString() + " Low: " + p.Low.ToString() + " High: " + p.High.ToString());
		}

		private void GetTempData(DateTime date)
		{
			Console.WriteLine ("GetTempData");
			var db = GetOrCreateDatabase ();
			var dates = from d in db.Table<DailyTemp> ()
					where d.Date>date
				select d;

			foreach (var p in dates) {
				Console.WriteLine (p.Date.ToShortDateString() + " Low: " + p.Low.ToString() + " High: " + p.High.ToString());
			}
		}

		private void GetHighDay()
		{
			Console.WriteLine ("GetHighDay");
			var db = GetOrCreateDatabase ();

			var highDay = db.Query<DailyTemp>("SELECT * FROM DailyTemp Order By High DESC LIMIT 1");
			foreach (var p in highDay) {
				Console.WriteLine (p.Date.ToShortDateString() + " Low: " + p.Low.ToString() + " High: " + p.High.ToString());
			}		
		}

	}
}

