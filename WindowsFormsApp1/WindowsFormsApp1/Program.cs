using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
     class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        void Init()
        {
            ThongKe thongke = new ThongKe(); 
            thongke.bills = new List<Bill>();
            thongke.date = DateTime.Now;
            thongke.total = 0;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
