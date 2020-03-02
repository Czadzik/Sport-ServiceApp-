using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNewsService
{
     public static class LineRemover
    {
        
       

        public static void RemoveLine(string []id)
        {
            int number_of_rss = 8;
            string line = null;
            int line_number = 0;
            int[] line_to_delete = new []{2,6,7,462};

            for (int i = 0; i < number_of_rss; i++)
            {
                using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Update_" + id[i] + ".xml"))
                {
                    using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Updates\\Update__done_" + id[i] + ".xml"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            line_number++;

                            if (line_number == line_to_delete[0] || line_number == line_to_delete[1] || line_number == line_to_delete[2] || line_number == line_to_delete[3])
                                continue;

                            writer.WriteLine(line);
                        }

                        line_number = 0;
                    }
                }

             
            }
            
        }

    }
}
