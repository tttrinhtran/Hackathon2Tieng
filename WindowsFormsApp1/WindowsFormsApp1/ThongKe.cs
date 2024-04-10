using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ThongKe
    {
        public List<Bill> bills;
        public float total;
        public DateTime date;

        public void extractThongKe(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"{date.Day}, {date.Month}, {date.Year}");
                    float tmp = 0;
                    writer.WriteLine($"{bills.Count}");
                    foreach (var bill in bills)
                    {
                        writer.WriteLine($"{bill.total}, {bill.date}");
                        tmp += bill.total;
                    }
                    writer.WriteLine($"{tmp}"); 
                }
                Console.WriteLine("Thong ke written to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }   
    }
}
