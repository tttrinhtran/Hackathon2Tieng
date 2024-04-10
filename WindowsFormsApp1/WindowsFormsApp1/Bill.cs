using System;
using System.Collections.Generic;
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
    internal class Bill
    {
        List<Item> items;
        float total;
        DateTime date;
    }
}
