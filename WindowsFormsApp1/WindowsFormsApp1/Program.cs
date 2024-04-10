using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
     class Program
    {
        public partial class Form1 : Form
        {
            private List<Item> items;

            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                // Load items from file
                items = new Item().ReadItemsFromFile("items.txt");

                // Populate ListView with items
                PopulateListView();
            }

            private void PopulateListView()
            {
                listView1.Items.Clear(); // Clear existing items

                foreach (Item item in items)
                {
                    ListViewItem listItem = new ListViewItem(item.Name);
                    listItem.SubItems.Add(item.Price.ToString());
                    listItem.SubItems.Add(item.Type.ToString());

                    listView1.Items.Add(listItem);
                }
            }
        }
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
