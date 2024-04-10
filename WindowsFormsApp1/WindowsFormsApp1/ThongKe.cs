using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                        writer.WriteLine($"{bill.total}, {bill.date.Day}, {bill.date.Month}, {bill.date.Year}");
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

        public List<Bill> ReadThongKeFromFile(string filePath)
        {
            List<Bill> readBills = new List<Bill>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read the date line and parse it
                    string dateLine = reader.ReadLine();
                    string[] dateParts = dateLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int day = int.Parse(dateParts[0].Trim());
                    int month = int.Parse(dateParts[1].Trim());
                    int year = int.Parse(dateParts[2].Trim());
                    DateTime thongKeDate = new DateTime(year, month, day);

                    // Read the number of bills
                    int billCount = int.Parse(reader.ReadLine());

                    // Read each bill and add it to the list
                    for (int i = 0; i < billCount; i++)
                    {
                        string billLine = reader.ReadLine();
                        string[] billParts = billLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        float billTotal = float.Parse(billParts[0].Trim());

                        // Parse the bill date
                        int billDay = int.Parse(billParts[1].Trim());
                        int billMonth = int.Parse(billParts[2].Trim());
                        int billYear = int.Parse(billParts[3].Trim());
                        DateTime billDate = new DateTime(billYear, billMonth, billDay);

                        readBills.Add(new Bill { total = billTotal, date = billDate });
                    }

                    // Read the total
                    float thongKeTotal = float.Parse(reader.ReadLine());
                    // Assign the total and date to the ThongKe object
                    total = thongKeTotal;
                    date = thongKeDate;
                }

                Console.WriteLine("Thong ke read from file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return readBills;
        }
    }
}
