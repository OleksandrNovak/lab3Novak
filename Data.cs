using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3
{
    public static class Data 
    {
        public class Worker {
            public String id { get; set; }
            public String last_name { get; set; }
            public String stat { get; set; }
            public String shop { get; set; }
            public String posada { get; set; }
            public String stazh { get; set; }
            public String salary { get; set; }
        }

        public class Premium
        {
            public String id { get; set; }
            public String prem { get; set; }
            
            public String year { get; set; }
        }

        public static Dictionary<int, Worker> Workers { get; private set; }
        public static Dictionary<int, Premium> Premiums { get; private set; }

        public static void ReadData(string DataDir) {
            Workers = new Dictionary<int, Worker>();
            Premiums = new Dictionary<int, Premium>();
            int i = 1;
            foreach (var line in File.ReadAllLines(DataDir + "workers.txt", Encoding.UTF8))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length != 7)
                    continue;
                Workers.Add(i, new Worker { id = words[0], last_name = words[1], stat = words[2], shop = words[3], posada = words[4], stazh = words[5], salary=words[6]});
                i++;
            }
            i = 1;
            foreach (var line in File.ReadAllLines(DataDir + "premia.txt"))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length != 3 )
                    continue;
                Premiums.Add(i, new Premium { id = words[0], prem = words[1], year = words[2] });
                i++;
            }
        }

    }
}