/*
 * XML File structure for serialization
 */
using System;
using System.Collections.Generic;

namespace XamarinLocalStorage
{
	public class Profile
	{
		private List<SocialNetwork> networks;

		public Profile ()
		{
			networks = new List<SocialNetwork> ();
		}

		public int ProfileId{ get; set; }
		public string DisplayName{ get; set; }
		public DateTime? LastUpdated{ get; set; }
		public List<SocialNetwork> SocialNetworks {
			get { return networks; }
			set { networks = value; }
		}

	}

	public class SocialNetwork
	{
		public int SocialNetworkId{ get; set; }
		public int ProfileId{ get; set; }
		public string AccountPath{ get; set; }
		public string DisplayName{ get; set; }
	}
}

