using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Type
{
    Cà_phê,
    Sinh_tố,
    Nước_ép,
    Thức_ăn,
    Bánh_ngọt

}
namespace WindowsFormsApp1
{
    public class Bill
    {
        public List<Item> items { get; set; }
        public float total { get; set; }
        public DateTime date { get; set; }

        public void extractBill(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"{date.Day}, {date.Month}, {date.Year}");
                    float tmp = 0;
                    writer.WriteLine($"{items.Count}"); 
                    foreach (var item in items)
                    {
                        writer.WriteLine($"{item.name}, {item.price}");
                        tmp += item.price; 
                    }
                    writer.WriteLine($"{tmp}");
                }
                Console.WriteLine("Bill items written to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
