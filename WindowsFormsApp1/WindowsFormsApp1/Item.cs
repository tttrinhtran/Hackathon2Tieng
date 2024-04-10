using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{

    public enum Type
    {
        Cà_phê,
        Sinh_tố,
        Nước_ép,
        Thức_ăn,
        Bánh_ngọt

    }
   public class Item
    {
        public float price { get; set; }
        public string name { get; set; }
        public Type type { get; set; }
        public Item(string name, float price, Type type)
        {
            this.price = price;
            this.name = name;
            this.type = type;
        }

        public Item()
        {
            this.price = 0;
            this.name = "";
            this.type = 0;
        }

        public List<Item> ReadItemsFromFile(string filePath)
        {
            List<Item> items = new List<Item>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                // Parsing the first line to get the amount of items
                if (lines.Length > 0 && int.TryParse(lines[0], out int itemCount))
                {
                    int currentIndex = 1; // Start index after the amount of items
                    for (int i = 0; i < itemCount; i++)
                    {
                        string itemName = lines[currentIndex++];
                        float itemPrice = float.Parse(lines[currentIndex++]);
                        string itemTypeString = lines[currentIndex++];
                        Type itemType = GetTypeFromString(itemTypeString);

                        Item item = new Item(itemName, itemPrice, itemType);
                        items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid file format: The first line should specify the amount of items.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading the file: {ex.Message}");
            }

            return items;
        }

        private Type GetTypeFromString(string typeString)
        {
            switch (typeString.Trim().ToUpper())
            {
                case "CÀ PHÊ":
                    return Type.Cà_phê;
                case "SINH TỐ":
                    return Type.Sinh_tố;
                case "NƯỚC ÉP":
                    return Type.Nước_ép;
                case "THỨC ĂN":
                    return Type.Thức_ăn;
                case "BÁNH NGỌT":
                    return Type.Bánh_ngọt;
                default:
                    throw new ArgumentException($"Invalid item type: {typeString}");
            }
        }

        private List<Item> getItemByType(string type, List<Item> listItem)
        {
            List<Item> res = new List<Item>(); 
            foreach (var item in listItem)
            {
                if (item.type.ToString() == type)
                {
                    res.Add(item);
                }
            }
            return res; 
        }
    }
   
}
