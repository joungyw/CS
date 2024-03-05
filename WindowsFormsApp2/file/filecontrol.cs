using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.file
{
    internal class filecontrol
    {
        string filepath = "data.txt";

        public void write(string txet, List<string> list)
        {
            foreach (var item in list) 
            {
                Console.WriteLine(item);
            }
            File.WriteAllLines(filepath, list);
        }
        public List<string> read()
        {
            List<string> list = new List<string>(File.ReadAllLines(filepath));
            return list;
        }
    }
}
