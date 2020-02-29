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

namespace SportNewsService
{
    public partial class Service1 : ServiceBase
    {
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
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 600000; //co jaki czas aktualizujemy dane
            timer.Enabled = true;
            // Pierwsze pobieranie danych po uruchomieniu
            WriteToFile(updateData("https://www.polsatsport.pl/rss/pilkanozna.xml"));
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
            WriteToFile(updateData("https://www.polsatsport.pl/rss/pilkanozna.xml"));
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Updates";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Update_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
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
