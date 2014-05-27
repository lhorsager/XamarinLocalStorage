using System;
using System.Text;

namespace XamarinLocalStorage
{
	static public class DateConverter
	{
		static public string TimeSpanToFriendly(DateTime Date, DateTime CompareDate)
		{
			TimeSpan timeSpan;

			if (Date > CompareDate) {
				timeSpan = Date.Subtract (CompareDate);
			} else {
				timeSpan = CompareDate.Subtract (Date);
			}

			int years = timeSpan.Days / 365; 
			int months = (timeSpan.Days % 365) / 30;
			int weeks = ((timeSpan.Days % 365) % 30) / 7;
			int days = (((timeSpan.Days % 365) % 30) % 7);
			int hours = ((((timeSpan.Days % 365) % 30) % 7)/24);
			int minutes = (((((timeSpan.Days % 365) % 30) % 7)/24)/60);

			StringBuilder sb = new StringBuilder();
			if(years > 0)
			{
				if (years > 1) {
					sb.Append (years.ToString () + " years");
				} else {
					sb.Append (years.ToString () + " year");
				}
			}
			if(months > 0 && sb.Length==0)
			{
				if (months > 1) {
					sb.Append (months.ToString () + " months");
				} else {
					sb.Append (months.ToString () + " month");
				}
			}
			if(weeks > 0 && sb.Length==0)
			{
				if (weeks > 1) {
					sb.Append (weeks.ToString () + " weeks");
				} else {
					sb.Append (weeks.ToString () + " week");
				}
			}
			if(days > 0 && sb.Length==0)
			{
				if (days > 1) {
					sb.Append (days.ToString () + " days");
				} else {
					sb.Append (days.ToString () + " day");
				}
			}
			if(hours > 0 && sb.Length==0)
			{
				if (hours > 1) {
					sb.Append (hours.ToString () + " hours");
				} else {
					sb.Append (hours.ToString () + " hour");
				}
			}			
			if(minutes > 0 && sb.Length==0)
			{
				if (minutes > 1) {
					sb.Append (minutes.ToString () + " minutes");
				} else {
					sb.Append (minutes.ToString () + " minute");
				}
			}			
			return sb.ToString();
		}
	}
}

