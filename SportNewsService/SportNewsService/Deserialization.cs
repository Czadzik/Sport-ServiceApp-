﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XML_class_test
{
    static class Deserialization
    {
        public static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T ParseXML<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(),
                new XmlReaderSettings() {ConformanceLevel = ConformanceLevel.Document});
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        public static void Run(string[] id)
        {
            channel catalog1 = default;
            int number_of_rss = 7;
            for (int i = 0; i < number_of_rss; i++)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Update__done_" + id[i] + ".xml";
                
                    string xml = File.ReadAllText(path);

                    catalog1 = xml.ParseXML<channel>();
                   
                        DeserializationTest(catalog1);


                
                

            }

           
        }

        public static void DeserializationTest(channel catalog1)
        {
            using (StreamWriter writer1 =
                new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Test" + ".xml"))
            {
                writer1.WriteLine(catalog1.item[0].description);
            }
        }
    }
}