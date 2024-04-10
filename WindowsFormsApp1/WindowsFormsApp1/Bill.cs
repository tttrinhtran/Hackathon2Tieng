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
                    writer.WriteLine($"{date.Day}, {date.Month}, {date.Year}, {date.Hour}, {date.Minute}");
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

        public Bill readBillFromFile(string filePath) // format file bill: 11042024_1330.txt
        {
            Bill readBill = new Bill();

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
                    int hour = int.Parse(dateParts[3].Trim());
                    int minute = int.Parse(dateParts[4].Trim());    
                    readBill.date = new DateTime(year, month, day, hour, minute, 0);

                    // Read the number of items
                    int itemCount = int.Parse(reader.ReadLine());

                    // Read each item and add it to the bill
                    for (int i = 0; i < itemCount; i++)
                    {
                        string itemLine = reader.ReadLine();
                        string[] itemParts = itemLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string itemName = itemParts[0].Trim();
                        float itemPrice = float.Parse(itemParts[1].Trim());
                        readBill.items.Add(new Item { name = itemName, price = itemPrice });
                    }

                    // Read the total
                    readBill.total = float.Parse(reader.ReadLine());
                }

                Console.WriteLine("Bill read from file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return readBill;
        }
    }
}
