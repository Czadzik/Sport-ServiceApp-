using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Net;
using XML_class_test;

namespace SportNewsService
{
    public partial class Service1 : ServiceBase
    {
        string[] id_of_rss = new[] { "pilkanozna", "siatkowka", "sportywalki", "pilkareczna", "moto", "tenis", "koszykowka", "wszystkie" };
        static string updateData(string link)
        {
           
            string data;
            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent: Other");
            data = webClient.DownloadString(link);
            return data;
        }

        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            WriteToFile("Service is started at " + DateTime.Now, "pilkanozna");
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 600000; //co jaki czas aktualizujemy dane
            timer.Enabled = true;
            // Pierwsze pobieranie danych po uruchomieniu
            WriteToFile(updateData("https://www.polsatsport.pl/rss/pilkanozna.xml"), "pilkanozna");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/siatkowka.xml"), "siatkowka");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/sportywalki.xml"), "sportywalki");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/pilkareczna.xml"), "pilkareczna");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/moto.xml"), "moto");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/tenis.xml"), "tenis");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/koszykowka.xml"), "koszykowka");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/wszystkie.xml"), "wszystkie");
            LineRemover.RemoveLine(id_of_rss);
            Deserialization.Run(id_of_rss);

        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now, "pilkanozna");
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now, "pilkanozna");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/pilkanozna.xml"), "pilkanozna");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/siatkowka.xml"), "siatkowka");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/sportywalki.xml"), "sportywalki");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/pilkareczna.xml"), "pilkareczna");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/moto.xml"), "moto");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/tenis.xml"), "tenis");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/koszykowka.xml"), "koszykowka");
            WriteToFile(updateData("https://www.polsatsport.pl/rss/wszystkie.xml"), "wszystkie");
            LineRemover.RemoveLine(id_of_rss);
            Deserialization.Run(id_of_rss);

        }
        public void WriteToFile(string Message,string id)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Updates";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Update_" +id + ".xml";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);

                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(filepath)) 
                {
                    sw.WriteLine(Message);
                }
            }

            
        }

       
    }
}
