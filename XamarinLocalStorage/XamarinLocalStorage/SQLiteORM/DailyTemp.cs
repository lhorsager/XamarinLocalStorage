/*
 * XML File structure for serialization
 */
using System;
using System.Collections.Generic;

namespace XamarinLocalStorage
{
	public class DailyTemp
	{
		public int DailyTempId{ get; set; }
		public DateTime Date{ get; set; }
		public string Location{ get; set; }
		public float Low{ get; set; }
		public float High{ get; set; }
	}
}

