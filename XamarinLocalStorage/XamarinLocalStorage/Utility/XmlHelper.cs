using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XamarinLocalStorage
{
	public class XmlHelper
	{
		public static void Serialize<T>(T dataToSerialize, string filePath)
		{
			try
			{
				using (Stream stream = System.IO.File.Open(filePath, FileMode.Create, FileAccess.ReadWrite))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Default);
					writer.Formatting = Formatting.Indented;
					serializer.Serialize(writer, dataToSerialize);
					writer.Close();
				}
			}
			catch
			{
				throw;
			}
		}

		public static string GetXmlString<T>(T dataToSerialize)
		{
			try
			{
				using (MemoryStream memStream = new MemoryStream())
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.Default);
					writer.Formatting = Formatting.Indented;
					serializer.Serialize(writer, dataToSerialize);
					writer.Close();

					string xml;
					xml = Encoding.UTF8.GetString(memStream.GetBuffer());

					return xml;
				}
			}
			catch
			{

				throw;
			}
		}
			
		public static T Deserialize<T>(string filePath)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				T serializedData;

				using (Stream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
					serializedData = (T)serializer.Deserialize(stream);
				}

				return serializedData;
			}
			catch
			{
				throw;
			}
		}
			
		public static T DeserializeString<T>(string xml)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				T serializedData;

				serializedData = (T)serializer.Deserialize(XmlReader.Create(new StringReader(xml)));

				return serializedData;
			}
			catch
			{
				throw;
			}
		}
	}
}
